using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPMedcialGroup_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? Idusuario { get; set; }
        public string NomePaci { get; set; }
        public string Email { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Telcontato { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
