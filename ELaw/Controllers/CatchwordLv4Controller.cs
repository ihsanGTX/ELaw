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
    public class CatchwordLv3Controller: Controller
    {
        private readonly EDbContext _context;
        private readonly ICatchwordLv2 _catchwordLv2Repo;
        private readonly ICatchwordLv3 _catchwordLv3Repo;

        public CatchwordLv3Controller(EDbContext context, ICatchwordLv2 catchwordLv2Repo, ICatchwordLv3 catchwordLv3Repo)
        {
            _context = context;
            _catchwordLv2Repo = catchwordLv2Repo;
            _catchwordLv3Repo = catchwordLv3Repo;
        }
        //State
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.AddColumn("Catch2_Id");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Catchword_Lv3> catchword_Lv3s = _catchwordLv3Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(catchword_Lv3s.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(catchword_Lv3s);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Catchword_Lv2 = GetCatchword_Lv2();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catchword_Lv3 catchword_Lv3s)
        {
            _context.Catchword_Lv3s.Add(catchword_Lv3s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Catchword_Lv2 = GetCatchword_Lv2();
            Catchword_Lv3 catchword_Lv3s = _context.Catchword_Lv3s.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(catchword_Lv3s);
        }
        [HttpPost]
        public IActionResult Delete(Catchword_Lv3 catchword_Lv3s)
        {
            _context.Attach(catchword_Lv3s);
            _context.Entry(catchword_Lv3s).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetCatchword_Lv2()
        {
            var lstCatchword_Lv1 = new List<SelectListItem>();
            PaginatedList<Catchword_Lv2> Catchword_Lv2 = _catchwordLv2Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstCatchword_Lv1 = Catchword_Lv2.Select(ut => new SelectListItem()
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
