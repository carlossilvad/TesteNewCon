using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNewCon1.Model
{
        [Table("PontosTuristicos")]
        public class PontoTuristico
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "O nome é obrigatório")]
            [StringLength(80)]
            public string Nome { get; set; }

            [Required(ErrorMessage = "A descrição é obrigatória")]
            [StringLength(500)]
            public string Descricao { get; set; }

            [Required(ErrorMessage = "A localização é obrigatória")]
            [StringLength(100)]
            public string Localizacao { get; set; }

            [Required(ErrorMessage = "A cidade é obrigatória")]
            [StringLength(50)]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "O estado é obrigatório")]
            [StringLength(50)]
            public string Estado { get; set; }

            public DateTime DataCadastro { get; set; }
        }
}
