using ELaw.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ELaw.Data
{
    public class EDbContext : DbContext
    {
        private IConfigurationRoot _config;
        public EDbContext(IConfigurationRoot config, DbContextOptions<EDbContext> options) : base(options)
        {
            _config = config;
        }

        public virtual DbSet<LawReview> LawReviews { get; set; }

        //Foreign table
        public virtual DbSet<ReferredCase> ReferredCases { get; set; }
        public virtual DbSet<ReferredLegislation> ReferredLegislations { get; set; }
        //public virtual DbSet<Appellant> Appellants { get; set; }
        //public virtual DbSet<Applicant> Applicants { get; set; }
        //public virtual DbSet<Claimant> Claimants { get; set; }
        //public virtual DbSet<Company> Companies { get; set; }
        //public virtual DbSet<Defendent> Defendents { get; set; }
        //public virtual DbSet<Liquidator> Liquidators { get; set; }
        //public virtual DbSet<Plaintiff> Plaintiffs { get; set; }
        //public virtual DbSet<Respondent> Respondents { get; set; }
        //public virtual DbSet<ThirdParty> ThirdParties { get; set; }

        //Cascade table
        public virtual DbSet<Catchword_Lv1> Catchword_Lv1s { get; set; }
        public virtual DbSet<Catchword_Lv2> Catchword_Lv2s { get; set; }
        public virtual DbSet<Catchword_Lv3> Catchword_Lv3s { get; set; }
        public virtual DbSet<Catchword_Lv4> Catchword_Lv4s { get; set; }
        public virtual DbSet<Court_Type> Court_Types { get; set; }
        public virtual DbSet<Judge_Name> Judge_Names { get; set; }
        public virtual DbSet<Judgment_Country> Judgment_Countries { get; set; }
        public virtual DbSet<Judgment_Language> Judgment_Languages { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ELawDbContextConnection"]);//connection string get by appsetting.json
        }
    }
}
