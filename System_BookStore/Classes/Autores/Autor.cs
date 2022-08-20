using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Autor
    {

        ~Autor() { }

        #region Atributos Privados
        private int v_Cod_Autor = -1;
        private int v_Cod_Nacionalidade = -1;
        private string v_Nm_Autor = "";
        private string v_Gen_Autor = "";
        private DateTime v_Nas_Autor = DateTime.MinValue;
        #endregion

        #region Métodos Públicos
        public int Cod_Autor
        {
            get => v_Cod_Autor;
            set => v_Cod_Autor = value;
        }

        public int Cod_Nacionalidade
        {
            get => v_Cod_Nacionalidade;
            set => v_Cod_Nacionalidade = value;
        }

        public string Nm_Autor
        {
            get => v_Nm_Autor;
            set => v_Nm_Autor = value;
        }

        public string Gen_Autor
        {
            get => v_Gen_Autor;
            set => v_Gen_Autor = value;
        }

        public DateTime Nas_Autor
        {
            get => v_Nas_Autor;
            set => v_Nas_Autor = value;
        }
        #endregion
    }
}
