using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELaw.Models
{

    public class JUDGMENT_COUNTRY
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class STATE
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Judgment_Country_Id { get; set; }
    }
    public class CATCHWORD_LV1
    {
        [Key]
        public int Id { get; set; }
        public string Name_Lv1 { get; set; }

    }
    public class CATCHWORD_LV2
    {
        [Key]
        public int Id { get; set; }
        public string Name_Lv2 { get; set; }

        public int Catch1_Id { get; set; }
    }
    public class CATCHWORD_LV3
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name_Lv3 { get; set; }

        public int Catch2_Id { get; set; }
    }
    public class CATCHWORD_LV4
    {
        [Key]
        public int Id { get; set; }
        public string Name_Lv4 { get; set; }
        public int Catch3_Id { get; set; }
    }
    public class JUDGMENT_LANGUAGE
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class COURT_TYPE
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class JUDGE_NAME
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
