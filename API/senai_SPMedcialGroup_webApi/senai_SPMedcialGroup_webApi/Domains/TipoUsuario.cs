using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPMedcialGroup_webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipo { get; set; }
        public string NomeTipoUser { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
