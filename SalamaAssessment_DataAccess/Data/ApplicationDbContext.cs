using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalamaAssessment_Models.Models;

namespace SalamaAssessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QuoteInfo> QuoteInfo { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }
    }
}