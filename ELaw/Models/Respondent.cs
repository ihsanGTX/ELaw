//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ELaw.Models
//{
//    public class Respondent
//    {
//        [Key]
//        public int RESPONDENT_ID { get; set; }

//        [ForeignKey("LawReview")]
//        public int LAWREVIEW_ID { get; set; }
//        public virtual LawReview LawReview { get; set; }

//        [StringLength(150)]
//        public string RESPONDENTS { get; set; }

//        [NotMapped]
//        public bool IsDeleted { get; set; } = false;
//    }
//}
