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
    public class CatchwordLv2Controller: Controller
    {
        private readonly EDbContext _context;
        private readonly ICatchwordLv1 _catchwordLv1Repo;
        private readonly ICatchwordLv2 _catchwordLv2Repo;

        public CatchwordLv2Controller(EDbContext context, ICatchwordLv1 catchwordLv1Repo, ICatchwordLv2 catchwordLv2Repo)
        {
            _context = context;
            _catchwordLv1Repo = catchwordLv1Repo;
            _catchwordLv2Repo = catchwordLv2Repo;
        }
        //State
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.AddColumn("Catch1_Id");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Catchword_Lv2> catchword_Lv2s = _catchwordLv2Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(catchword_Lv2s.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(catchword_Lv2s);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Catchword_Lv1 = GetCatchword_Lv1();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catchword_Lv2 catchword_Lv2s)
        {
            _context.Catchword_Lv2s.Add(catchword_Lv2s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Catchword_Lv1 = GetCatchword_Lv1();
            Catchword_Lv2 catchword_Lv2s = _context.Catchword_Lv2s.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(catchword_Lv2s);
        }
        [HttpPost]
        public IActionResult Delete(Catchword_Lv2 catchword_Lv2s)
        {
            _context.Attach(catchword_Lv2s);
            _context.Entry(catchword_Lv2s).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetCatchword_Lv1()
        {
            var lstCatchword_Lv1 = new List<SelectListItem>();
            PaginatedList<Catchword_Lv1> Catchword_Lv1 = _catchwordLv1Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstCatchword_Lv1 = Catchword_Lv1.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Catchword----"
            };

            lstCatchword_Lv1.Insert(0, defItem);

            return lstCatchword_Lv1;

        }
    }
}
