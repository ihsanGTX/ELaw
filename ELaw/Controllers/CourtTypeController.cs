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
    public class CourtTypeController: Controller
    {
        private readonly EDbContext _context;
        private readonly ICourtType _courtTypeRepo;
        public CourtTypeController(EDbContext context, ICourtType courtTypeRepo)
        {
            _context = context;
            _courtTypeRepo = courtTypeRepo;
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

            PaginatedList<Court_Type> court_Types = _courtTypeRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(court_Types.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(court_Types);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Court_Type court_Type)
        {
            _context.Court_Types.Add(court_Type);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Court_Type court_Type = _context.Court_Types.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(court_Type);
        }
        [HttpPost]
        public IActionResult Delete(Court_Type court_Type)
        {
            _context.Attach(court_Type);
            _context.Entry(court_Type).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
