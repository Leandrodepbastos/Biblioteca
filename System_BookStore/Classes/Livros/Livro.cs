using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Livro
    {
        ~Livro()
        {

        }

        #region Atributos Privados
        private int v_Cod_Livro = -1;
        private int v_Cod_Autor = -1;
        private int v_Cod_Genero = -1;
        private string v_Tit_Livro = "";
        private string v_ISBN_Livro = "";
        private string v_Lang_Livro = "";
        #endregion

        #region Metodos Públicos
        public int Cod_Livro
        {
            get => v_Cod_Livro;
            set => v_Cod_Livro = value;
        }

        public int Cod_Autor
        {
            get => v_Cod_Autor;
            set => v_Cod_Autor = value;
        }

        public int Cod_Genero
        {
            get => v_Cod_Genero;
            set => v_Cod_Genero = value;
        }

        public string Tit_Livro
        {
            get => v_Tit_Livro;
            set => v_Tit_Livro = value;
        }

        public string ISBN_Livro
        {
            get => v_ISBN_Livro;
            set => v_ISBN_Livro = value;
        }

        public string Lang_Livro
        {
            get => v_Lang_Livro;
            set => v_Lang_Livro = value;
        }
        #endregion
    }
}