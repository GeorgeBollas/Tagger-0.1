﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tagger.Data.Sql;
using Tagger.Entities;

namespace Tagger.Data.Sql.Migrations
{
    [DbContext(typeof(TaggerDataContext))]
    [Migration("20180525104143_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tagger.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("EntityState");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("Modified");

                    b.Property<long?>("TagTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TagTypeId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Tagger.Entities.TagType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int>("EntityState");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TagTypes");
                });

            modelBuilder.Entity("Tagger.Entities.Tag", b =>
                {
                    b.HasOne("Tagger.Entities.TagType")
                        .WithMany("Tags")
                        .HasForeignKey("TagTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
