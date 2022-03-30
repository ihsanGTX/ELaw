
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
            public Catchword_Lv1 Create(Catchword_Lv1 Catchword_Lv1)
            {
                _context.Catchword_Lv1s.Add(Catchword_Lv1);
                _context.SaveChanges();
                return Catchword_Lv1;
            }

            public Catchword_Lv1 Delete(Catchword_Lv1 Catchword_Lv1)
            {
                _context.Catchword_Lv1s.Attach(Catchword_Lv1);
                _context.Entry(Catchword_Lv1).State = EntityState.Deleted;
                _context.SaveChanges();
                return Catchword_Lv1;
            }

            public Catchword_Lv1 Edit(Catchword_Lv1 Catchword_Lv1)
            {
                _context.Catchword_Lv1s.Attach(Catchword_Lv1);
                _context.Entry(Catchword_Lv1).State = EntityState.Modified;
                _context.SaveChanges();
                return Catchword_Lv1;
            }


            private List<Catchword_Lv1> DoSort(List<Catchword_Lv1> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Catchword_Lv1> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Catchword_Lv1> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv1s.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv1s.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Catchword_Lv1> retItems = new PaginatedList<Catchword_Lv1>(items, pageIndex, pageSize);

                return retItems;
            }

            public Catchword_Lv1 GetCatchword_Lv1(int id)
            {
                Catchword_Lv1 item = _context.Catchword_Lv1s.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv1s.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv1s.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
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
            public Catchword_Lv2 Create(Catchword_Lv2 Catchword_Lv2)
            {
                _context.Catchword_Lv2s.Add(Catchword_Lv2);
                _context.SaveChanges();
                return Catchword_Lv2;
            }

            public Catchword_Lv2 Delete(Catchword_Lv2 Catchword_Lv2)
            {
                _context.Catchword_Lv2s.Attach(Catchword_Lv2);
                _context.Entry(Catchword_Lv2).State = EntityState.Deleted;
                _context.SaveChanges();
                return Catchword_Lv2;
            }

            public Catchword_Lv2 Edit(Catchword_Lv2 Catchword_Lv2)
            {
                _context.Catchword_Lv2s.Attach(Catchword_Lv2);
                _context.Entry(Catchword_Lv2).State = EntityState.Modified;
                _context.SaveChanges();
                return Catchword_Lv2;
            }


            private List<Catchword_Lv2> DoSort(List<Catchword_Lv2> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Catchword_Lv2> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Catchword_Lv2> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv2s.Where(n => n.Name.Contains(SearchText))
                        .Include(u => u.Catchword_Lv1s)
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv2s.Include(u => u.Catchword_Lv1s).ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Catchword_Lv2> retItems = new PaginatedList<Catchword_Lv2>(items, pageIndex, pageSize);

                return retItems;
            }

            public Catchword_Lv2 GetCatchword_Lv2(int id)
            {
                Catchword_Lv2 item = _context.Catchword_Lv2s.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv2s.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv2s.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
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
            public Catchword_Lv3 Create(Catchword_Lv3 Catchword_Lv3)
            {
                _context.Catchword_Lv3s.Add(Catchword_Lv3);
                _context.SaveChanges();
                return Catchword_Lv3;
            }

            public Catchword_Lv3 Delete(Catchword_Lv3 Catchword_Lv3)
            {
                _context.Catchword_Lv3s.Attach(Catchword_Lv3);
                _context.Entry(Catchword_Lv3).State = EntityState.Deleted;
                _context.SaveChanges();
                return Catchword_Lv3;
            }

            public Catchword_Lv3 Edit(Catchword_Lv3 Catchword_Lv3)
            {
                _context.Catchword_Lv3s.Attach(Catchword_Lv3);
                _context.Entry(Catchword_Lv3).State = EntityState.Modified;
                _context.SaveChanges();
                return Catchword_Lv3;
            }


            private List<Catchword_Lv3> DoSort(List<Catchword_Lv3> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Catchword_Lv3> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Catchword_Lv3> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv3s.Where(n => n.Name.Contains(SearchText))
                        .Include(u => u.Catchword_Lv2s)
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv3s.Include(u => u.Catchword_Lv2s).ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Catchword_Lv3> retItems = new PaginatedList<Catchword_Lv3>(items, pageIndex, pageSize);

                return retItems;
            }

            public Catchword_Lv3 GetCatchword_Lv3(int id)
            {
                Catchword_Lv3 item = _context.Catchword_Lv3s.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv3s.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv3s.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
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
            public Catchword_Lv4 Create(Catchword_Lv4 Catchword_Lv4)
            {
                _context.Catchword_Lv4s.Add(Catchword_Lv4);
                _context.SaveChanges();
                return Catchword_Lv4;
            }

            public Catchword_Lv4 Delete(Catchword_Lv4 Catchword_Lv4)
            {
                _context.Catchword_Lv4s.Attach(Catchword_Lv4);
                _context.Entry(Catchword_Lv4).State = EntityState.Deleted;
                _context.SaveChanges();
                return Catchword_Lv4;
            }

            public Catchword_Lv4 Edit(Catchword_Lv4 Catchword_Lv4)
            {
                _context.Catchword_Lv4s.Attach(Catchword_Lv4);
                _context.Entry(Catchword_Lv4).State = EntityState.Modified;
                _context.SaveChanges();
                return Catchword_Lv4;
            }


            private List<Catchword_Lv4> DoSort(List<Catchword_Lv4> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Catchword_Lv4> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Catchword_Lv4> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Catchword_Lv4s.Where(n => n.Name.Contains(SearchText))
                        .Include(u => u.Catchword_Lv3s)
                        .ToList();
                }
                else
                    items = _context.Catchword_Lv4s.Include(u => u.Catchword_Lv3s).ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Catchword_Lv4> retItems = new PaginatedList<Catchword_Lv4>(items, pageIndex, pageSize);

                return retItems;
            }

            public Catchword_Lv4 GetCatchword_Lv4(int id)
            {
                Catchword_Lv4 item = _context.Catchword_Lv4s.Where(u => u.Id == id).FirstOrDefault();
                return item;
            }
            public bool IsItemExists(string name)
            {
                int ct = _context.Catchword_Lv4s.Where(n => n.Name.ToLower() == name.ToLower()).Count();
                if (ct > 0)
                    return true;
                else
                    return false;
            }

            public bool IsItemExists(string name, int Id)
            {
                int ct = _context.Catchword_Lv4s.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != Id).Count();
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
            public Court_Type Create(Court_Type Court_Type)
            {
                _context.Court_Types.Add(Court_Type);
                _context.SaveChanges();
                return Court_Type;
            }

            public Court_Type Delete(Court_Type Court_Type)
            {
                _context.Court_Types.Attach(Court_Type);
                _context.Entry(Court_Type).State = EntityState.Deleted;
                _context.SaveChanges();
                return Court_Type;
            }

            public Court_Type Edit(Court_Type Court_Type)
            {
                _context.Court_Types.Attach(Court_Type);
                _context.Entry(Court_Type).State = EntityState.Modified;
                _context.SaveChanges();
                return Court_Type;
            }


            private List<Court_Type> DoSort(List<Court_Type> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Court_Type> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Court_Type> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Court_Types.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Court_Types.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Court_Type> retItems = new PaginatedList<Court_Type>(items, pageIndex, pageSize);

                return retItems;
            }

            public Court_Type GetCourt_Types(int id)
            {
                Court_Type item = _context.Court_Types.Where(u => u.Id == id).FirstOrDefault();
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
            public Judge_Name Create(Judge_Name Judge_Name)
            {
                _context.Judge_Names.Add(Judge_Name);
                _context.SaveChanges();
                return Judge_Name;
            }

            public Judge_Name Delete(Judge_Name Judge_Name)
            {
                _context.Judge_Names.Attach(Judge_Name);
                _context.Entry(Judge_Name).State = EntityState.Deleted;
                _context.SaveChanges();
                return Judge_Name;
            }

            public Judge_Name Edit(Judge_Name Judge_Name)
            {
                _context.Judge_Names.Attach(Judge_Name);
                _context.Entry(Judge_Name).State = EntityState.Modified;
                _context.SaveChanges();
                return Judge_Name;
            }


            private List<Judge_Name> DoSort(List<Judge_Name> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Judge_Name> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Judge_Name> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judge_Names.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judge_Names.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Judge_Name> retItems = new PaginatedList<Judge_Name>(items, pageIndex, pageSize);

                return retItems;
            }

            public Judge_Name GetJudge_Names(int id)
            {
                Judge_Name item = _context.Judge_Names.Where(u => u.Id == id).FirstOrDefault();
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
            public Judgment_Country Create(Judgment_Country Judgment_Country)
            {
                _context.Judgment_Countries.Add(Judgment_Country);
                _context.SaveChanges();
                return Judgment_Country;
            }

            public Judgment_Country Delete(Judgment_Country Judgment_Country)
            {
                _context.Judgment_Countries.Attach(Judgment_Country);
                _context.Entry(Judgment_Country).State = EntityState.Deleted;
                _context.SaveChanges();
                return Judgment_Country;
            }

            public Judgment_Country Edit(Judgment_Country Judgment_Country)
            {
                _context.Judgment_Countries.Attach(Judgment_Country);
                _context.Entry(Judgment_Country).State = EntityState.Modified;
                _context.SaveChanges();
                return Judgment_Country;
            }


            private List<Judgment_Country> DoSort(List<Judgment_Country> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Judgment_Country> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Judgment_Country> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judgment_Countries.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judgment_Countries.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Judgment_Country> retItems = new PaginatedList<Judgment_Country>(items, pageIndex, pageSize);

                return retItems;
            }

            public Judgment_Country GetJudgment_Countries(int id)
            {
                Judgment_Country item = _context.Judgment_Countries.Where(u => u.Id == id).FirstOrDefault();
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
            public State Create(State State)
            {
                _context.States.Add(State);
                _context.SaveChanges();
                return State;
            }

            public State Delete(State State)
            {
                _context.States.Attach(State);
                _context.Entry(State).State = EntityState.Deleted;
                _context.SaveChanges();
                return State;
            }

            public State Edit(State State)
            {
                _context.States.Attach(State);
                _context.Entry(State).State = EntityState.Modified;
                _context.SaveChanges();
                return State;
            }


            private List<State> DoSort(List<State> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<State> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<State> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.States.Where(n => n.Name.Contains(SearchText))
                        .Include(u=>u.Judgment_Countries)
                        .ToList();
                }
                else
                    items = _context.States.Include(u => u.Judgment_Countries).ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<State> retItems = new PaginatedList<State>(items, pageIndex, pageSize);

                return retItems;
            }

            public State GetStates(int id)
            {
                State item = _context.States.Where(u => u.Id == id).FirstOrDefault();
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
            public Judgment_Language Create(Judgment_Language Judgment_Language)
            {
                _context.Judgment_Languages.Add(Judgment_Language);
                _context.SaveChanges();
                return Judgment_Language;
            }

            public Judgment_Language Delete(Judgment_Language Judgment_Language)
            {
                _context.Judgment_Languages.Attach(Judgment_Language);
                _context.Entry(Judgment_Language).State = EntityState.Deleted;
                _context.SaveChanges();
                return Judgment_Language;
            }

            public Judgment_Language Edit(Judgment_Language Judgment_Language)
            {
                _context.Judgment_Languages.Attach(Judgment_Language);
                _context.Entry(Judgment_Language).State = EntityState.Modified;
                _context.SaveChanges();
                return Judgment_Language;
            }


            private List<Judgment_Language> DoSort(List<Judgment_Language> items, string SortProperty, SortOrder sortOrder)
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

            public PaginatedList<Judgment_Language> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
            {
                List<Judgment_Language> items;

                if (SearchText != "" && SearchText != null)
                {
                    items = _context.Judgment_Languages.Where(n => n.Name.Contains(SearchText))
                        .ToList();
                }
                else
                    items = _context.Judgment_Languages.ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<Judgment_Language> retItems = new PaginatedList<Judgment_Language>(items, pageIndex, pageSize);

                return retItems;
            }

            public Judgment_Language GetJudgment_Language(int id)
            {
                Judgment_Language item = _context.Judgment_Languages.Where(u => u.Id == id).FirstOrDefault();
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
                else if (SortProperty == "Court_Type")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.COURT_TYPE).ToList();
                    else
                        items = items.OrderByDescending(n => n.COURT_TYPE).ToList();
                }
                else if (SortProperty == "Judge_Name")
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
                else if (SortProperty == "Judgment_Country")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_COUNTRY).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_COUNTRY).ToList();
                }
                else if (SortProperty == "State")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.STATE).ToList();
                    else
                        items = items.OrderByDescending(n => n.STATE).ToList();
                }
                else if (SortProperty == "Judgment_Language")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.JUDGMENT_LANGUAGE).ToList();
                    else
                        items = items.OrderByDescending(n => n.JUDGMENT_LANGUAGE).ToList();
                }
                else if (SortProperty == "Catchword_Lv1")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV1).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV1).ToList();
                }
                else if (SortProperty == "Catchword_Lv2")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV2).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV2).ToList();
                }
                else if (SortProperty == "Catchword_Lv3")
                {
                    if (sortOrder == SortOrder.Ascending)
                        items = items.OrderBy(n => n.CATCHWORD_LV3).ToList();
                    else
                        items = items.OrderByDescending(n => n.CATCHWORD_LV3).ToList();
                }
                else if (SortProperty == "Catchword_Lv4")
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
                    items = _context.LawReviews.Where(n => n.LAWREVIEW_ID.ToString().Contains(SearchText) || n.JUDGMENT_NAME.Contains(SearchText) || n.JUDGMENT_NAME_VERSUS.Contains(SearchText) || n.JUDGMENT_NAME_ADDITIONAL.Contains(SearchText) || n.Court_Types.Name.Contains(SearchText) || n.Judge_Names.Name.Contains(SearchText) || n.JUDGMENT_NUMBER.Contains(SearchText) || n.JUDGMENT_DATE.Contains(SearchText) || n.HEADNOTE.Contains(SearchText) || n.Judgment_Countries.Name.Contains(SearchText) || n.States.Name.Contains(SearchText) || n.Judgment_Languages.Name.Contains(SearchText) || n.Catchword_Lv1s.Name.Contains(SearchText) || n.Catchword_Lv2s.Name.Contains(SearchText) || n.Catchword_Lv3s.Name.Contains(SearchText) || n.Catchword_Lv4s.Name.Contains(SearchText) || n.VERDICT.Contains(SearchText))
                        .Include(u => u.Court_Types).Include(r => r.Judge_Names).Include(s => s.Judgment_Countries).Include(c => c.States).Include(t => t.Judgment_Languages).Include(v => v.Catchword_Lv1s).Include(w => w.Catchword_Lv2s).Include(x => x.Catchword_Lv3s).Include(y => y.Catchword_Lv4s)
                        .ToList();
                }
                else
                    items = _context.LawReviews
                        .Include(u => u.Court_Types).Include(r => r.Judge_Names).Include(s => s.Judgment_Countries).Include(c => c.States).Include(t => t.Judgment_Languages).Include(v => v.Catchword_Lv1s).Include(w => w.Catchword_Lv2s).Include(x => x.Catchword_Lv3s).Include(y => y.Catchword_Lv4s)
                        .ToList();

                items = DoSort(items, SortProperty, sortOrder);

                PaginatedList<LawReview> retItems = new PaginatedList<LawReview>(items, pageIndex, pageSize);

                return retItems;
            }

            public LawReview GetItem(int LAWREVIEW_ID)
            {
                LawReview item = _context.LawReviews.Where(u => u.LAWREVIEW_ID == LAWREVIEW_ID).FirstOrDefault();
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
