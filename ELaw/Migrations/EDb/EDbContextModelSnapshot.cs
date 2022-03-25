﻿// <auto-generated />
using System;
using ELaw.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ELaw.Migrations.EDb
{
    [DbContext(typeof(EDbContext))]
    partial class EDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ELaw.Models.CATCHWORD_LV1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name_Lv1")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catchword_Lv1");
                });

            modelBuilder.Entity("ELaw.Models.CATCHWORD_LV2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Catch1_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name_Lv2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catchword_Lv2");
                });

            modelBuilder.Entity("ELaw.Models.CATCHWORD_LV3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Catch2_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name_Lv3")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Catchword_Lv3");
                });

            modelBuilder.Entity("ELaw.Models.CATCHWORD_LV4", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Catch3_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name_Lv4")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catchword_Lv4");
                });

            modelBuilder.Entity("ELaw.Models.COURT_TYPE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Court_Types");
                });

            modelBuilder.Entity("ELaw.Models.JUDGE_NAME", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Judge_Names");
                });

            modelBuilder.Entity("ELaw.Models.JUDGMENT_COUNTRY", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Judgment_Countries");
                });

            modelBuilder.Entity("ELaw.Models.JUDGMENT_LANGUAGE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Judgment_Languages");
                });

            modelBuilder.Entity("ELaw.Models.LawReview", b =>
                {
                    b.Property<int>("LAWREVIEW_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CATCHWORD_LV1")
                        .HasColumnType("int");

                    b.Property<int?>("CATCHWORD_LV2")
                        .HasColumnType("int");

                    b.Property<int?>("CATCHWORD_LV3")
                        .HasColumnType("int");

                    b.Property<int?>("CATCHWORD_LV4")
                        .HasColumnType("int");

                    b.Property<int?>("COURT_TYPE")
                        .HasColumnType("int");

                    b.Property<int?>("Catchword_Lv1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Catchword_Lv2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Catchword_Lv3Id")
                        .HasColumnType("int");

                    b.Property<int?>("Catchword_Lv4Id")
                        .HasColumnType("int");

                    b.Property<int?>("Court_TypesId")
                        .HasColumnType("int");

                    b.Property<string>("HEADNOTE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JUDGE_NAME")
                        .HasColumnType("int");

                    b.Property<int?>("JUDGMENT_COUNTRY")
                        .HasColumnType("int");

                    b.Property<string>("JUDGMENT_DATE")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("JUDGMENT_LANGUAGE")
                        .HasColumnType("int");

                    b.Property<string>("JUDGMENT_NAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("JUDGMENT_NAME_ADDITIONAL")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("JUDGMENT_NAME_VERSUS")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("JUDGMENT_NUMBER")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Judge_NamesId")
                        .HasColumnType("int");

                    b.Property<int?>("Judgment_CountriesId")
                        .HasColumnType("int");

                    b.Property<int?>("Judgment_LanguagesId")
                        .HasColumnType("int");

                    b.Property<int?>("STATE")
                        .HasColumnType("int");

                    b.Property<int?>("StatesId")
                        .HasColumnType("int");

                    b.Property<string>("VERDICT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LAWREVIEW_ID");

                    b.HasIndex("Catchword_Lv1Id");

                    b.HasIndex("Catchword_Lv2Id");

                    b.HasIndex("Catchword_Lv3Id");

                    b.HasIndex("Catchword_Lv4Id");

                    b.HasIndex("Court_TypesId");

                    b.HasIndex("Judge_NamesId");

                    b.HasIndex("Judgment_CountriesId");

                    b.HasIndex("Judgment_LanguagesId");

                    b.HasIndex("StatesId");

                    b.ToTable("LawReviews");
                });

            modelBuilder.Entity("ELaw.Models.ReferredCase", b =>
                {
                    b.Property<int>("REFERRED_CASES_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LAWREVIEW_ID")
                        .HasColumnType("int");

                    b.Property<string>("REFERRED_CASES")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("REFERRED_CASES_ID");

                    b.HasIndex("LAWREVIEW_ID");

                    b.ToTable("ReferredCases");
                });

            modelBuilder.Entity("ELaw.Models.ReferredLegislation", b =>
                {
                    b.Property<int>("REFERRED_LEGISLATION_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LAWREVIEW_ID")
                        .HasColumnType("int");

                    b.Property<string>("REFERRED_LEGISLATIONS")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("REFERRED_LEGISLATION_ID");

                    b.HasIndex("LAWREVIEW_ID");

                    b.ToTable("ReferredLegislations");
                });

            modelBuilder.Entity("ELaw.Models.STATE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Judgment_Country_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("ELaw.Models.LawReview", b =>
                {
                    b.HasOne("ELaw.Models.CATCHWORD_LV1", "Catchword_Lv1")
                        .WithMany()
                        .HasForeignKey("Catchword_Lv1Id");

                    b.HasOne("ELaw.Models.CATCHWORD_LV2", "Catchword_Lv2")
                        .WithMany()
                        .HasForeignKey("Catchword_Lv2Id");

                    b.HasOne("ELaw.Models.CATCHWORD_LV3", "Catchword_Lv3")
                        .WithMany()
                        .HasForeignKey("Catchword_Lv3Id");

                    b.HasOne("ELaw.Models.CATCHWORD_LV4", "Catchword_Lv4")
                        .WithMany()
                        .HasForeignKey("Catchword_Lv4Id");

                    b.HasOne("ELaw.Models.COURT_TYPE", "Court_Types")
                        .WithMany()
                        .HasForeignKey("Court_TypesId");

                    b.HasOne("ELaw.Models.JUDGE_NAME", "Judge_Names")
                        .WithMany()
                        .HasForeignKey("Judge_NamesId");

                    b.HasOne("ELaw.Models.JUDGMENT_COUNTRY", "Judgment_Countries")
                        .WithMany()
                        .HasForeignKey("Judgment_CountriesId");

                    b.HasOne("ELaw.Models.JUDGMENT_LANGUAGE", "Judgment_Languages")
                        .WithMany()
                        .HasForeignKey("Judgment_LanguagesId");

                    b.HasOne("ELaw.Models.STATE", "States")
                        .WithMany()
                        .HasForeignKey("StatesId");

                    b.Navigation("Catchword_Lv1");

                    b.Navigation("Catchword_Lv2");

                    b.Navigation("Catchword_Lv3");

                    b.Navigation("Catchword_Lv4");

                    b.Navigation("Court_Types");

                    b.Navigation("Judge_Names");

                    b.Navigation("Judgment_Countries");

                    b.Navigation("Judgment_Languages");

                    b.Navigation("States");
                });

            modelBuilder.Entity("ELaw.Models.ReferredCase", b =>
                {
                    b.HasOne("ELaw.Models.LawReview", "LawReview")
                        .WithMany("ReferredCases")
                        .HasForeignKey("LAWREVIEW_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LawReview");
                });

            modelBuilder.Entity("ELaw.Models.ReferredLegislation", b =>
                {
                    b.HasOne("ELaw.Models.LawReview", "LawReview")
                        .WithMany("ReferredLegislations")
                        .HasForeignKey("LAWREVIEW_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LawReview");
                });

            modelBuilder.Entity("ELaw.Models.LawReview", b =>
                {
                    b.Navigation("ReferredCases");

                    b.Navigation("ReferredLegislations");
                });
#pragma warning restore 612, 618
        }
    }
}