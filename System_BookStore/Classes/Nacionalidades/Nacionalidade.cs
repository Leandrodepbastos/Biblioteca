using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Nacionalidade
    {
        ~Nacionalidade()
        {

        }

        #region Atributos Privados
        private int v_Cod_Nacionalidade = -1;
        private string v_Tit_Nacionalidade = "";
        #endregion

        #region Metodos Públicos
        public int Cod_Nacionalidade
        {
            get => v_Cod_Nacionalidade;
            set => v_Cod_Nacionalidade = value;
        }

        public string Tit_Nacionalidade
        {
            get => v_Tit_Nacionalidade;
            set => v_Tit_Nacionalidade = value;
        }
        #endregion
    }
}
