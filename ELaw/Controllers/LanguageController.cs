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
    public class LanguageController: Controller
    {
        private readonly EDbContext _context;
        private readonly IJudgmentLanguage _judgmentLanguageRepo;
        public LanguageController(EDbContext context, IJudgmentLanguage judgmentLanguageRepo)
        {
            _context = context;
            _judgmentLanguageRepo = judgmentLanguageRepo;
        }
        //CourtType
        [HttpGet]
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Judgment_Language> judgment_Languages = _judgmentLanguageRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(judgment_Languages.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(judgment_Languages);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Judgment_Language judgment_Languages)
        {
            _context.Judgment_Languages.Add(judgment_Languages);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Judgment_Language judgment_Languages = _context.Judgment_Languages.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(judgment_Languages);
        }
        [HttpPost]
        public IActionResult Delete(Judgment_Language judgment_Languages)
        {
            _context.Attach(judgment_Languages);
            _context.Entry(judgment_Languages).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
