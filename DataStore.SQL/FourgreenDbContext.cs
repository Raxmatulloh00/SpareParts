using Info.BotUsers;
using Info.CarSpare;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.SQL
{
    public class FourgreenDbContext : IdentityDbContext<IdentityUser>
    {
        public FourgreenDbContext(DbContextOptions options) : base(options)
        {

        }
   
        public DbSet<SparePartBrands> SparePartBrands { get; set; }
        public DbSet<SparePartBrandsImage> SparePartBrandsImages { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<SparePartsInfo> SparePartsInfos { get; set; }
        public DbSet<SparePartsInfoImage> SparePartsInfoImages { get; set; }

        public DbSet<BotUser> BotUsers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BotUser>().HasIndex(u => u.TelegramChatId).IsUnique();
            base.OnModelCreating(modelBuilder);

        }
        
    }
    
}
