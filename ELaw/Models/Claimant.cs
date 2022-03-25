//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ELaw.Models
//{
//    public class Claimant
//    {
//        [Key]
//        public int CLAIMANT_ID { get; set; }

//        [ForeignKey("LawReview")]
//        public int LAWREVIEW_ID { get; set; }
//        public virtual LawReview LawReview { get; set; }

//        [StringLength(150)]
//        public string CLAIMANTS { get; set; }

//        [NotMapped]
//        public bool IsDeleted { get; set; } = false;
//    }
//}
