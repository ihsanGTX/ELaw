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
    public class CatchwordLv4Controller: Controller
    {
        private readonly EDbContext _context;
        private readonly ICatchwordLv3 _catchwordLv3Repo;
        private readonly ICatchwordLv4 _catchwordLv4Repo;

        public CatchwordLv4Controller(EDbContext context, ICatchwordLv3 catchwordLv3Repo, ICatchwordLv4 catchwordLv4Repo)
        {
            _context = context;
            _catchwordLv3Repo = catchwordLv3Repo;
            _catchwordLv4Repo = catchwordLv4Repo;
        }
        //State
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("Name");
            sortModel.AddColumn("Catch3_Id");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Catchword_Lv4> catchword_Lv4s = _catchwordLv4Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(catchword_Lv4s.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(catchword_Lv4s);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Catchword_Lv3 = GetCatchword_Lv3();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catchword_Lv4 catchword_Lv4s)
        {
            _context.Catchword_Lv4s.Add(catchword_Lv4s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Catchword_Lv3 = GetCatchword_Lv3();
            Catchword_Lv4 catchword_Lv4s = _context.Catchword_Lv4s.Where(a => a.Id == id).FirstOrDefault();
            TempData.Keep();
            return View(catchword_Lv4s);
        }
        [HttpPost]
        public IActionResult Delete(Catchword_Lv4 catchword_Lv4s)
        {
            _context.Attach(catchword_Lv4s);
            _context.Entry(catchword_Lv4s).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private List<SelectListItem> GetCatchword_Lv3()
        {
            var lstCatchword_Lv3 = new List<SelectListItem>();
            PaginatedList<Catchword_Lv3> Catchword_Lv3 = _catchwordLv3Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstCatchword_Lv3 = Catchword_Lv3.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Catchword----"
            };

            lstCatchword_Lv3.Insert(0, defItem);

            return lstCatchword_Lv3;

        }
    }
}
