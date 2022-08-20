/****************************************************************
 *  NOME DA CLASSE: Associado
 *       DESCRIÇÃO: Esta classe de objeto representa o Associado
 *                  da bibliotéca.
 *     DT. CRIAÇÃO: -
 *   DT. ALTERAÇÃO: --/--/---- ( -- )
 *      CRIADA POR: -
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Associado
    {
        // Método Destruct
        ~Associado() { }


        #region Atributos Privados
        
        private int v_Cod_Associado = -1;
        private string v_Nm_Associado = "";
        private string v_Gen_Associado = "";
        private string v_Mail_Associado = "";
        private string v_Cel_Associado = "";
        private string v_CPF_Associado = "";

        #endregion


        #region Métodos Públicos

        public int Cod_Associado 
        { 
            get => v_Cod_Associado; 
            set => v_Cod_Associado = value; 
        }

        public string Nm_Associado 
        { 
            get => v_Nm_Associado; 
            set => v_Nm_Associado = value; 
        }

        public string Gen_Associado 
        { 
            get => v_Gen_Associado; 
            set => v_Gen_Associado = value; 
        }

        public string Mail_Associado 
        { 
            get => v_Mail_Associado; 
            set => v_Mail_Associado = value; 
        }

        public string Cel_Associado 
        { 
            get => v_Cel_Associado; 
            set => v_Cel_Associado = value; 
        }

        public string CPF_Associado 
        { 
            get => v_CPF_Associado; 
            set => v_CPF_Associado = value; 
        }

        #endregion
    }
}
