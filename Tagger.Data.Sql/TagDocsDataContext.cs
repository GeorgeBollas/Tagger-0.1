using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tagger.Entities;

namespace Tagger.Data.Sql
{
    public class TaggerDataContext : DbContext, ITaggerDataContext
    {

        //private string _databaseName;


        ////required for data migrations
        //public TaggerDataContext()
        //{
        //    //todo fix this
        //    _databaseName = "TagDocs.db"; //todo move to config
        //}

        ////todo why is thid called when using Caliburn???
        //public TaggerDataContext(string databaseName)
        //{
        //    _databaseName = databaseName;
        //}


        //todo hide this from the repositories somehow

        #region DbSets

        internal DbSet<Tag> Tags { get; set; }

        internal DbSet<TagType> TagTypes { get; set; }

        #endregion DbSets


        #region Repositories

        public ITagsRepository TagsRepository => new TagsRepository(this);

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // does not work with Trusted Connection?
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Tagger;User Id=George;Password=Chloe001!;");
        }

        public override int  SaveChanges()
        {
            return base.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
