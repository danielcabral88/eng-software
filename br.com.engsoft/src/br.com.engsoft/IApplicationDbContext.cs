using br.com.engsoft.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.engsoft.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Cidade> Cidade { get; set; }
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Frete> Frete { get; set; }

        void ChangeObjectState(object model, EntityState state);
    }
}