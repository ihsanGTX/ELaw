using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELaw.Models
{
    public class ReferredCase
    {
        [Key]
        public int REFERRED_CASES_ID { get; set; }

        [ForeignKey("LawReview")]
        public int LAWREVIEW_ID { get; set; }
        public virtual LawReview LawReview { get; private set; }

        [StringLength(150)]
        public string REFERRED_CASES { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
