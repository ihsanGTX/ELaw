using ELaw.Models;
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
            PaginatedList<Catchword_Lv1> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Catchword_Lv1 GetCatchword_Lv1(int id); // read particular item

            Catchword_Lv1 Create(Catchword_Lv1 Catchword_Lv1);

            Catchword_Lv1 Edit(Catchword_Lv1 Catchword_Lv1);

            Catchword_Lv1 Delete(Catchword_Lv1 Catchword_Lv1);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv2
        {
            PaginatedList<Catchword_Lv2> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Catchword_Lv2 GetCatchword_Lv2(int id); // read particular item

            Catchword_Lv2 Create(Catchword_Lv2 Catchword_Lv2);

            Catchword_Lv2 Edit(Catchword_Lv2 Catchword_Lv2);

            Catchword_Lv2 Delete(Catchword_Lv2 Catchword_Lv2);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv3
        {
            PaginatedList<Catchword_Lv3> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Catchword_Lv3 GetCatchword_Lv3(int id); // read particular item

            Catchword_Lv3 Create(Catchword_Lv3 Catchword_Lv3);

            Catchword_Lv3 Edit(Catchword_Lv3 Catchword_Lv3);

            Catchword_Lv3 Delete(Catchword_Lv3 Catchword_Lv3);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICatchwordLv4
        {
            PaginatedList<Catchword_Lv4> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Catchword_Lv4 GetCatchword_Lv4(int id); // read particular item

            Catchword_Lv4 Create(Catchword_Lv4 Catchword_Lv4);

            Catchword_Lv4 Edit(Catchword_Lv4 Catchword_Lv4);

            Catchword_Lv4 Delete(Catchword_Lv4 Catchword_Lv4);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface ICourtType
        {
            PaginatedList<Court_Type> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Court_Type GetCourt_Types(int id); // read particular item

            Court_Type Create(Court_Type Court_Type);

            Court_Type Edit(Court_Type Court_Type);

            Court_Type Delete(Court_Type Court_Type);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgeName
        {
            PaginatedList<Judge_Name> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Judge_Name GetJudge_Names(int id); // read particular item

            Judge_Name Create(Judge_Name Judge_Name);

            Judge_Name Edit(Judge_Name Judge_Name);

            Judge_Name Delete(Judge_Name Judge_Name);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgmentCountry
        {
            PaginatedList<Judgment_Country> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Judgment_Country GetJudgment_Countries(int id); // read particular item

            Judgment_Country Create(Judgment_Country Judgment_Country);

            Judgment_Country Edit(Judgment_Country Judgment_Country);

            Judgment_Country Delete(Judgment_Country Judgment_Country);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IJudgmentLanguage
        {
            PaginatedList<Judgment_Language> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            Judgment_Language GetJudgment_Language(int id); // read particular item

            Judgment_Language Create(Judgment_Language Judgment_Language);

            Judgment_Language Edit(Judgment_Language Judgment_Language);

            Judgment_Language Delete(Judgment_Language Judgment_Language);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int Id);


        }
        public interface IState
        {
            PaginatedList<State> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
            State GetStates(int id); // read particular item

            State Create(State State);

            State Edit(State State);

            State Delete(State State);

            public bool IsItemExists(string name);
            public bool IsItemExists(string name, int id);


        }
    }
}
