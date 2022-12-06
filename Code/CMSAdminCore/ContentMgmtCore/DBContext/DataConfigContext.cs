using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ContentMgmtCore.Model;
using Entities; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace ContentMgmtCore.DBContext
{
    public class DataConfigContext : DbContext  
    {
        public DataConfigContext(DbContextOptions<DataConfigContext> options) : base(options)
        {
        }
        public static readonly LoggerFactory LoggerFactory =
            new LoggerFactory(new[] { new DebugLoggerProvider() }); 

        public DbSet<LoginUser> tb_loginuser { get; set; }  
        public DbSet<DBBakInfo> tb_dbbackinfo { get; set; } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

           // modelBuilder.Entity<DBBakInfo>().Ignore(x => x.UploadFileAbsolutePath_01);

            modelBuilder.Entity<DBBakInfo>(entity =>
            {
                entity.HasKey(e => e.RecId);
            })  ;  
            
            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.HasKey(e => e.recid);
            });  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }
    }
}
