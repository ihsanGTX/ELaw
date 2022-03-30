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
    public class CatchwordLv1Controller: Controller
    {
        private readonly EDbContext _context;
        private readonly ICatchwordLv1 _catchwordLv1Repo;
        public CatchwordLv1Controller(EDbContext context, ICatchwordLv1 catchwordLv1Repo)
        {
            _context = context;
            _catchwordLv1Repo = catchwordLv1Repo;
        }
        //Country
        [HttpGet]
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Catchword_Lv1> catchword_Lv1s = _catchwordLv1Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(catchword_Lv1s.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(catchword_Lv1s);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catchword_Lv1 catchword_Lv1s)
        {
            _context.Catchword_Lv1s.Add(catchword_Lv1s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Catchword_Lv1 catchword_Lv1s = _context.Catchword_Lv1s.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(catchword_Lv1s);
        }
        [HttpPost]
        public IActionResult Delete(Catchword_Lv1 catchword_Lv1s)
        {
            _context.Attach(catchword_Lv1s);
            _context.Entry(catchword_Lv1s).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
