using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Genero
    {

        ~Genero() { }

        #region Atributos Privados
        private int v_Cod_Genero = -1;
        private string v_Tit_Genero = "";
        #endregion

        #region Metodos Públicos
        public int Cod_Genero
        {
            get => v_Cod_Genero;
            set => v_Cod_Genero = value;
        }

        public string Tit_Genero
        {
            get => v_Tit_Genero;
            set => v_Tit_Genero = value;
        }
        #endregion
    }
}