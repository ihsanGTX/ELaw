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
        public virtual DbSet<CATCHWORD_LV1> Catchword_Lv1 { get; set; }
        public virtual DbSet<CATCHWORD_LV2> Catchword_Lv2 { get; set; }
        public virtual DbSet<CATCHWORD_LV3> Catchword_Lv3 { get; set; }
        public virtual DbSet<CATCHWORD_LV4> Catchword_Lv4 { get; set; }
        public virtual DbSet<COURT_TYPE> Court_Types { get; set; }
        public virtual DbSet<JUDGE_NAME> Judge_Names { get; set; }
        public virtual DbSet<JUDGMENT_COUNTRY> Judgment_Countries { get; set; }
        public virtual DbSet<JUDGMENT_LANGUAGE> Judgment_Languages { get; set; }
        public virtual DbSet<STATE> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ELawDbContextConnection"]);//connection string get by appsetting.json
        }
    }
}
