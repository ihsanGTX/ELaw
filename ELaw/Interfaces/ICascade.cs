﻿using ELaw.Models;
using ELaw.Tools;

namespace ELaw.Interfaces
{
    public class ICascade
    {
        public interface ILawReview
        {
            PaginatedList<LawReview> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            LawReview GetItem(int LAWREVIEW_ID); // read particular item

            LawReview Create(LawReview lawReview);

            LawReview Edit(LawReview lawReview);

            LawReview Delete(LawReview lawReview);
            public bool IsItemExists(int LAWREVIEW_ID);


        }
        public interface ICatchwordLv1
        {
            PaginatedList<CATCHWORD_LV1> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            CATCHWORD_LV1 GetCatchword_Lv1(int id); // read particular item

            CATCHWORD_LV1 Create(CATCHWORD_LV1 catchword_lv1);

            CATCHWORD_LV1 Edit(CATCHWORD_LV1 catchword_lv1);

            CATCHWORD_LV1 Delete(CATCHWORD_LV1 catchword_lv1);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv2
        {
            PaginatedList<CATCHWORD_LV2> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            CATCHWORD_LV2 GetCatchword_Lv2(int id); // read particular item

            CATCHWORD_LV2 Create(CATCHWORD_LV2 catchword_lv2);

            CATCHWORD_LV2 Edit(CATCHWORD_LV2 catchword_lv2);

            CATCHWORD_LV2 Delete(CATCHWORD_LV2 catchword_lv2);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv3
        {
            PaginatedList<CATCHWORD_LV3> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            CATCHWORD_LV3 GetCatchword_Lv3(int id); // read particular item

            CATCHWORD_LV3 Create(CATCHWORD_LV3 catchword_lv3);

            CATCHWORD_LV3 Edit(CATCHWORD_LV3 catchword_lv3);

            CATCHWORD_LV3 Delete(CATCHWORD_LV3 catchword_lv3);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv4
        {
            PaginatedList<CATCHWORD_LV4> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            CATCHWORD_LV4 GetCatchword_Lv4(int id); // read particular item

            CATCHWORD_LV4 Create(CATCHWORD_LV4 catchword_lv4);

            CATCHWORD_LV4 Edit(CATCHWORD_LV4 catchword_lv4);

            CATCHWORD_LV4 Delete(CATCHWORD_LV4 catchword_lv4);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICourtType
        {
            PaginatedList<COURT_TYPE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            COURT_TYPE GetCourt_Types(int id); // read particular item

            COURT_TYPE Create(COURT_TYPE court_type);

            COURT_TYPE Edit(COURT_TYPE court_type);

            COURT_TYPE Delete(COURT_TYPE court_type);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgeName
        {
            PaginatedList<JUDGE_NAME> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            JUDGE_NAME GetJudge_Names(int id); // read particular item

            JUDGE_NAME Create(JUDGE_NAME judge_name);

            JUDGE_NAME Edit(JUDGE_NAME judge_name);

            JUDGE_NAME Delete(JUDGE_NAME judge_name);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgmentCountry
        {
            PaginatedList<JUDGMENT_COUNTRY> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            JUDGMENT_COUNTRY GetJudgment_Countries(int id); // read particular item

            JUDGMENT_COUNTRY Create(JUDGMENT_COUNTRY judgement_country);

            JUDGMENT_COUNTRY Edit(JUDGMENT_COUNTRY judgement_country);

            JUDGMENT_COUNTRY Delete(JUDGMENT_COUNTRY judgement_country);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgmentLanguage
        {
            PaginatedList<JUDGMENT_LANGUAGE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            JUDGMENT_LANGUAGE GetJudgment_Language(int id); // read particular item

            JUDGMENT_LANGUAGE Create(JUDGMENT_LANGUAGE judgement_language);

            JUDGMENT_LANGUAGE Edit(JUDGMENT_LANGUAGE judgement_language);

            JUDGMENT_LANGUAGE Delete(JUDGMENT_LANGUAGE judgement_language);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IState
        {
            PaginatedList<STATE> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            STATE GetStates(int id); // read particular item

            STATE Create(STATE state);

            STATE Edit(STATE state);

            STATE Delete(STATE state);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int id);


        }
    }
}
