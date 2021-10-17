﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPMedcialGroup_webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecialidade { get; set; }
        public string Tema { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
