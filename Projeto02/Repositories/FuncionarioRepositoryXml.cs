using Projeto02.Entities;
using System.Xml.Serialization;

namespace Projeto02.Repositories
{
    public class FuncionarioRepositoryXml : FuncionarioRepository
    {
        public override void Exportar(Funcionario funcionario)
        {
            //Gerando um xml.
            var xml = new XmlSerializer(funcionario.GetType());

            //Escrevendo os dados
            using (var streamWriter = new StreamWriter("c:\\temp2\\funcionario.xml"))
            {
                //recebe os dados passados por paramêtro no Exportar.
                //passa os dados para o streamWriter que cria um arquivo no caminho passado
                //transforma em xml
                xml.Serialize(streamWriter, funcionario);
            }
        }
    }
}
