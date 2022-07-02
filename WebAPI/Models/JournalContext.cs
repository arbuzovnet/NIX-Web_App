using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        {        }

        public DbSet<Journal> Journals { get; set; } = null;
    }
}
