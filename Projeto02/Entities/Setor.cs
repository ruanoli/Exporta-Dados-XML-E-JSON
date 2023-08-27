using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto02.Entities
{
    public class Setor
    {
        private Guid _id;
        private string _name;


        public Guid Id 
        { 
            get { return _id; }
            
            set 
            { 
                if(value == Guid.Empty)
                {
                    throw new ArgumentException("Id não pode ser nulo.");
                }
                _id = value; 
            }
        }

        public string Nome
        {
            get { return _name; }
            set 
            {
                var regex = new Regex("^[A-Za-zÀ-Üa-ü\\s]{3,50}$");

                if(!regex.IsMatch(value))
                {
                    throw new ArgumentException("Nome do setor inválido.");
                }

                _name = value; 
            }
        }
    }
}
