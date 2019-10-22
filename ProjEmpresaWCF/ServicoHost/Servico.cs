using Entidade;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoHost
{
    class Servico : IServico
    {
        TesteCadastroBO boTesteCadastro;
        public List<EntTesteCadastro> Consultar(string nome)
        {
            boTesteCadastro = new TesteCadastroBO();
            EntTesteCadastro cliente = new EntTesteCadastro();
            cliente.Nome = nome;
            return boTesteCadastro.BuscarCliente(cliente);
        }
    }
}