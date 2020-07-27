using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocaApi.Models
{
    public class VocaContext : DbContext
    {
        public VocaContext()
        { 
        }
        public VocaContext(DbContextOptions<VocaContext> options)
           : base(options)
        {
        }

        public DbSet<Voca> Voca { get; set; }

       


    }


}
