/****************************************************************
 *  NOME DA CLASSE: NacionalidadeBD
 *       DESCRIÇÃO: Representação da classe de Banco NacionalidadeBD
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
    class NacionalidadeBD
    {

        ~NacionalidadeBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public int Incluir(Nacionalidade pobj_Nacionalidade)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_NACIONALIDADE " +
                              "( " +
                              "S_TIT_NACIONALIDADE, " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@S_TIT_NACIONALIDADE, " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_NACIONALIDADE') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@S_TIT_NACIONALIDADE", pobj_Nacionalidade.Tit_Nacionalidade);


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
        ****************************************************************/

        public bool Alterar(Nacionalidade pobj_Nacionalidade)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_NACIONALIDADE SET " +
                              "S_TIT_NACIONALIDADE  = @S_TIT_NACIONALIDADE, " +
                              "WHERE I_COD_NACIONALIDADE = @I_COD_NACIONALIDADE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_NACIONALIDADE", pobj_Nacionalidade.Cod_Nacionalidade);
            obj_Cmd.Parameters.AddWithValue("@S_TIT_NACIONALIDADE", pobj_Nacionalidade.Tit_Nacionalidade);

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
        public bool Excluir(Nacionalidade pobj_Nacionalidade)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_NACIONALIDADE " +
                              "WHERE I_COD_NACIONALIDADE = @I_COD_NACIONALIDADE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_NACIONALIDADE", pobj_Nacionalidade.Cod_Nacionalidade);

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


        #region Método FindByCodNacionalidade()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodNacionalidade
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Nacionalidade FindByCodNacionalidade(Nacionalidade pobj_Nacionalidade)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_NACIONALIDADE " +
                              "WHERE I_COD_NACIONALIDADE = @I_COD_NACIONALIDADE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_NACIONALIDADE", pobj_Nacionalidade.Cod_Nacionalidade);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Nacionalidade.Tit_Nacionalidade = obj_Dtr["S_TIT_NACIONALIDADE"].ToString();

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Nacionalidade;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Nacionalidade;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Nacionalidade;
            }
        }
        #endregion


        #region Método FindAllNacionalidade()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllNacionalidade
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public List<Nacionalidade> FindAllNacionalidade()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_NACIONALIDADE ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Nacionalidade> lista = new List<Nacionalidade>();

                if (obj_Dtr.HasRows)
                {
                    Nacionalidade obj_Nacionalidade = new Nacionalidade();

                    while (obj_Dtr.Read())
                    {
                        obj_Nacionalidade.Cod_Nacionalidade = Convert.ToInt16(obj_Dtr["I_COD_NACIONALIDADE"].ToString());
                        obj_Nacionalidade.Tit_Nacionalidade = obj_Dtr["S_TIT_NACIONALIDADE"].ToString();

                        lista.Add(obj_Nacionalidade);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Nacionalidade>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Nacionalidade>();
            }
        }
        #endregion
    }
}