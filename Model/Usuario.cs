using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TESTE_API_ASPNETCORE.Model
{
    [Table("Usuario")]
    public class Usuario
    {
       [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("setor")]
        public string Setor { get; set; }
    }
}
