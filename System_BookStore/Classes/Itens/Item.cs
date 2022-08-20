using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Item
    {
        ~Item()
        {

        }

        #region Atributos Privados
        private int v_Cod_Item = -1;
        private int v_Cod_Livro = -1;
        private int v_Cod_Emprestimo = -1;
        #endregion

        #region Metodos Públicos
        public int Cod_Item
        {
            get => v_Cod_Item;
            set => v_Cod_Item = value;
        }

        public int Cod_Livro
        {
            get => v_Cod_Livro;
            set => v_Cod_Livro = value;
        }

        public int Cod_Emprestimo
        {
            get => v_Cod_Emprestimo;
            set => v_Cod_Emprestimo = value;
        }
        #endregion
    }
}
