using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AquarelleBot;

namespace AquarelleBot.Migrations
{
    [DbContext(typeof(AquarelleModelPostgreSqlContext))]
    [Migration("20160909150258_Aquarelle1")]
    partial class Aquarelle1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("AquarelleBot.API.Personal.Model.PhoneModel+RootobjectPhoneItems", b =>
                {
                    b.Property<long>("RootobjectPhoneItemsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birthday");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Organization");

                    b.Property<int?>("PhoneHandheld");

                    b.Property<string>("PhoneMobile");

                    b.Property<string>("PhoneStationary");

                    b.Property<string>("Service");

                    b.Property<string>("email");

                    b.HasKey("RootobjectPhoneItemsId");

                    b.ToTable("RootobjectPhoneItems");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.menu.StateModel", b =>
                {
                    b.Property<long>("StateModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChatId");

                    b.Property<string>("TextButon");

                    b.HasKey("StateModelId");

                    b.ToTable("StateModel");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<long>("TypeCompanyId");

                    b.HasKey("CompanyId");

                    b.HasIndex("TypeCompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Avatar");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Description");

                    b.Property<string>("FirsName");

                    b.Property<string>("LastName");

                    b.Property<long>("PositionId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("PersonId");

                    b.HasIndex("PositionId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.Position", b =>
                {
                    b.Property<long>("PositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("PositionId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.TypeCompany", b =>
                {
                    b.Property<long>("TypeCompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TypeCompanyId");

                    b.ToTable("TypeCompany");
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.Company", b =>
                {
                    b.HasOne("AquarelleBot.API.Telegram.Model.TypeCompany", "TypeCompany")
                        .WithMany()
                        .HasForeignKey("TypeCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AquarelleBot.API.Telegram.Model.Person", b =>
                {
                    b.HasOne("AquarelleBot.API.Telegram.Model.Position", "Position")
                        .WithMany("Person")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
