using System;
using System.Collections.Generic;

namespace WebAppTrabalho.Models
{
    public partial class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int IdTurma { get; set; }

        public Turma IdTurmaNavigation { get; set; }
    }
}
