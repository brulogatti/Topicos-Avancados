using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcessoDados;
using Entidade;

namespace Negocio
{
    public class TesteCadastroBO
    {
        TesteCadastroDAO daoTestaCadastro;

        public List<EntTesteCadastro> BuscarCliente(EntTesteCadastro cliente)
        {
            daoTestaCadastro = new TesteCadastroDAO();
            return daoTestaCadastro.BuscarCadastro(cliente);
        }

    }
}
