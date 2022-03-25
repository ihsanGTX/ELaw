using ELaw.Data;
using ELaw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace ELaw.Controllers
{
    public class CascadeController: Controller
    {
        private readonly EDbContext _context;
        public CascadeController(EDbContext context)
        {
            _context = context;
        }


        //Cascading Country


        [HttpGet]
        public IActionResult Index()
        {
            var countries = _context.Judgment_Countries.ToList();
            return View(countries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(JUDGMENT_COUNTRY countries)
        {
            _context.Judgment_Countries.Add(countries);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult StateIndex()
        {
            var states = _context.States.ToList();
            return View(states);
        }
        public IActionResult CreateState()
        {
            ViewBag.Judgement_Countries = new SelectList(_context.Judgment_Countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateState(STATE states)
        {
            _context.States.Add(states);
            _context.SaveChanges();
            return RedirectToAction("StateIndex");
        }

        //Cascading Catchword

        [HttpGet]
        public IActionResult IndexCatchword()
        {
            var catchword_lv1 = _context.Catchword_Lv1.ToList();
            return View(catchword_lv1);
        }
        [HttpGet]
        public IActionResult CreateCatchword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCatchword(CATCHWORD_LV1 catchword_Lv1)
        {
            _context.Catchword_Lv1.Add(catchword_Lv1);
            _context.SaveChanges();
            return RedirectToAction("IndexCatchword");
        }
        public IActionResult IndexCatchword2()
        {
            var catchword_lv2 = _context.Catchword_Lv2.ToList();
            return View(catchword_lv2);
        }
        public IActionResult CreateCatchword2()
        {
            ViewBag.Catchword_Lv1 = new SelectList(_context.Catchword_Lv1, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateCatchword2(CATCHWORD_LV2 catchword_Lv2)
        {
            _context.Catchword_Lv2.Add(catchword_Lv2);
            _context.SaveChanges();
            return RedirectToAction("IndexCatchword");
        }
        public IActionResult IndexCatchword3()
        {
            var catchword_lv3 = _context.Catchword_Lv3.ToList();
            return View(catchword_lv3);
        }
        public IActionResult CreateCatchword3()
        {
            ViewBag.Catchword_Lv2 = new SelectList(_context.Catchword_Lv2, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateCatchword3(CATCHWORD_LV3 catchword_Lv3)
        {
            _context.Catchword_Lv3.Add(catchword_Lv3);
            _context.SaveChanges();
            return RedirectToAction("IndexCatchword3");
        }

        //Cascade Country
        public IActionResult CascadeList()
        {
            ViewBag.Judgement_Countries = new SelectList(_context.Judgment_Countries, "Id", "Name");
            return View();
        }
        public JsonResult LoadState(string Judgment_Country_Id)
        {
            var StateList = _context.States.Where(z => z.Judgment_Country_Id == Convert.ToInt32(Judgment_Country_Id));
            return Json(new SelectList(StateList, "Id", "Name"));
        }

        //Cascade Catchword
        public IActionResult CascadeListCatchword()
        {
            ViewBag.Catchword_Lv1 = new SelectList(_context.Catchword_Lv1, "Id", "Name");
            return View();
        }
        public JsonResult LoadCatchwordLv2(int Id)
        {
            var catchword_lv2 = _context.Catchword_Lv2.Where(z => z.Id == Id).ToList();
            return Json(new SelectList(catchword_lv2, "Id", "Name"));
        }
        public JsonResult LoadCatchwordLv3(int Id)
        {
            var catchword_lv3 = _context.Catchword_Lv3.Where(z => z.Id == Id).ToList();
            return Json(new SelectList(catchword_lv3, "Id", "Name"));
        }
        public JsonResult LoadCatchwordLv4(int Id)
        {
            var catchword_lv4 = _context.Catchword_Lv4.Where(z => z.Id == Id).ToList();
            return Json(new SelectList(catchword_lv4, "Id", "Name"));
        }
    }
}
