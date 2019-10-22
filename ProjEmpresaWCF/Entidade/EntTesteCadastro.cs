using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class EntTesteCadastro
    {
        #region Atributo
        private int _id;
        private string _nome;
        private int _qtdfuncionarios;
        private string _endereco;
        #endregion

        #region Propriedade
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
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
        public int QtdFuncionarios
        {
            get
            {
                return _qtdfuncionarios;
            }
            set
            {
                _qtdfuncionarios = value;
            }
        }
        public string Endereco
        {
            get
            {
                return _endereco;
            }
            set
            {
                _endereco = value;
            }
        }
        #endregion
    }
}
