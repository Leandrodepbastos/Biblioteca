/****************************************************************
 *  NOME DA CLASSE: EmprestimoBD
 *       DESCRIÇÃO: Representação da classe de Banco EmprestimoBD
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
using System.Data.SqlClient;
using System.Windows.Forms;

namespace System_BookStore
{
    class EmprestimoBD
    {

        ~EmprestimoBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public int Incluir(Emprestimo pobj_Emprestimo)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_EMPRESTIMO " +
                              "( " +
                              "I_COD_FUNCIONARIO, " +
                              "I_COD_ASSOCIADO, " +
                              "DT_EMP_EMPRESTIMO, " +
                              "DT_DEV_EMPRESTIMO " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@I_COD_FUNCIONARIO, " +
                              "@I_COD_ASSOCIADO, " +
                              "@DT_EMP_EMPRESTIMO, " +
                              "@DT_DEV_EMPRESTIMO " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_EMPRESTIMO') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Emprestimo.Cod_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ASSOCIADO", pobj_Emprestimo.Cod_Associado);
            obj_Cmd.Parameters.AddWithValue("@DT_EMP_EMPRESTIMO", pobj_Emprestimo.Emp_Emprestimo);
            obj_Cmd.Parameters.AddWithValue("@DT_DEV_EMPRESTIMO", pobj_Emprestimo.Dev_Emprestimo);

            try
            {
                obj_Con.Open();

                Id = Convert.ToInt16(obj_Cmd.ExecuteScalar());

                obj_Con.Close();

                return Id;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Id;
            }
        }
        #endregion 

        #region Método Alterar()

        /****************************************************************
        *  NOME DO MÉTODO: Alterar
        *       DESCRIÇÃO: Responsável por Alterar o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public bool Alterar(Emprestimo pobj_Emprestimo)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_EMPRESTIMO SET " +
                              "I_COD_AUTOR, = @I_COD_AUTOR, " +
                              "I_COD_GENERO, = @I_COD_GENERO, " +
                              "S_TIT_EMPRESTIMO, = @S_TIT_EMPRESTIMO, " +
                              "S_ISBN_EMPRESTIMO, = @S_ISBN_EMPRESTIMO " +
                              "S_LANG_EMPRESTIMO = @S_LANG_EMPRESTIMO " +
                              "WHERE I_COD_EMPRESTIMO = @I_COD_EMPRESTIMO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Emprestimo.Cod_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ASSOCIADO", pobj_Emprestimo.Cod_Associado);
            obj_Cmd.Parameters.AddWithValue("@DT_EMP_EMPRESTIMO", pobj_Emprestimo.Emp_Emprestimo);
            obj_Cmd.Parameters.AddWithValue("@DT_DEV_EMPRESTIMO", pobj_Emprestimo.Dev_Emprestimo);

            try
            {
                obj_Con.Open();

                if (obj_Cmd.ExecuteNonQuery() != 0)
                {
                    b_Alterado = true;
                }

                obj_Con.Close();

                return b_Alterado;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return b_Alterado;
            }
        }
        #endregion


        #region Método Excluir()

        /****************************************************************
        *  NOME DO MÉTODO: Excluir
        *       DESCRIÇÃO: Responsável por Excluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public bool Excluir(Emprestimo pobj_Emprestimo)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_EMPRESTIMO " +
                              "WHERE I_COD_EMPRESTIMO = @I_COD_EMPRESTIMO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_EMPRESTIMO", pobj_Emprestimo.Cod_Emprestimo);

            try
            {
                obj_Con.Open();

                if (obj_Cmd.ExecuteNonQuery() != 0)
                {
                    b_Excluido = true;
                }

                obj_Con.Close();


                return b_Excluido;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return b_Excluido;
            }
        }
        #endregion


        #region Método FindByCodEmprestimo()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodEmprestimo
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Emprestimo FindByCodEmprestimo(Emprestimo pobj_Emprestimo)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_EMPRESTIMO " +
                              "WHERE I_COD_EMPRESTIMO = @I_COD_EMPRESTIMO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_EMPRESTIMO", pobj_Emprestimo.Cod_Emprestimo);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Emprestimo.Cod_Funcionario = Convert.ToInt16(obj_Dtr["I_COD_AUTOR"].ToString());
                    pobj_Emprestimo.Cod_Associado = Convert.ToInt16(obj_Dtr["I_COD_GENERO"].ToString());
                    pobj_Emprestimo.Emp_Emprestimo = Convert.ToDateTime(obj_Dtr["DT_EMP_EMPRESTIMO"].ToString());
                    pobj_Emprestimo.Dev_Emprestimo = Convert.ToDateTime(obj_Dtr["DT_DEV_EMPRESTIMO"].ToString());

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Emprestimo;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Emprestimo;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Emprestimo;
            }
        }
        #endregion


        #region Método FindAllEmprestimo()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllEmprestimo
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Emprestimo> FindAllEmprestimo()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_EMPRESTIMO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Emprestimo> lista = new List<Emprestimo>();

                if (obj_Dtr.HasRows)
                {
                    Emprestimo obj_Emprestimo = new Emprestimo();

                    while (obj_Dtr.Read())
                    {
                        obj_Emprestimo.Cod_Emprestimo = Convert.ToInt16(obj_Dtr["I_COD_EMPRESTIMO"].ToString());
                        obj_Emprestimo.Cod_Funcionario = Convert.ToInt16(obj_Dtr["I_COD_AUTOR"].ToString());
                        obj_Emprestimo.Cod_Associado = Convert.ToInt16(obj_Dtr["I_COD_GENERO"].ToString());
                        obj_Emprestimo.Emp_Emprestimo = Convert.ToDateTime(obj_Dtr["S_TIT_EMPRESTIMO"].ToString());
                        obj_Emprestimo.Dev_Emprestimo = Convert.ToDateTime(obj_Dtr["S_ISBN_EMPRESTIMO"].ToString());

                        lista.Add(obj_Emprestimo);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Emprestimo>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Emprestimo>();
            }
        }
        #endregion
    }
}