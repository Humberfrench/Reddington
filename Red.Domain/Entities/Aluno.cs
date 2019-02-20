using Red.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Red.Domain.Entities
{
    public class Aluno : IEntidade
    {
        public Aluno()
        {
            atividadesPreferidas = new List<AtividadePreferida>();
            caracteristicas = new List<Caracteristica>();
            problemasSaude = new List<ProblemaSaude>();
            responsaveis = new List<Responsavel>();
            turmas = new List<Turma>();
            status= new Status();
        }

        private int codigo;
        private Status status;
        private Responsavel responsavel;
        private string nome;
        private string sexo;
        private DateTime dataNascimento;
        private bool grupoDeJovens;
        private bool matriculado;
        private string observacao;

        private IList<AtividadePreferida> atividadesPreferidas;
        private IList<Caracteristica> caracteristicas;
        private IList<ProblemaSaude> problemasSaude;
        private IList<Responsavel> responsaveis;
        private IList<Turma> turmas;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public virtual Responsavel Responsavel
        {
            get
            {
                return responsavel;
            }
            set
            {
                responsavel = value;
            }
        }

         public virtual Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public virtual string Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        public virtual DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
            }
        }

        public virtual bool GrupoDeJovens
        {
            get
            {
                return grupoDeJovens;
            }
            set
            {
                grupoDeJovens = value;
            }
        }

        public virtual bool Matriculado
        {
            get
            {
                return matriculado;
            }
            set
            {
                matriculado = value;
            }
        }

        public virtual string Observacao
        {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
            }
        }

        public virtual IList<AtividadePreferida> AtividadesPreferidas
        {
            get
            {
                return atividadesPreferidas;
            }
            set
            {
                atividadesPreferidas = value;
            }
        }

        public virtual IList<Caracteristica> Caracteristicas
        {
            get
            {
                return caracteristicas;
            }
            set
            {
                caracteristicas = value;
            }
        }

        public virtual IList<ProblemaSaude> ProblemasSaude
        {
            get
            {
                return problemasSaude;
            }
            set
            {
                problemasSaude = value;
            }
        }

        public virtual IList<Turma> Turmas
        {
            get
            {
                return turmas;
            }
            set
            {
                turmas = value;
            }
        }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new AlunoIsValidValidation();
        //        ValidationResult = fiscal.Validate(this);
        //        return ValidationResult.IsValid;
        //    }
        //}

    }


}
