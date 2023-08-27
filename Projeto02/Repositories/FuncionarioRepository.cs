using Projeto02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Repositories
{
    /// <summary>
    /// Classe servirá de base padrão para outras classes
    /// </summary>
    public abstract class FuncionarioRepository
    {
        public abstract void Exportar(Funcionario funcionario);
    }
}
