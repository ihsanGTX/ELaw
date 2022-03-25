using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELaw.Models
{
    public class ReferredLegislation
    {
        [Key]
        public int REFERRED_LEGISLATION_ID { get; set; }

        [ForeignKey("LawReview")]
        public int LAWREVIEW_ID { get; set; }
        public virtual LawReview LawReview { get; private set; }

        [StringLength(150)]
        public string REFERRED_LEGISLATIONS { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
