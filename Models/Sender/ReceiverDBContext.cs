using DataTransfer.Models.Receiver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Models.Sender
{
    public class ReceiverDBContext : DbContext
    {
        public DbSet<Briefing> Briefings { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<WtaStory> WtaStories { get; set; }
        public DbSet<TpaStory> TpaStories { get; set; }
        public DbSet<TaxStory> TaxStories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.131;User Id=sa; Password=$haonatkpl2013; Database=NestDB2021;");
            }
        }
    }
}
