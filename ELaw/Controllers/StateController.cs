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
using System.Collections.Generic;

namespace ELaw.Controllers
{
    public class StateController: Controller
    {
        private readonly EDbContext _context;
        private readonly IState _stateRepo;
        private readonly IJudgmentCountry _judgmentCountryRepo;
        public StateController(EDbContext context,IState stateRepo, IJudgmentCountry judgmentCountryRepo)
        {
            _context = context;
            _stateRepo = stateRepo;
            _judgmentCountryRepo = judgmentCountryRepo;
        }
        //State
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.AddColumn("Judgment_Country_Id");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<State> states = _stateRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(states.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Judgment_Countries = GetJudgment_Countries();
            return View();
        }
        [HttpPost]
        public IActionResult Create(State states)
        {
            _context.States.Add(states);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Judgment_Countries = GetJudgment_Countries();
            State state = _context.States.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(state);
        }
        [HttpPost]
        public IActionResult Delete(State state)
        {
            _context.Attach(state);
            _context.Entry(state).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetJudgment_Countries()
        {
            var lstJudgment_Countries = new List<SelectListItem>();
            PaginatedList<Judgment_Country> judgment_countries = _judgmentCountryRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstJudgment_Countries = judgment_countries.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country----"
            };

            lstJudgment_Countries.Insert(0, defItem);

            return lstJudgment_Countries;

        }
    }
}
