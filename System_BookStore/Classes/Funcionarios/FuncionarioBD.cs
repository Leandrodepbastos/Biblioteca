/****************************************************************
 *  NOME DA CLASSE: FuncionarioBD
 *       DESCRIÇÃO: Representação da classe de Banco FuncionarioBD
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
    class FuncionarioBD
    {
        // Método Destruct
        ~FuncionarioBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public int Incluir(Funcionario pobj_Funcionario)
        {
            int Id = -1;

            
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_FUNCIONARIO " +
                              "( " +
                              "S_NM_FUNCIONARIO, " +
                              "S_LOG_FUNCIONARIO, " +
                              "S_PASS_FUNCIONARIO, " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@S_NM_FUNCIONARIO, " +
                              "@S_LOG_FUNCIONARIO, " +
                              "@S_PASS_FUNCIONARIO, " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_FUNCIONARIO') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@S_NM_FUNCIONARIO", pobj_Funcionario.Nm_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_LOG_FUNCIONARIO", pobj_Funcionario.Log_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_PASS_FUNCIONARIO", pobj_Funcionario.Pass_Funcionario);

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

        public bool Alterar(Funcionario pobj_Funcionario)
        {
            bool b_Alterado = false;

            //(05/07/2022 - mfacine) - Criar a Classe Connection
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_FUNCIONARIO SET " +
                              "S_NM_FUNCIONARIO  = @S_NM_FUNCIONARIO, " +
                              "S_LOG_FUNCIONARIO = @S_LOG_FUNCIONARIO, " +
                              "S_PASS_FUNCIONARIO = @S_PASS_FUNCIONARIO " +
                              "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_NM_FUNCIONARIO", pobj_Funcionario.Nm_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_LOG_FUNCIONARIO", pobj_Funcionario.Log_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_PASS_FUNCIONARIO", pobj_Funcionario.Pass_Funcionario);

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

        public bool Excluir(Funcionario pobj_Funcionario)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_FUNCIONARIO " +
                              "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);

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


        #region Método FindByCodFuncionario()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodFuncionario
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Funcionario FindByCodFuncionario(Funcionario pobj_Funcionario)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_FUNCIONARIO " +
                              "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Funcionario.Nm_Funcionario = obj_Dtr["S_NM_FUNCIONARIO"].ToString();
                    pobj_Funcionario.Log_Funcionario = obj_Dtr["S_LOG_FUNCIONARIO"].ToString();
                    pobj_Funcionario.Pass_Funcionario = obj_Dtr["S_PASS_FUNCIONARIO"].ToString();

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Funcionario;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Funcionario;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Funcionario;
            }
        }
        #endregion


        #region Método FindAllFuncionario()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllFuncionario
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Funcionario> FindAllFuncionario()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_FUNCIONARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Funcionario> lista = new List<Funcionario>();

                if (obj_Dtr.HasRows)
                {
                    Funcionario obj_Funcionario = new Funcionario();

                    while (obj_Dtr.Read())
                    {
                        obj_Funcionario.Cod_Funcionario = Convert.ToInt16(obj_Dtr["I_COD_FUNCIONARIO"].ToString());
                        obj_Funcionario.Nm_Funcionario = obj_Dtr["S_NM_FUNCIONARIO"].ToString();
                        obj_Funcionario.Log_Funcionario = obj_Dtr["S_LOG_FUNCIONARIO"].ToString();
                        obj_Funcionario.Pass_Funcionario = obj_Dtr["S_PASS_FUNCIONARIO"].ToString();

                        lista.Add(obj_Funcionario);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Funcionario>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Funcionario>();
            }
        }
        #endregion
    }
}