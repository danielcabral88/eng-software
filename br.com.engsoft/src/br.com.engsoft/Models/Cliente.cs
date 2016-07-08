using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace br.com.engsoft.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Fretes = new List<Frete>();
        }

        [Key]
        public int codigo_cliente { get; set; }
    [MaxLength(30)]
        public string nome { get; set; }
    [MaxLength(30)]
        public string endereco { get; set; }
    [MaxLength(30)]
        public string telefone { get; set; }

        public virtual ICollection<Frete> Fretes { get; set; }

        
    }
}
