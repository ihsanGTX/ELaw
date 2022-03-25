
using ELaw.Data;
using ELaw.Models;
using ELaw.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static ELaw.Interfaces.ICascade;

namespace ELaw.Repositories
{
    public class CascadeRepo
    {
        public class CatchwordLv1Repo : ICatchwordLv1
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public CatchwordLv1Repo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public CATCHWORD_LV1 Create(CATCHWORD_LV1 CATCHWORD_LV1)
            {
                _context.Catchword_Lv1.Add(CATCHWORD_LV1);
                _context.SaveChanges();
                return CATCHWORD_LV1;
            }

            public CATCHWORD_LV1 Delete(CATCHWORD_LV1 CATCHWORD_LV1)
            {
                _context.Catchword_Lv1.Attach(CATCHWORD_LV1);
                _context.Entry(CATCHWORD_LV1).State = EntityState.Deleted;
                _context.SaveChanges();
                return CATCHWORD_LV1;
            }

            public CATCHWORD_LV1 Edit(CATCHWORD_LV1 CATCHWORD_LV1)
            {
                _context.Catchword_Lv1.Attach(CATCHWORD_LV1);
                _context.Entry(CATCHWORD_LV1).State = EntityState.Modified;
                _context.SaveChanges();
                return CATCHWORD_LV1;
            }


            private List<CATCHWORD_LV1> DoSort(List<CATCHWORD_LV1> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name_Lv1).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name_Lv1).ToList();
                }

                return items;
            }

            public PaginatedList<CATCHWORD_LV1> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<CATCHWORD_LV1> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv1.Where(n => n.Name_Lv1.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv1.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<CATCHWORD_LV1> retItems = new PaginatedList<CATCHWORD_LV1>(items, pageIndex, pageSize);

                return retItems;
            }

            public CATCHWORD_LV1 GetCatchword_Lv1(int id)
            {
                CATCHWORD_LV1 item = _context.Catchword_Lv1.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv1.Where(n => n.Name_Lv1.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv1.Where(n => n.Name_Lv1.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class CatchwordLv2Repo : ICatchwordLv2
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public CatchwordLv2Repo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public CATCHWORD_LV2 Create(CATCHWORD_LV2 CATCHWORD_LV2)
            {
                _context.Catchword_Lv2.Add(CATCHWORD_LV2);
                _context.SaveChanges();
                return CATCHWORD_LV2;
            }

            public CATCHWORD_LV2 Delete(CATCHWORD_LV2 CATCHWORD_LV2)
            {
                _context.Catchword_Lv2.Attach(CATCHWORD_LV2);
                _context.Entry(CATCHWORD_LV2).State = EntityState.Deleted;
                _context.SaveChanges();
                return CATCHWORD_LV2;
            }

            public CATCHWORD_LV2 Edit(CATCHWORD_LV2 CATCHWORD_LV2)
            {
                _context.Catchword_Lv2.Attach(CATCHWORD_LV2);
                _context.Entry(CATCHWORD_LV2).State = EntityState.Modified;
                _context.SaveChanges();
                return CATCHWORD_LV2;
            }


            private List<CATCHWORD_LV2> DoSort(List<CATCHWORD_LV2> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name_Lv2).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name_Lv2).ToList();
                }

                return items;
            }

            public PaginatedList<CATCHWORD_LV2> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<CATCHWORD_LV2> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv2.Where(n => n.Name_Lv2.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv2.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<CATCHWORD_LV2> retItems = new PaginatedList<CATCHWORD_LV2>(items, pageIndex, pageSize);

                return retItems;
            }

            public CATCHWORD_LV2 GetCatchword_Lv2(int id)
            {
                CATCHWORD_LV2 item = _context.Catchword_Lv2.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv2.Where(n => n.Name_Lv2.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv2.Where(n => n.Name_Lv2.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class CatchwordLv3Repo : ICatchwordLv3
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public CatchwordLv3Repo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public CATCHWORD_LV3 Create(CATCHWORD_LV3 CATCHWORD_LV3)
            {
                _context.Catchword_Lv3.Add(CATCHWORD_LV3);
                _context.SaveChanges();
                return CATCHWORD_LV3;
            }

            public CATCHWORD_LV3 Delete(CATCHWORD_LV3 CATCHWORD_LV3)
            {
                _context.Catchword_Lv3.Attach(CATCHWORD_LV3);
                _context.Entry(CATCHWORD_LV3).State = EntityState.Deleted;
                _context.SaveChanges();
                return CATCHWORD_LV3;
            }

            public CATCHWORD_LV3 Edit(CATCHWORD_LV3 CATCHWORD_LV3)
            {
                _context.Catchword_Lv3.Attach(CATCHWORD_LV3);
                _context.Entry(CATCHWORD_LV3).State = EntityState.Modified;
                _context.SaveChanges();
                return CATCHWORD_LV3;
            }


            private List<CATCHWORD_LV3> DoSort(List<CATCHWORD_LV3> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name_Lv3).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name_Lv3).ToList();
                }

                return items;
            }

            public PaginatedList<CATCHWORD_LV3> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<CATCHWORD_LV3> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv3.Where(n => n.Name_Lv3.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv3.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<CATCHWORD_LV3> retItems = new PaginatedList<CATCHWORD_LV3>(items, pageIndex, pageSize);

                return retItems;
            }

            public CATCHWORD_LV3 GetCatchword_Lv3(int id)
            {
                CATCHWORD_LV3 item = _context.Catchword_Lv3.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv3.Where(n => n.Name_Lv3.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv3.Where(n => n.Name_Lv3.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class CatchwordLv4Repo : ICatchwordLv4
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public CatchwordLv4Repo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public CATCHWORD_LV4 Create(CATCHWORD_LV4 CATCHWORD_LV4)
            {
                _context.Catchword_Lv4.Add(CATCHWORD_LV4);
                _context.SaveChanges();
                return CATCHWORD_LV4;
            }

            public CATCHWORD_LV4 Delete(CATCHWORD_LV4 CATCHWORD_LV4)
            {
                _context.Catchword_Lv4.Attach(CATCHWORD_LV4);
                _context.Entry(CATCHWORD_LV4).State = EntityState.Deleted;
                _context.SaveChanges();
                return CATCHWORD_LV4;
            }

            public CATCHWORD_LV4 Edit(CATCHWORD_LV4 CATCHWORD_LV4)
            {
                _context.Catchword_Lv4.Attach(CATCHWORD_LV4);
                _context.Entry(CATCHWORD_LV4).State = EntityState.Modified;
                _context.SaveChanges();
                return CATCHWORD_LV4;
            }


            private List<CATCHWORD_LV4> DoSort(List<CATCHWORD_LV4> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name_Lv4).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name_Lv4).ToList();
                }

                return items;
            }

            public PaginatedList<CATCHWORD_LV4> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<CATCHWORD_LV4> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv4.Where(n => n.Name_Lv4.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv4.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<CATCHWORD_LV4> retItems = new PaginatedList<CATCHWORD_LV4>(items, pageIndex, pageSize);

                return retItems;
            }

            public CATCHWORD_LV4 GetCatchword_Lv4(int id)
            {
                CATCHWORD_LV4 item = _context.Catchword_Lv4.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv4.Where(n => n.Name_Lv4.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv4.Where(n => n.Name_Lv4.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class CourtTypeRepo : ICourtType
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public CourtTypeRepo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public COURT_TYPE Create(COURT_TYPE COURT_TYPE)
            {
                _context.Court_Types.Add(COURT_TYPE);
                _context.SaveChanges();
                return COURT_TYPE;
            }

            public COURT_TYPE Delete(COURT_TYPE COURT_TYPE)
            {
                _context.Court_Types.Attach(COURT_TYPE);
                _context.Entry(COURT_TYPE).State = EntityState.Deleted;
                _context.SaveChanges();
                return COURT_TYPE;
            }

            public COURT_TYPE Edit(COURT_TYPE COURT_TYPE)
            {
                _context.Court_Types.Attach(COURT_TYPE);
                _context.Entry(COURT_TYPE).State = EntityState.Modified;
                _context.SaveChanges();
                return COURT_TYPE;
            }


            private List<COURT_TYPE> DoSort(List<COURT_TYPE> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name).ToList();
                }

                return items;
            }

            public PaginatedList<COURT_TYPE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<COURT_TYPE> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Court_Types.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Court_Types.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<COURT_TYPE> retItems = new PaginatedList<COURT_TYPE>(items, pageIndex, pageSize);

                return retItems;
            }

            public COURT_TYPE GetCourt_Types(int id)
            {
                COURT_TYPE item = _context.Court_Types.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Court_Types.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Court_Types.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class JudgeNameRepo : IJudgeName
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public JudgeNameRepo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public JUDGE_NAME Create(JUDGE_NAME JUDGE_NAME)
            {
                _context.Judge_Names.Add(JUDGE_NAME);
                _context.SaveChanges();
                return JUDGE_NAME;
            }

            public JUDGE_NAME Delete(JUDGE_NAME JUDGE_NAME)
            {
                _context.Judge_Names.Attach(JUDGE_NAME);
                _context.Entry(JUDGE_NAME).State = EntityState.Deleted;
                _context.SaveChanges();
                return JUDGE_NAME;
            }

            public JUDGE_NAME Edit(JUDGE_NAME JUDGE_NAME)
            {
                _context.Judge_Names.Attach(JUDGE_NAME);
                _context.Entry(JUDGE_NAME).State = EntityState.Modified;
                _context.SaveChanges();
                return JUDGE_NAME;
            }


            private List<JUDGE_NAME> DoSort(List<JUDGE_NAME> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name).ToList();
                }

                return items;
            }

            public PaginatedList<JUDGE_NAME> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<JUDGE_NAME> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judge_Names.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judge_Names.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<JUDGE_NAME> retItems = new PaginatedList<JUDGE_NAME>(items, pageIndex, pageSize);

                return retItems;
            }

            public JUDGE_NAME GetJudge_Names(int id)
            {
                JUDGE_NAME item = _context.Judge_Names.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Judge_Names.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Judge_Names.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class JudgmentCountryRepo : IJudgmentCountry
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public JudgmentCountryRepo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public JUDGMENT_COUNTRY Create(JUDGMENT_COUNTRY JUDGMENT_COUNTRY)
            {
                _context.Judgment_Countries.Add(JUDGMENT_COUNTRY);
                _context.SaveChanges();
                return JUDGMENT_COUNTRY;
            }

            public JUDGMENT_COUNTRY Delete(JUDGMENT_COUNTRY JUDGMENT_COUNTRY)
            {
                _context.Judgment_Countries.Attach(JUDGMENT_COUNTRY);
                _context.Entry(JUDGMENT_COUNTRY).State = EntityState.Deleted;
                _context.SaveChanges();
                return JUDGMENT_COUNTRY;
            }

            public JUDGMENT_COUNTRY Edit(JUDGMENT_COUNTRY JUDGMENT_COUNTRY)
            {
                _context.Judgment_Countries.Attach(JUDGMENT_COUNTRY);
                _context.Entry(JUDGMENT_COUNTRY).State = EntityState.Modified;
                _context.SaveChanges();
                return JUDGMENT_COUNTRY;
            }


            private List<JUDGMENT_COUNTRY> DoSort(List<JUDGMENT_COUNTRY> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name).ToList();
                }

                return items;
            }

            public PaginatedList<JUDGMENT_COUNTRY> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<JUDGMENT_COUNTRY> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judgment_Countries.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judgment_Countries.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<JUDGMENT_COUNTRY> retItems = new PaginatedList<JUDGMENT_COUNTRY>(items, pageIndex, pageSize);

                return retItems;
            }

            public JUDGMENT_COUNTRY GetJudgment_Countries(int id)
            {
                JUDGMENT_COUNTRY item = _context.Judgment_Countries.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Judgment_Countries.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Judgment_Countries.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class StateRepo : IState
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public StateRepo (EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public STATE Create(STATE STATE)
            {
                _context.States.Add(STATE);
                _context.SaveChanges();
                return STATE;
            }

            public STATE Delete(STATE STATE)
            {
                _context.States.Attach(STATE);
                _context.Entry(STATE).State = EntityState.Deleted;
                _context.SaveChanges();
                return STATE;
            }

            public STATE Edit(STATE STATE)
            {
                _context.States.Attach(STATE);
                _context.Entry(STATE).State = EntityState.Modified;
                _context.SaveChanges();
                return STATE;
            }


            private List<STATE> DoSort(List<STATE> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name).ToList();
                }

                return items;
            }

            public PaginatedList<STATE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<STATE> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.States.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.States.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<STATE> retItems = new PaginatedList<STATE>(items, pageIndex, pageSize);

                return retItems;
            }

            public STATE GetStates(int id)
            {
                STATE item = _context.States.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.States.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.States.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class JudgmentLanguageRepo : IJudgmentLanguage
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public JudgmentLanguageRepo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public JUDGMENT_LANGUAGE Create(JUDGMENT_LANGUAGE JUDGMENT_LANGUAGE)
            {
                _context.Judgment_Languages.Add(JUDGMENT_LANGUAGE);
                _context.SaveChanges();
                return JUDGMENT_LANGUAGE;
            }

            public JUDGMENT_LANGUAGE Delete(JUDGMENT_LANGUAGE JUDGMENT_LANGUAGE)
            {
                _context.Judgment_Languages.Attach(JUDGMENT_LANGUAGE);
                _context.Entry(JUDGMENT_LANGUAGE).State = EntityState.Deleted;
                _context.SaveChanges();
                return JUDGMENT_LANGUAGE;
            }

            public JUDGMENT_LANGUAGE Edit(JUDGMENT_LANGUAGE JUDGMENT_LANGUAGE)
            {
                _context.Judgment_Languages.Attach(JUDGMENT_LANGUAGE);
                _context.Entry(JUDGMENT_LANGUAGE).State = EntityState.Modified;
                _context.SaveChanges();
                return JUDGMENT_LANGUAGE;
            }


            private List<JUDGMENT_LANGUAGE> DoSort(List<JUDGMENT_LANGUAGE> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "name")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.Name).ToList();
                    else
                        items = items.OrderByDescending(n => n.Name).ToList();
                }

                return items;
            }

            public PaginatedList<JUDGMENT_LANGUAGE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<JUDGMENT_LANGUAGE> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judgment_Languages.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judgment_Languages.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<JUDGMENT_LANGUAGE> retItems = new PaginatedList<JUDGMENT_LANGUAGE>(items, pageIndex, pageSize);

                return retItems;
            }

            public JUDGMENT_LANGUAGE GetJudgment_Language(int id)
            {
                JUDGMENT_LANGUAGE item = _context.Judgment_Languages.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Judgment_Languages.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Judgment_Languages.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }
        }
        public class LawReviewRepo : ILawReview
        {
            private readonly EDbContext _context; // for connecting to efcore.
            public LawReviewRepo(EDbContext context) // will be passed by dependency injection.
            {
                _context = context;
            }
            public LawReview Create(LawReview lawReview)
            {
                _context.LawReviews.Add(lawReview);
                _context.SaveChanges();
                return lawReview;
            }

            public LawReview Delete(LawReview lawReview)
            {
                _context.LawReviews.Attach(lawReview);
                _context.Entry(lawReview).State = EntityState.Deleted;
                _context.SaveChanges();
                return lawReview;
            }

            public LawReview Edit(LawReview lawReview)
            {
                _context.LawReviews.Attach(lawReview);
                _context.Entry(lawReview).State = EntityState.Modified;
                _context.SaveChanges();
                return lawReview;
            }


            private List<LawReview> DoSort(List<LawReview> items, string SortProperty, SortOrder sortOrder)
            {

                if (SortProperty.ToLower() == "LAWREVIEW_ID")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.LAWREVIEW_ID).ToList();
                    else
                        items = items.OrderByDescending(n => n.LAWREVIEW_ID).ToList();
                }
                else if (SortProperty == "JUDGMENT_NAME")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_NAME).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_NAME).ToList();
                }
                else if (SortProperty == "JUDGMENT_NAME_VERSUS")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_NAME_VERSUS).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_NAME_VERSUS).ToList();
                }
                else if (SortProperty == "JUDGMENT_NAME_ADDITIONAL")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_NAME_ADDITIONAL).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_NAME_ADDITIONAL).ToList();
                }
                else if (SortProperty == "COURT_TYPE")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.COURT_TYPE).ToList();
                    else
                        items = items.OrderByDescending(n => n.COURT_TYPE).ToList();
                }
                else if (SortProperty == "JUDGE_NAME")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGE_NAME).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGE_NAME).ToList();
                }
                else if (SortProperty == "JUDGMENT_NAME")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_NAME).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_NAME).ToList();
                }
                else if (SortProperty == "JUDGMENT_NUMBER")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_NUMBER).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_NUMBER).ToList();
                }
                else if (SortProperty == "JUDGMENT_DATE")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_DATE).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_DATE).ToList();
                }
                else if (SortProperty == "JUDGMENT_COUNTRY")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_COUNTRY).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_COUNTRY).ToList();
                }
                else if (SortProperty == "STATE")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.STATE).ToList();
                    else
                        items = items.OrderByDescending(n => n.STATE).ToList();
                }
                else if (SortProperty == "JUDGMENT_LANGUAGE")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_LANGUAGE).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_LANGUAGE).ToList();
                }
                else if (SortProperty == "CATCHWORD_LV1")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV1).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV1).ToList();
                }
                else if (SortProperty == "CATCHWORD_LV2")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV2).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV2).ToList();
                }
                else if (SortProperty == "CATCHWORD_LV3")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV3).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV3).ToList();
                }
                else if (SortProperty == "CATCHWORD_LV4")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV4).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV4).ToList();
                }


                return items;
            }

            public PaginatedList<LawReview> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<LawReview> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.LawReviews.Where(n => n.LAWREVIEW_ID.ToString().Contains(SearchText) || n.JUDGMENT_NAME.Contains(SearchText) || n.JUDGMENT_NAME_VERSUS.Contains(SearchText) || n.JUDGMENT_NAME_ADDITIONAL.Contains(SearchText) || n.Court_Types.Name.Contains(SearchText) || n.Judge_Names.Name.Contains(SearchText) || n.JUDGMENT_NUMBER.Contains(SearchText) || n.JUDGMENT_DATE.Contains(SearchText) || n.HEADNOTE.Contains(SearchText) || n.Judgment_Countries.Name.Contains(SearchText) || n.States.Name.Contains(SearchText) || n.Judgment_Languages.Name.Contains(SearchText) || n.Catchword_Lv1.Name_Lv1.Contains(SearchText) || n.Catchword_Lv2.Name_Lv2.Contains(SearchText) || n.Catchword_Lv3.Name_Lv3.Contains(SearchText) || n.Catchword_Lv4.Name_Lv4.Contains(SearchText) || n.VERDICT.Contains(SearchText))
                        .Include(u => u.Court_Types)
                        .ToList();
                }
                else
                    items = _context.LawReviews
                        .Include(u => u.Court_Types).Include(r => r.Judge_Names).Include(s => s.Judgment_Countries).Include(t => t.Judgment_Languages).Include(v => v.Catchword_Lv1).Include(w => w.Catchword_Lv2).Include(x => x.Catchword_Lv3).Include(y => y.Catchword_Lv4).Include(z => z.States)
                        .ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<LawReview> retItems = new PaginatedList<LawReview>(items, pageIndex, pageSize);

                return retItems;
            }

            public LawReview GetItem(int LAWREVIEW_ID)
            {
                LawReview item = _context.LawReviews.Where(u => u.LAWREVIEW_ID == LAWREVIEW_ID).Where(r => r.LAWREVIEW_ID == LAWREVIEW_ID).Where(s => s.LAWREVIEW_ID == LAWREVIEW_ID).Where(t => t.LAWREVIEW_ID == LAWREVIEW_ID).Where(v => v.LAWREVIEW_ID == LAWREVIEW_ID).Where(w => w.LAWREVIEW_ID == LAWREVIEW_ID).Where(x => x.LAWREVIEW_ID == LAWREVIEW_ID).Where(y => y.LAWREVIEW_ID == LAWREVIEW_ID)
                    .Include(u => u.Court_Types).Include(r => r.Judge_Names).Include(s => s.Judgment_Countries).Include(t => t.Judgment_Languages).Include(v => v.Catchword_Lv1).Include(w => w.Catchword_Lv2).Include(x => x.Catchword_Lv3).Include(y => y.Catchword_Lv4)
                    .FirstOrDefault();
                return item;
            }
            public bool IsItemExists(int LAWREVIEW_ID)
            {
                int ct = _context.LawReviews.Where(n => n.LAWREVIEW_ID.ToString().ToLower() == LAWREVIEW_ID.ToString().ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

        }

    }
}
