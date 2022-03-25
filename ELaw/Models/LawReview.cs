

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

        [ForeignKey("COURT_TYPE")]
        [Display(Name = "COURT_TYPE")]
        public int? COURT_TYPE { get; set; }
        public virtual COURT_TYPE Court_Types { get; set; }

        [ForeignKey("JUDGE_NAME")]
        [Display(Name = "JUDGE_NAME")]
        public int? JUDGE_NAME { get; set; }
        public virtual JUDGE_NAME Judge_Names { get; set; }

        [ForeignKey("JUDGMENT_COUNTRY")]
        [Display(Name = "JUDGMENT_COUNTRY")]
        public int? JUDGMENT_COUNTRY { get; set; }
        public virtual JUDGMENT_COUNTRY Judgment_Countries { get; set; }

        [ForeignKey("STATE")]
        [Display(Name = "STATE")]
        public int? STATE { get; set; }
        public virtual STATE States { get; set; }


        [ForeignKey("JUDGMENT_LANGUAGE")]
        [Display(Name = "JUDGMENT_LANGUAGE")]
        public int? JUDGMENT_LANGUAGE { get; set; }
        public virtual JUDGMENT_LANGUAGE Judgment_Languages { get; set; }

        [ForeignKey("CATCHWORD_LV1")]
        [Display(Name = "CATCHWORD_LV1")]
        public int? CATCHWORD_LV1 { get; set; }
        public virtual CATCHWORD_LV1 Catchword_Lv1 { get; set; }

        [ForeignKey("CATCHWORD_LV2")]
        [Display(Name = "CATCHWORD_LV2")]
        public int? CATCHWORD_LV2 { get; set; }
        public virtual CATCHWORD_LV2 Catchword_Lv2 { get; set; }

        [ForeignKey("CATCHWORD_LV3")]
        [Display(Name = "CATCHWORD_LV3")]
        public int? CATCHWORD_LV3 { get; set; }
        public virtual CATCHWORD_LV3 Catchword_Lv3 { get; set; }

        [ForeignKey("CATCHWORD_LV4")]
        [Display(Name = "CATCHWORD_LV4")]
        public int? CATCHWORD_LV4 { get; set; }
        public virtual CATCHWORD_LV4 Catchword_Lv4 { get; set; }

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
