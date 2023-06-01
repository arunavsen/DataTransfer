using DataTransfer.Data.SenderData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models.Sender
{
    public class SenderDBContext : DbContext
    {
        public DbSet<Brief> Brief { get; set; }
        public DbSet<BriefCountryMap> BriefCountryMap { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TaxBriefContent> TaxBriefContent { get; set; }
        public DbSet<TpaBriefContent> TpaBriefContent { get; set; }
        public DbSet<WtaBriefContent> WtaBriefContent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.131;Database=RegBriefDB;User Id=sa; Password=$haonatkpl2013;TrustServerCertificate=True");
            }
        }
    }
}
