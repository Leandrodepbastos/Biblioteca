/****************************************************************
 *  NOME DA CLASSE: AssociadoBD
 *       DESCRIÇÃO: Representação da classe de Banco AssociadoBD
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
    class AssociadoBD
    {
        // Método Destruct
        ~AssociadoBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public int Incluir(Associado pobj_Associado)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            

            string s_varDML = "INSERT INTO TB_ASSOCIADO " +
                              "( " +
                              "S_NM_ASSOCIADO, " +
                              "S_GEN_ASSOCIADO, " +
                              "S_MAIL_ASSOCIADO, " +
                              "S_CEL_ASSOCIADO, " +
                              "S_CPF_ASSOCIADO " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@S_NM_ASSOCIADO, " +
                              "@S_GEN_ASSOCIADO, " +
                              "@S_MAIL_ASSOCIADO, " +
                              "@S_CEL_ASSOCIADO, " +
                              "@S_CPF_ASSOCIADO " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_ASSOCIADO') AS ID_CURRENT";


            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@S_NM_ASSOCIADO", pobj_Associado.Nm_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_GEN_ASSOCIADO", pobj_Associado.Gen_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_ASSOCIADO", pobj_Associado.Mail_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_ASSOCIADO", pobj_Associado.Cel_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_ASSOCIADO", pobj_Associado.CPF_Associado);
                        

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

        public bool Alterar(Associado pobj_Associado)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_ASSOCIADO SET " +
                              "S_NM_ASSOCIADO  = @S_NM_ASSOCIADO, " +
                              "S_GEN_ASSOCIADO = @S_GEN_ASSOCIADO, " +
                              "S_MAIL_ASSOCIADO= @S_MAIL_ASSOCIADO, " +
                              "S_CEL_ASSOCIADO = @S_CEL_ASSOCIADO, " +
                              "S_CPF_ASSOCIADO = @S_CPF_ASSOCIADO " +
                              "WHERE I_COD_ASSOCIADO = @I_COD_ASSOCIADO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ASSOCIADO", pobj_Associado.Cod_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_NM_ASSOCIADO", pobj_Associado.Nm_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_GEN_ASSOCIADO", pobj_Associado.Gen_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_ASSOCIADO", pobj_Associado.Mail_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_ASSOCIADO", pobj_Associado.Cel_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_ASSOCIADO", pobj_Associado.CPF_Associado);

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
        public bool Excluir(Associado pobj_Associado)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_ASSOCIADO " +
                              "WHERE I_COD_ASSOCIADO = @I_COD_ASSOCIADO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ASSOCIADO", pobj_Associado.Cod_Associado);

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


        #region Método FindByCodAssociado()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodAssociado
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Associado FindByCodAssociado(Associado pobj_Associado)
        {

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_ASSOCIADO " +
                              "WHERE I_COD_ASSOCIADO = @I_COD_ASSOCIADO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ASSOCIADO", pobj_Associado.Cod_Associado);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Associado.Nm_Associado = obj_Dtr["S_NM_ASSOCIADO"].ToString();
                    pobj_Associado.CPF_Associado = obj_Dtr["S_CPF_ASSOCIADO"].ToString();
                    pobj_Associado.Cel_Associado = obj_Dtr["S_CEL_ASSOCIADO"].ToString();
                    pobj_Associado.Mail_Associado = obj_Dtr["S_MAIL_ASSOCIADO"].ToString();
                    pobj_Associado.Gen_Associado = obj_Dtr["S_GEN_ASSOCIADO"].ToString();

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Associado;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Associado;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Associado;
            }
        }
        #endregion


        #region Método FindAllAssociado()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllAssociado
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Associado> FindAllAssociado()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_ASSOCIADO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Associado> lista = new List<Associado>();

                if (obj_Dtr.HasRows)
                {
                    Associado obj_Associado = new Associado();

                    while (obj_Dtr.Read())
                    {
                        obj_Associado.Cod_Associado = Convert.ToInt16(obj_Dtr["I_COD_ASSOCIADO"].ToString());
                        obj_Associado.Nm_Associado = obj_Dtr["S_NM_ASSOCIADO"].ToString();
                        obj_Associado.CPF_Associado = obj_Dtr["S_CPF_ASSOCIADO"].ToString();
                        obj_Associado.Cel_Associado = obj_Dtr["S_CEL_ASSOCIADO"].ToString();
                        obj_Associado.Mail_Associado = obj_Dtr["S_MAIL_ASSOCIADO"].ToString();
                        obj_Associado.Gen_Associado = obj_Dtr["S_GEN_ASSOCIADO"].ToString();

                        lista.Add(obj_Associado);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Associado>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Associado>();
            }
        }
        #endregion
    }
}