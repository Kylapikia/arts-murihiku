﻿// <auto-generated />
using AM1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AM1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181005142139_99new")]
    partial class _99new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AM1.Models.Album", b =>
                {
                    b.Property<string>("AlbumID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AlbumCreatedTime");

                    b.Property<string>("AlbumDescription");

                    b.Property<string>("AlbumOwner");

                    b.Property<string>("AlbumTitle");

                    b.HasKey("AlbumID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AM1.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("AccountCreated");

                    b.Property<string>("Address");

                    b.Property<bool>("Artist");

                    b.Property<string>("ArtistDescription");

                    b.Property<double>("CartID");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("CreativeSpace");

                    b.Property<bool>("Design");

                    b.Property<string>("DeviantArt");

                    b.Property<bool>("Education");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FacebookLink");

                    b.Property<bool>("Festival");

                    b.Property<bool>("Film");

                    b.Property<bool>("FirstTimeSetup");

                    b.Property<string>("FullAddress");

                    b.Property<bool>("Individual");

                    b.Property<string>("InstagramLink");

                    b.Property<bool>("IsAddressVisable");

                    b.Property<bool>("IsEmailVisable");

                    b.Property<bool>("IsPhoneVisable");

                    b.Property<bool>("Literacy");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<bool>("MixedMedia");

                    b.Property<bool>("MultiCultural");

                    b.Property<bool>("Music");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<bool>("Organisation");

                    b.Property<bool>("Paint");

                    b.Property<bool>("Pasifika");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<bool>("Photography");

                    b.Property<string>("PostCode");

                    b.Property<string>("ProfilePic");

                    b.Property<bool>("PublicArt");

                    b.Property<bool>("Sculpture");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Suburb");

                    b.Property<bool>("Textiles");

                    b.Property<bool>("Theatre");

                    b.Property<bool>("ToiMaori");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("WebsiteLink");

                    b.Property<string>("YoutubeLink");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AM1.Models.Artist", b =>
                {
                    b.Property<int>("ArtistID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistDescription");

                    b.Property<string>("ArtistName");

                    b.HasKey("ArtistID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("AM1.Models.ArtsDir", b =>
                {
                    b.Property<int>("ArtsDirID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtName");

                    b.Property<string>("Description");

                    b.Property<bool>("Design");

                    b.Property<bool>("Education");

                    b.Property<bool>("Film");

                    b.Property<bool>("Literacy");

                    b.Property<bool>("MixedMedia");

                    b.Property<bool>("MultiCultural");

                    b.Property<bool>("Music");

                    b.Property<bool>("Paint");

                    b.Property<bool>("Pasifika");

                    b.Property<bool>("Photography");

                    b.Property<string>("Picture1");

                    b.Property<string>("Picture2");

                    b.Property<string>("Picture3");

                    b.Property<string>("Picture4");

                    b.Property<string>("Picture5");

                    b.Property<string>("ProfileLink");

                    b.Property<bool>("PublicArt");

                    b.Property<bool>("Sculpture");

                    b.Property<bool>("Textiles");

                    b.Property<bool>("Theatre");

                    b.HasKey("ArtsDirID");

                    b.ToTable("ArtsDir");
                });

            modelBuilder.Entity("AM1.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("BlogPic");

                    b.Property<string>("BlogPost");

                    b.Property<string>("Category");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("BlogID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("AM1.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistID");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductName");

                    b.Property<double>("ProductPrice");

                    b.Property<int>("Quantity");

                    b.HasKey("CartID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("AM1.Models.Contact", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Subject");

                    b.Property<DateTime>("SubmitDate");

                    b.HasKey("BlogID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AM1.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("EventCategory");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("EventPicture");

                    b.Property<DateTime>("FinishEventDate");

                    b.Property<string>("FinishTime");

                    b.Property<bool>("Free");

                    b.Property<string>("FullAddress");

                    b.Property<bool>("FullDay");

                    b.Property<string>("Location");

                    b.Property<string>("PostCode");

                    b.Property<int?>("Price");

                    b.Property<DateTime>("StartEventDate");

                    b.Property<string>("StartTime");

                    b.Property<string>("Suburb");

                    b.Property<string>("ThemeColour");

                    b.HasKey("EventID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("AM1.Models.GMapModel", b =>
                {
                    b.Property<int>("GMapID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FridayClose");

                    b.Property<string>("FridayOpen");

                    b.Property<string>("GAddress");

                    b.Property<string>("GDisciplines");

                    b.Property<string>("GLinkProfile");

                    b.Property<string>("GName");

                    b.Property<string>("GProfilePic");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<string>("MondayClose");

                    b.Property<string>("MondayOpen");

                    b.Property<string>("SaturdayClose");

                    b.Property<string>("SaturdayOpen");

                    b.Property<string>("SundayClose");

                    b.Property<string>("SundayOpen");

                    b.Property<string>("ThursdayClose");

                    b.Property<string>("ThursdayOpen");

                    b.Property<string>("TuesdayClose");

                    b.Property<string>("TuesdayOpen");

                    b.Property<string>("WednesdayClose");

                    b.Property<string>("WednesdayOpen");

                    b.HasKey("GMapID");

                    b.ToTable("GMapModel");
                });

            modelBuilder.Entity("AM1.Models.MyArtist", b =>
                {
                    b.Property<int>("MyArtistID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ArtistDescription");

                    b.Property<string>("City");

                    b.Property<bool>("CreativeSpace");

                    b.Property<bool>("Design");

                    b.Property<string>("DeviantArt");

                    b.Property<bool>("Education");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookLink");

                    b.Property<bool>("Festival");

                    b.Property<bool>("Film");

                    b.Property<bool>("Individual");

                    b.Property<string>("InstagramLink");

                    b.Property<bool>("Literacy");

                    b.Property<bool>("MixedMedia");

                    b.Property<bool>("MultiCultural");

                    b.Property<bool>("Music");

                    b.Property<bool>("Organisation");

                    b.Property<bool>("Paint");

                    b.Property<bool>("Pasifika");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("Photography");

                    b.Property<string>("ProfilePic");

                    b.Property<bool>("PublicArt");

                    b.Property<bool>("Sculpture");

                    b.Property<bool>("Textiles");

                    b.Property<bool>("Theatre");

                    b.Property<bool>("ToiMaori");

                    b.Property<string>("UserID");

                    b.Property<string>("WebsiteLink");

                    b.Property<string>("YoutubeLink");

                    b.HasKey("MyArtistID");

                    b.ToTable("MyArtist");
                });

            modelBuilder.Entity("AM1.Models.Photos", b =>
                {
                    b.Property<string>("PhotoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileFullPath");

                    b.Property<string>("FileName");

                    b.Property<string>("PhotoAlbumID");

                    b.Property<string>("PhotoOwner");

                    b.HasKey("PhotoID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("AM1.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.Property<string>("ProductPicture");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AM1.Models.VolForm", b =>
                {
                    b.Property<int>("VolFormID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AppDevelopment");

                    b.Property<bool>("AssistanceExhibitionsGen");

                    b.Property<bool>("AssistanceExhibitionsGen1");

                    b.Property<bool>("AssistanceVisitors");

                    b.Property<bool>("AssistanceVisitors1");

                    b.Property<bool>("AssistanceWorkshops");

                    b.Property<bool>("AssistanceWorkshops1");

                    b.Property<bool>("Catering");

                    b.Property<string>("ContactMethod")
                        .IsRequired();

                    b.Property<bool>("Costuming");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("Facebook");

                    b.Property<bool>("FirstAidCertificate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("FrontOfHouse");

                    b.Property<bool>("Hair");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Instagram");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("Lighting");

                    b.Property<bool>("MakeUp");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("PoliceVetCheck");

                    b.Property<string>("PreviousExperience")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("Prompt");

                    b.Property<bool>("Props");

                    b.Property<bool>("PublicityAndPromotion");

                    b.Property<bool>("PublicityAndPromotion1");

                    b.Property<bool>("PublicityAndPromotion2");

                    b.Property<bool>("SetBuilding");

                    b.Property<bool>("SnapChat");

                    b.Property<bool>("Sound");

                    b.Property<bool>("StageManagement");

                    b.Property<bool>("SupportOpenings");

                    b.Property<bool>("SupportOpenings1");

                    b.Property<bool>("TermsAndConditions");

                    b.Property<bool>("Twitter");

                    b.Property<bool>("WebsiteDevelopment");

                    b.HasKey("VolFormID");

                    b.ToTable("VolForm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AM1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AM1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AM1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AM1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
