using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELaw.Models
{

    public class Judgment_Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Judgment_Countries")]
        public int Judgment_Country_Id { get; set; }
        public virtual Judgment_Country Judgment_Countries { get; set; }
    }
    public class Catchword_Lv1
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Catchword_Lv2
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Catchword_Lv1s")]
        public int Catch1_Id { get; set; }
        public virtual Catchword_Lv1 Catchword_Lv1s { get; set; }
    }
    public class Catchword_Lv3
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Catchword_Lv2s")]

        public int Catch2_Id { get; set; }
        public virtual Catchword_Lv2 Catchword_Lv2s { get; set; }
    }
    public class Catchword_Lv4
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Catchword_Lv3s")]
        public int Catch3_Id { get; set; }
        public virtual Catchword_Lv3 Catchword_Lv3s { get; set; }
    }
    public class Judgment_Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Court_Type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Judge_Name
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
