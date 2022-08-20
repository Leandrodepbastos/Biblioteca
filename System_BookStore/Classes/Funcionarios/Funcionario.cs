using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Funcionario
    {
        // Método Destruct
        ~Funcionario() { }


        #region Atributos Privados
        private int v_Cod_Funcionario = -1;
        private string v_Nm_Funcionario = "";
        private string v_Log_Funcionario = "";
        private string v_Pass_Funcionario = "";
        #endregion


        #region Métodos Públicos
        public int Cod_Funcionario 
        { 
            get => v_Cod_Funcionario; 
            set => v_Cod_Funcionario = value; 
        }

        public string Nm_Funcionario 
        { 
            get => v_Nm_Funcionario; 
            set => v_Nm_Funcionario = value; 
        }

        public string Log_Funcionario 
        { 
            get => v_Log_Funcionario; 
            set => v_Log_Funcionario = value; 
        }

        public string Pass_Funcionario 
        { 
            get => v_Pass_Funcionario; 
            set => v_Pass_Funcionario = value; 
        }

        #endregion
    }
}
