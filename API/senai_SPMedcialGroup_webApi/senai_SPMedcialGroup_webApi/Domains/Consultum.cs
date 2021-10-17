﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SPMedcialGroup_webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public byte? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSaida { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
