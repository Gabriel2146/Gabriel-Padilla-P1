using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gabriel_Padilla_P1.Models;

namespace Gabriel_Padilla_P1.Data
{
    public class Gabriel_Padilla_P1Context : DbContext
    {
        public Gabriel_Padilla_P1Context (DbContextOptions<Gabriel_Padilla_P1Context> options)
            : base(options)
        {
        }

        public DbSet<Gabriel_Padilla_P1.Models.PRodriguez> PRodriguez { get; set; } = default!;
    }
}
