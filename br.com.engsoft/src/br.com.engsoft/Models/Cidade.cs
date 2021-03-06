﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace br.com.engsoft.Models
{
    public class Cidade // Teste de integração contínua - 19/07/2016
    {
        public Cidade()
        {
            Fretes = new List<Frete>();
        }

        [Key]
        public int codigo_cidade { get; set; }
    [MaxLength(30)]
        public string nome { get; set; }
    [MaxLength(30)]
        public string UF { get; set; }
        public float taxa { get; set; }

        public virtual ICollection<Frete> Fretes { get; set; }

        
    }

}
