using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ShenMen.Dominio
{
    public class Cliente
    {
        public int ID_CLIENTE { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 50 caracteres!")]
        public string NOME { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo endereco deve ter entre 5 e 100 caracteres!")]
        public string ENDERECO { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatorio.")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "O campo telefone deve ter no máximo 12 caracteres!")]
        public string TELEFONE { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo email deve ter entre 5 e 50 caracteres!")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatorio.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DTNASC { get; set; }
    }
}
