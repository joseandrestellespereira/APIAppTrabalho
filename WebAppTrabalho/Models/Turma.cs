using System;
using System.Collections.Generic;

namespace WebAppTrabalho.Models
{
	public partial class Turma
	{
		public Turma()
		{
			Aluno = new HashSet<Aluno>();
		}

		public int Id { get; set; }
		public string Curso { get; set; }
		public string Turno { get; set; }

		public ICollection<Aluno> Aluno { get; set; }
	}
}
