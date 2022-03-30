using Microsoft.AspNetCore.Mvc;
using ELaw.Data;
using ELaw.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using static ELaw.Interfaces.ICascade;
using ELaw.Tools;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ELaw.Controllers
{
    [Authorize]
    public class ELawController : Controller
    {
        private readonly EDbContext _context;
        private readonly ILawReview _lawReviewRepo;
        private readonly IState _stateRepo;
        private readonly ICourtType _courtTypeRepo;
        private readonly IJudgeName _judgeNameRepo;
        private readonly IJudgmentCountry _judgmentCountryRepo;
        private readonly IJudgmentLanguage _judgmentLanguageRepo;
        private readonly ICatchwordLv1 _catchwordLv1Repo;
        private readonly ICatchwordLv2 _catchwordLv2Repo;
        private readonly ICatchwordLv3 _catchwordLv3Repo;
        private readonly ICatchwordLv4 _catchwordLv4Repo;
        public ELawController(EDbContext context, ILawReview lawReviewRepo, ICourtType courtTypeRepo, IJudgeName judgeNameRepo, IJudgmentCountry judgmentCountryRepo,
            IState stateRepo, IJudgmentLanguage judgmentLanguageRepo, ICatchwordLv1 catchwordLv1Repo, ICatchwordLv2 catchwordLv2Repo, ICatchwordLv3 catchwordLv3Repo, ICatchwordLv4 catchwordLv4Repo)
        {
            _context = context;
            _lawReviewRepo = lawReviewRepo;
            _courtTypeRepo = courtTypeRepo;
            _judgeNameRepo = judgeNameRepo;
            _judgmentCountryRepo = judgmentCountryRepo;
            _stateRepo = stateRepo;
            _judgmentLanguageRepo = judgmentLanguageRepo;
            _catchwordLv1Repo = catchwordLv1Repo;
            _catchwordLv2Repo = catchwordLv2Repo;
            _catchwordLv3Repo = catchwordLv3Repo;
            _catchwordLv4Repo = catchwordLv4Repo;
        }
        public IEnumerable<LawReview> LawReviews { get; set; }

        public async Task OnGet()
        {
            LawReviews = await _context.LawReviews.ToListAsync();
        }


        //public IActionResult SaveDocument()
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(LawReview));
        //    //get the data you want from the database
        //    LawReview po = _context.LawReviews.Include(a => a.ReferredCases).ToList()
        //    var stream = new MemoryStream();
        //    //serialize to xml
        //    serializer.Serialize(stream, po);

        //    //download the xml file
        //    return File(stream.ToArray(), "application/xml", "test.xml");
        //}
        //public XmlDocument SaveDocument(XmlDocument document, String path)
        //{
        //    using (StreamWriter stream = new StreamWriter("test.xml", false, Encoding.GetEncoding("iso-8859-7")))
        //    {
        //        document.Save(stream);
        //    }
        //    return (document);
        //}

        //protected void SaveDocument(object sender, EventArgs e)
        //{
        //    using (EDbContext db = new EDbContext())
        //    {
        //        List<LawReview> lawReviews = db.LawReviews.ToList();
        //        if (lawReviews.Count > 0)
        //        {
        //            var xEle = new XElement("LawReview", from LawReview in lawReviews select new XElement ("LawReview", 
        //                new XElement("LAWREVIEW_ID", LawReview.LAWREVIEW_ID)
        //                ));
        //            HttpContext context = HttpContext.Current;
        //            context.Response.Write(xEle);
        //            context.Response.ContentType = "application/xml";
        //            context.Response.AppendHeader("Content-Disposition", "attachment; filename");
        //        }
        //    }    
        //}

        //Document LawReview
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("JUDGMENT_NAME");
            sortModel.AddColumn("JUDGMENT_NAME_VERSUS");
            sortModel.AddColumn("JUDGMENT_NAME_ADDITIONAL");
            sortModel.AddColumn("COURT_TYPE");
            sortModel.AddColumn("JUDGE_NAME");
            sortModel.AddColumn("JUDGMENT_NUMBER");
            sortModel.AddColumn("JUDGMENT_DATE");
            sortModel.AddColumn("HEADNOTE");
            sortModel.AddColumn("JUDGMENT_COUNTRY");
            sortModel.AddColumn("STATE");
            sortModel.AddColumn("JUDGMENT_LANGUAGE");
            sortModel.AddColumn("CATCHWORD_LV1");
            sortModel.AddColumn("CATCHWORD_LV2");
            sortModel.AddColumn("CATCHWORD_LV3");
            sortModel.AddColumn("CATCHWORD_LV4");
            sortModel.AddColumn("VERDICT");
            sortModel.AddColumn("REFERRED_CASE");
            sortModel.AddColumn("REFERRED_LEGISLATION");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<LawReview> LawReviews = _lawReviewRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(LawReviews.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            return View(LawReviews);
        }
        //[HttpGet]
        //public IActionResult SaveXml()
        //{
        //    LawReview lawreview = new LawReview();

        //    ViewBag.Court_Types = GetCourt_Types();
        //    ViewBag.Judge_Names = GetJudge_Names();
        //    ViewBag.Judgment_Countries = GetJudgment_Countries();
        //    ViewBag.Judgment_Languages = GetJudgment_Languages();
        //    ViewBag.States = GetStates();
        //    ViewBag.Catchword_Lv1 = GetCatchword_Lv1();
        //    ViewBag.Catchword_Lv2 = GetCatchword_Lv2();
        //    ViewBag.Catchword_Lv3 = GetCatchword_Lv3();
        //    ViewBag.Catchword_Lv4 = GetCatchword_Lv4();

        //    lawreview.ReferredCases.Add(new ReferredCase() { REFERRED_CASES_ID = 1 });
        //    lawreview.ReferredLegislations.Add(new ReferredLegislation() { REFERRED_LEGISLATION_ID = 1 });
        //    return View(lawreview);
        //}

        //[HttpPost]
        //public IActionResult SaveXml(LawReview lawreview)
        //{
        //    lawreview.ReferredCases.RemoveAll(n => n.IsDeleted == true);
        //    lawreview.ReferredLegislations.RemoveAll(n => n.IsDeleted == true);
        //    lawreview = _lawReviewRepo.Create(lawreview);
        //    _context.Add(lawreview);
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Create()
        {
            LawReview lawreview = new LawReview();

            ViewBag.Court_Types = GetCourt_Types();
            ViewBag.Judge_Names = GetJudge_Names();
            ViewBag.Judgment_Countries = GetJudgment_Countries();
            ViewBag.Judgment_Languages = GetJudgment_Languages();
            ViewBag.States = GetStates();
            ViewBag.Catchword_Lv1 = GetCatchword_Lv1();
            ViewBag.Catchword_Lv2 = GetCatchword_Lv2();
            ViewBag.Catchword_Lv3 = GetCatchword_Lv3();
            ViewBag.Catchword_Lv4 = GetCatchword_Lv4();

            lawreview.ReferredCases.Add(new ReferredCase() { REFERRED_CASES_ID = 1 });
            lawreview.ReferredLegislations.Add(new ReferredLegislation() { REFERRED_LEGISLATION_ID = 1 });
            //lawreview.Appellants.Add(new Appellant() { APPELLANT_ID = 1 });
            //lawreview.Applicants.Add(new Applicant() { APPLICANT_ID = 1 });
            //lawreview.Claimants.Add(new Claimant() { CLAIMANT_ID = 1 });
            //lawreview.Companies.Add(new Company() { COMPANY_ID = 1 });
            //lawreview.Defendents.Add(new Defendent() { DEFENDENT_ID = 1 });
            //lawreview.Liquidators.Add(new Liquidator() { LIQUIDATOR_ID = 1 });
            //lawreview.Plaintiffs.Add(new Plaintiff() { PLAINTIFF_ID = 1 });
            //lawreview.Respondents.Add(new Respondent() { RESPONDENT_ID = 1 });
            //lawreview.ThirdParties.Add(new ThirdParty() { THIRD_PARTY_ID = 1 });
            return View(lawreview);
        }

        [HttpPost]
        public IActionResult Create(LawReview lawreview)
        {
            lawreview.ReferredCases.RemoveAll(n => n.IsDeleted == true);
            lawreview.ReferredLegislations.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Appellants.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Applicants.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Claimants.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Companies.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Defendents.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Liquidators.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Plaintiffs.RemoveAll(n => n.IsDeleted == true);
            //lawreview.Respondents.RemoveAll(n => n.IsDeleted == true);
            //lawreview.ThirdParties.RemoveAll(n => n.IsDeleted == true);
            lawreview = _lawReviewRepo.Create(lawreview);
            _context.Add(lawreview);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            LawReview lawReview = _context.LawReviews.Include(b => b.ReferredCases)/*.Include(c => c.ReferredLegislations).Include(d => d.Appellants).Include(e => e.Applicants).Include(f => f.Claimants).Include(g => g.Companies).Include(h => h.Defendents).Include(i => i.Liquidators).Include(j => j.Plaintiffs).Include(k => k.Respondents).Include(l => l.ThirdParties)*/.Where(a => a.LAWREVIEW_ID == id).FirstOrDefault();
            return View(lawReview);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Court_Types = GetCourt_Types();
            ViewBag.Judge_Names = GetJudge_Names();
            ViewBag.Judgment_Countries = GetJudgment_Countries();
            ViewBag.Judgment_Languages = GetJudgment_Languages();
            ViewBag.States = GetStates();
            ViewBag.Catchword_Lv1 = GetCatchword_Lv1();
            ViewBag.Catchword_Lv2 = GetCatchword_Lv2();
            ViewBag.Catchword_Lv3 = GetCatchword_Lv3();
            ViewBag.Catchword_Lv4 = GetCatchword_Lv4();


            LawReview lawReview = _context.LawReviews.Include(b => b.ReferredCases).Include(c => c.ReferredLegislations)/*.Include(d => d.Appellants).Include(e => e.Applicants).Include(f => f.Claimants).Include(g => g.Companies).Include(h => h.Defendents).Include(i => i.Liquidators).Include(j => j.Plaintiffs).Include(k => k.Respondents).Include(l => l.ThirdParties)*/.Where(a => a.LAWREVIEW_ID == id).FirstOrDefault();
            TempData.Keep();
            return View(lawReview);
        }

        [HttpPost]
        public IActionResult Edit(LawReview lawreview)
        {
            List<ReferredCase> refercase = _context.ReferredCases.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            List<ReferredLegislation> referlegislation = _context.ReferredLegislations.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Appellant> appellant = _context.Appellants.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Applicant> applicant = _context.Applicants.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Claimant> claimant = _context.Claimants.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Defendent> defendent = _context.Defendents.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Liquidator> liquidator = _context.Liquidators.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Plaintiff> plaintiff = _context.Plaintiffs.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Company> company = _context.Companies.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<Respondent> respondent = _context.Respondents.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            //List<ThirdParty> thirdParty = _context.ThirdParties.Where(d => d.LAWREVIEW_ID == lawreview.LAWREVIEW_ID).ToList();
            _context.ReferredCases.RemoveRange(refercase);
            _context.ReferredLegislations.RemoveRange(referlegislation);
            //_context.Appellants.RemoveRange(appellant);
            //_context.Applicants.RemoveRange(applicant);
            //_context.Claimants.RemoveRange(claimant);
            //_context.Defendents.RemoveRange(defendent);
            //_context.Liquidators.RemoveRange(liquidator);
            //_context.Plaintiffs.RemoveRange(plaintiff);
            //_context.Companies.RemoveRange(company);
            //_context.Respondents.RemoveRange(respondent);
            //_context.ThirdParties.RemoveRange(thirdParty);
            _context.SaveChanges();

            lawreview.ReferredCases.RemoveAll(a => a.IsDeleted == true);
            lawreview.ReferredLegislations.RemoveAll(b => b.IsDeleted == true);
            //lawreview.Appellants.RemoveAll(c => c.IsDeleted == true);
            //lawreview.Applicants.RemoveAll(e => e.IsDeleted == true);
            //lawreview.Claimants.RemoveAll(f => f.IsDeleted == true);
            //lawreview.Companies.RemoveAll(g => g.IsDeleted == true);
            //lawreview.Defendents.RemoveAll(h => h.IsDeleted == true);
            //lawreview.Liquidators.RemoveAll(h => h.IsDeleted == true);
            //lawreview.Plaintiffs.RemoveAll(i => i.IsDeleted == true);
            //lawreview.Respondents.RemoveAll(j => j.IsDeleted == true);
            //lawreview.ThirdParties.RemoveAll(k => k.IsDeleted == true);


            _context.Attach(lawreview);
            _context.Entry(lawreview).State = EntityState.Modified;
            _context.ReferredCases.AddRange(lawreview.ReferredCases);
            _context.ReferredLegislations.AddRange(lawreview.ReferredLegislations);
            //_context.Appellants.AddRange(lawreview.Appellants);
            //_context.Applicants.AddRange(lawreview.Applicants);
            //_context.Claimants.AddRange(lawreview.Claimants);
            //_context.Companies.AddRange(lawreview.Companies);
            //_context.Defendents.AddRange(lawreview.Defendents);
            //_context.Liquidators.AddRange(lawreview.Liquidators);
            //_context.Plaintiffs.AddRange(lawreview.Plaintiffs);
            //_context.Respondents.AddRange(lawreview.Respondents);
            //_context.ThirdParties.AddRange(lawreview.ThirdParties);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LawReview lawReview = _context.LawReviews.Include(b => b.ReferredCases).Include(c => c.ReferredLegislations)/*.Include(d => d.Appellants).Include(e => e.Applicants).Include(f => f.Claimants).Include(g => g.Companies).Include(h => h.Defendents).Include(i => i.Liquidators).Include(j => j.Plaintiffs).Include(k => k.Respondents).Include(l => l.ThirdParties)*/.Where(a => a.LAWREVIEW_ID == id).FirstOrDefault();
            TempData.Keep();
            return View(lawReview);
        }
        [HttpPost]
        public IActionResult Delete(LawReview lawReview)
        {
            _context.Attach(lawReview);
            _context.Entry(lawReview).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get method
        private List<SelectListItem> GetCourt_Types()
        {
            var lstCourt_Types = new List<SelectListItem>();
            PaginatedList<COURT_TYPE> Court_Types = _courtTypeRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstCourt_Types = Court_Types.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Court Type----"
            };

            lstCourt_Types.Insert(0, defItem);

            return lstCourt_Types;

        }
        private List<SelectListItem> GetJudge_Names()
        {
            var lstJudge_Names = new List<SelectListItem>();
            PaginatedList<JUDGE_NAME> judge_names = _judgeNameRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstJudge_Names = judge_names.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Judge----"
            };

            lstJudge_Names.Insert(0, defItem);

            return lstJudge_Names;

        }
        private List<SelectListItem> GetJudgment_Countries()
        {
            var lstJudgment_Countries = new List<SelectListItem>();
            PaginatedList<JUDGMENT_COUNTRY> judgment_countries = _judgmentCountryRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
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
        public JsonResult GetStateId(int countryId)
        {
            var data = _context.States.Where(x => x.Judgment_Country_Id == countryId).ToList();
            return Json(data);
        }
        private List<SelectListItem> GetStates()
        {
            var lstStates = new List<SelectListItem>();
            PaginatedList<STATE> states = _stateRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstStates = states.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select State----"
            };
            lstStates.Insert(0, defItem);

            return lstStates;

        }
        private List<SelectListItem> GetJudgment_Languages()
        {
            var lstJudgment_Languages = new List<SelectListItem>();
            PaginatedList<JUDGMENT_LANGUAGE> judgment_languages = _judgmentLanguageRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstJudgment_Languages = judgment_languages.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Unit----"
            };

            lstJudgment_Languages.Insert(0, defItem);

            return lstJudgment_Languages;

        }
        private List<SelectListItem> GetCatchword_Lv1()
        {
            var lstCatchword_Lv1 = new List<SelectListItem>();
            PaginatedList<CATCHWORD_LV1> Catchword_Lv1 = _catchwordLv1Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
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
        private List<SelectListItem> GetCatchword_Lv2()
        {
            var lstCatchword_Lv1 = new List<SelectListItem>();
            PaginatedList<CATCHWORD_LV2> Catchword_Lv2 = _catchwordLv2Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
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
        private List<SelectListItem> GetCatchword_Lv3()
        {
            var lstCatchword_Lv3 = new List<SelectListItem>();
            PaginatedList<CATCHWORD_LV3> Catchword_Lv3 = _catchwordLv3Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
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
        private List<SelectListItem> GetCatchword_Lv4()
        {
            var lstCatchword_Lv4 = new List<SelectListItem>();
            PaginatedList<CATCHWORD_LV4> Catchword_Lv4 = _catchwordLv4Repo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstCatchword_Lv4 = Catchword_Lv4.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Catchword----"
            };

            lstCatchword_Lv4.Insert(0, defItem);

            return lstCatchword_Lv4;

        }

        //Json
        [HttpGet]
        public JsonResult GetStateList(int Id)
        {
            var Items = _context.States.Where(x => x.Judgment_Country_Id == Id).ToList();
            return Json(Items);
        }
        [HttpGet]
        public JsonResult GetCatchlv2(int Id)
        {
            var Items = _context.Catchword_Lv2.Where(x => x.Catch1_Id == Id).ToList();
            return Json(Items);
        }
        [HttpGet]
        public JsonResult GetCatchlv3(int Id)
        {
            var Items = _context.Catchword_Lv3.Where(x => x.Catch2_Id == Id).ToList();
            return Json(Items);
        }
        [HttpGet]
        public JsonResult GetCatchlv4(int Id)
        {
            var Items = _context.Catchword_Lv4.Where(x => x.Catch3_Id == Id).ToList();
            return Json(Items);
        }
    }
}
