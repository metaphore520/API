using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DbContextFile
{
    public class InvoiceDBContext : DbContext
    {
        IConfiguration _configuration;
        public InvoiceDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                #warning To protect potentially sensitive information in your connection string, you should move 
                #it out of source code.
                See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseSqlServer("Server=DESKTOP-R1A1J4P\\SQLEXPRESS;Database=ProductDB;Trust Server Certificate=true;Trusted_Connection=True;");

            }
        }


    }
}
