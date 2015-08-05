using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShenMen.Dominio
{
    public class Tratamento
    {
        public int ID_TRATAMENTO { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatorio.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo descrição deve ter no máximo 200 caracteres!")]
        [DisplayName("DESCRIÇÃO")]
        public string DESCRICAO { get; set; }

    }
}
