using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto02.Entities
{
    public class Funcao
    {
        private Guid _id;
        private string _nome;
        private string _descricao;

        public Guid Id
        {
            get { return _id; }
            set 
            {
                if(value == Guid.Empty)
                {
                    throw new ArgumentException("Id obrigatório");
                }
                _id = value; 
            }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                var regex = new Regex("^[A-Za-z\\s]{3,100}$");

                if(!regex.IsMatch(value))
                {
                    throw new ArgumentException("Nome inválido.");
                }
                _nome = value; 
            }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
