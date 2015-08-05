using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ShenMen.Dominio
{
    public class Profissional
    {
        public int ID_PROFISSIONAL { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 50 caracteres!")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatorio.")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "O campo telefone deve ter no máximo 12 caracteres!")]
        public string TELEFONE { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo email deve ter entre 5 e 50 caracteres!")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatorio.")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O campo email deve ter entre 4 e 10 caracteres!")]
        public string SENHA { get; set; }

    }
}
