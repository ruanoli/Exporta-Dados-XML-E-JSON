using Newtonsoft.Json;
using Projeto02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Repositories
{
    public class FuncionarioRepositoryJson : FuncionarioRepository
    {
        public override void Exportar(Funcionario funcionario)
        {
            //Recebe o objeto e convert para json.
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            using(var streamWriter =  new StreamWriter("c:\\temp2\\funcionario.json"))
            {
                streamWriter.WriteLine(json);
            }
        }
    }
}
