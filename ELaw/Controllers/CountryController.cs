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
    public class CountryController: Controller
    {
        private readonly EDbContext _context;
        private readonly IJudgmentCountry _judgmentCountryRepo;
        public CountryController(EDbContext context,IJudgmentCountry judgmentCountryRepo)
        {
            _context = context;
            _judgmentCountryRepo = judgmentCountryRepo;
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

            PaginatedList<Judgment_Country> judgment_Countries = _judgmentCountryRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(judgment_Countries.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(judgment_Countries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Judgment_Country countries)
        {
            _context.Judgment_Countries.Add(countries);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Judgment_Country judgment_country = _context.Judgment_Countries.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(judgment_country);
        }
        [HttpPost]
        public IActionResult Delete(Judgment_Country judgment_country)
        {
            _context.Attach(judgment_country);
            _context.Entry(judgment_country).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
