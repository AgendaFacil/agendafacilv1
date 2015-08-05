using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ShenMen.Dominio
{
    public class Consulta
    {

        public int ID_CONSULTA { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DATA_CONSULTA { get; set; }

        public string HORARIO_CONSULTA { get; set; }

        public Profissional PROFISSIONAL { get; set; }

        public Tratamento TRATAMENTO { get; set; }

        public Cliente CLIENTE { get; set; }

    }
}
