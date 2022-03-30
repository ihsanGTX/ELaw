using ELaw.Data;
using ELaw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using ELaw.Controllers;
using Microsoft.EntityFrameworkCore;
using ELaw.Tools;
using static ELaw.Interfaces.ICascade;

namespace ELaw.Controllers
{
    public class JudgeNameController : Controller
    {
        private readonly EDbContext _context;
        private readonly IJudgeName _judgeNameRepo;
        public JudgeNameController(EDbContext context, IJudgeName judgeNameRepo)
        {
            _context = context;
            _judgeNameRepo = judgeNameRepo;
        }
        //JudgeName
        [HttpGet]
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Judge_Name> judge_Names = _judgeNameRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(judge_Names.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(judge_Names);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Judge_Name judge_Name)
        {
            _context.Judge_Names.Add(judge_Name);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Judge_Name judge_Name = _context.Judge_Names.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(judge_Name);
        }
        [HttpPost]
        public IActionResult Delete(Judge_Name judge_Name)
        {
            _context.Attach(judge_Name);
            _context.Entry(judge_Name).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
