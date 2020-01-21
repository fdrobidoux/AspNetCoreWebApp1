using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class WebAppDbContext : DbContext
    {
        protected DbSet<Household> Households { get; set; }

        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Household>().ToTable("Household")
                .Property(x => x.Id)
                .HasConversion(new GuidToStringConverter());
            builder.Entity<Household>(); // TODO
        }

        public IList<Household> GetHouseholds(int pageIndex = 1, int resultsPerPage = 20)
        {
            IQueryable<Household> query = (from h in Households select h)
                .Skip(resultsPerPage * (pageIndex - 1))
                .Take(resultsPerPage);
                
            if (query.Count() == 0)
            {
                throw new IndexOutOfRangeException("Aucun résultats trouvés.");
            }

            return query.ToList();
        }
    }
}