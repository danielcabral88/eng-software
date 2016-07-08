using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace br.com.engsoft.Models
{
    public class Frete
    {
    [Key]
        public int codigo_frete { get; set; }
    [MaxLength(30)]
        public string descricao { get; set; }
        public float peso { get; set; }
        public float valor { get; set; }

        public Cliente cliente { get; set; }
        public Cidade cidade { get; set; }

        //public IEnumerable<SelectListItem> ListaClientes { get; set; }
        //public IEnumerable<SelectListItem> ListaCidades { get; set; }
    }

}
