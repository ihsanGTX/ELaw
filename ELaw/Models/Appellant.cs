//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ELaw.Models
//{
//    public class Appellant
//    {
//        [Key]
//        public int APPELLANT_ID { get; set; }

//        [ForeignKey("LawReview")]
//        public int LAWREVIEW_ID { get; set; }
//        public virtual LawReview LawReview { get; set; }

//        [StringLength(150)]
//        public string APPELLANTS { get; set; }

//        [NotMapped]
//        public bool IsDeleted { get; set; } = false;
//    }
//}
