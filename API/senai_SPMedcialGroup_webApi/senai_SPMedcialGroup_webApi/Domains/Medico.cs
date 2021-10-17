using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPMedcialGroup_webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }
        public short? IdInstituicao { get; set; }
        public int? Idusuario { get; set; }
        public byte? IdEspecialidade { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
