

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELaw.Models
{
    [Serializable]
    public class LawReview
    {
        [Key]
        public int LAWREVIEW_ID { get; set; }

        [Required, StringLength(150)]
        public string JUDGMENT_NAME { get; set; }

        [Required, StringLength(150)]
        public string JUDGMENT_NAME_VERSUS { get; set; }

        [Required, StringLength(150)]
        public string JUDGMENT_NAME_ADDITIONAL { get; set; }

        [Required, StringLength(150)]
        public string JUDGMENT_NUMBER { get; set; }

        [Required, StringLength(150)]
        public string JUDGMENT_DATE { get; set; }

        public string HEADNOTE { get; set; }

        public string VERDICT { get; set; }

        //Cascade|Dropdown

        [ForeignKey("Court_Types")]
        public int? COURT_TYPE { get; set; }
        public virtual Court_Type Court_Types { get; set; }

        [ForeignKey("Judge_Names")]
        public int? JUDGE_NAME { get; set; }
        public virtual Judge_Name Judge_Names { get; set; }

        [ForeignKey("Judgment_Countries")]
        public int? JUDGMENT_COUNTRY { get; set; }
        public virtual Judgment_Country Judgment_Countries { get; set; }

        [ForeignKey("States")]
        public int? STATE { get; set; }
        public virtual State States { get; set; }


        [ForeignKey("Judgment_Languages")]
        public int? JUDGMENT_LANGUAGE { get; set; }
        public virtual Judgment_Language Judgment_Languages { get; set; }

        [ForeignKey("Catchword_Lv1s")]
        public int? CATCHWORD_LV1 { get; set; }
        public virtual Catchword_Lv1 Catchword_Lv1s { get; set; }

        [ForeignKey("Catchword_Lv2s")]
        public int? CATCHWORD_LV2 { get; set; }
        public virtual Catchword_Lv2 Catchword_Lv2s { get; set; }

        [ForeignKey("Catchword_Lv3s")]
        public int? CATCHWORD_LV3 { get; set; }
        public virtual Catchword_Lv3 Catchword_Lv3s { get; set; }

        [ForeignKey("Catchword_Lv4s")]
        public int? CATCHWORD_LV4 { get; set; }
        public virtual Catchword_Lv4 Catchword_Lv4s { get; set; }

        //Foreign Table
        public virtual List<ReferredCase> ReferredCases { get; set; } = new List<ReferredCase>();
        public virtual List<ReferredLegislation> ReferredLegislations { get; set; } = new List<ReferredLegislation>();
        //public virtual List<Appellant> Appellants { get; set; } = new List<Appellant>();
        //public virtual List<Applicant> Applicants { get; set; } = new List<Applicant>();
        //public virtual List<Claimant> Claimants { get; set; } = new List<Claimant>();
        //public virtual List<Company> Companies { get; set; } = new List<Company>();
        //public virtual List<Defendent> Defendents { get; set; } = new List<Defendent>();
        //public virtual List<Liquidator> Liquidators { get; set; } = new List<Liquidator>();
        //public virtual List<Plaintiff> Plaintiffs { get; set; } = new List<Plaintiff>();
        //public virtual List<Respondent> Respondents { get; set; } = new List<Respondent>();
        //public virtual List<ThirdParty> ThirdParties { get; set; } = new List<ThirdParty>();

    }
}
