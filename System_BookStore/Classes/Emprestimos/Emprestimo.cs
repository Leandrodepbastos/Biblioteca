using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_BookStore
{
    class Emprestimo
    {

        ~Emprestimo() { }

        #region Atributos Privados
        private int v_Cod_Emprestimo = -1;
        private int v_Cod_Funcionario = -1;
        private int v_Cod_Associado = -1;
        private DateTime v_Dt_Emp_Emprestimo = DateTime.MinValue;
        private DateTime v_Dt_Dev_Emprestimo = DateTime.MinValue;
        #endregion

        #region Metodos Públicos
        public int Cod_Emprestimo 
        { 
            get => v_Cod_Emprestimo; 
            set => v_Cod_Emprestimo = value; 
        }
        public int Cod_Funcionario 
        { 
            get => v_Cod_Funcionario; 
            set => v_Cod_Funcionario = value; 
        }
        public int Cod_Associado 
        { 
            get => v_Cod_Associado; 
            set => v_Cod_Associado = value; 
        }
        public DateTime Emp_Emprestimo 
        { 
            get => v_Dt_Emp_Emprestimo; 
            set => v_Dt_Emp_Emprestimo = value; 
        }
        public DateTime Dev_Emprestimo 
        { 
            get => v_Dt_Dev_Emprestimo; 
            set => v_Dt_Dev_Emprestimo = value; 
        }
        #endregion



    }
}
