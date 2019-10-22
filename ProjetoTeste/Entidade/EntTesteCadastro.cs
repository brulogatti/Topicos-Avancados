using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class EntTesteCadastro
    {
        #region Atributo
        private int _codigo;
        private string _nome;
        private string _telefone;
        #endregion

        #region Propriedade
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
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
                _nome = value;
            }
        }
        public string Telefone
        {
            get
            {
                return _telefone;
            }
            set
            {
                _telefone = value;
            }
        }
        #endregion
    }
}
