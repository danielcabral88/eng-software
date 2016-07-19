using br.com.engsoft.Data.Repository;
using br.com.engsoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.engsoft.Data.Repository
{
    public class TesteRepository : Repository<Cidade>
    {
        public TesteRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
