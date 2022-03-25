//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ELaw.Models
//{
//    public class Defendent
//    {
//        [Key]
//        public int DEFENDENT_ID { get; set; }

//        [ForeignKey("LawReview")]
//        public int LAWREVIEW_ID { get; set; }
//        public virtual LawReview LawReview { get; set; }

//        [StringLength(150)]
//        public string DEFENDENTS { get; set; }

//        [NotMapped]
//        public bool IsDeleted { get; set; } = false;
//    }
//}
