using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto02.Entities
{
    public class Funcionario
    {
        private Guid _id;
        private string? _cpf;
        private string? _matricula;
        private string? _nome;
        private DateTime _dataAdmissao;
        private Setor _setor;
        private Funcao _funcao;


        public Guid Id
        {
            get
            {
                return _id;
            }

            set 
            { 
                if(value  == null || value == Guid.Empty)
                {
                    throw new ArgumentException("Id não pode ser nulo.");
                }    
                
                _id = value; 
            }
        }

        public string Cpf
        {
            get
            {
                return _cpf;
            }

            set 
            {
                //Aceita somente números e 11 caracteres.
                var regex = new Regex("^[0-9]{11}$");

                if(!regex.IsMatch(value))
                {
                    throw new ArgumentException("Informe um CPF válido.");
                }

                _cpf = value; 
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set 
            {
                //^ marca o início da expressão regular
                //$ marca o fim
                //Entre [] colocamos os caracteres que permitiremos que o nome tenha.
                //A-Za-z Aceita letras maiúsculas e minúsculas de a à z.
                //À-Ü permite acentos
                // \\s aceita espaços
                //Entre {} colocamos o mínimo e máximo de caracteres
                //0-9 permitirá números.
                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{3,150}$");

                //Verifica se a expressão regular é válida.
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Nome do funcionário inválido.");
                }
                _nome = value; 
            }
        }

        public string Matricula
        {
            get
            {

                return _matricula;
            }

            set 
            {
                var regex = new Regex("^[A-Z0-9]{5,10}$");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Mátricula inválida.");
                }
                _matricula = value; 
            }
        }

        public DateTime DataAdmissao
        {
            get
            {
                return _dataAdmissao;
            }

            set 
            {
                if(value == DateTime.MinValue || value < DateTime.Now)
                {
                    throw new ArgumentException("Data de admissão inválida.");
                }
                
                _dataAdmissao = value; 
            }
        }

        public Setor Setor
        {
            get { return _setor; }
            set { _setor = value; }
        }

        public Funcao Funcao
        {
            get { return _funcao; }
            set { _funcao = value; }
        }
    }
}
