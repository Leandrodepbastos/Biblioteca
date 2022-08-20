/****************************************************************
 *  NOME DA CLASSE: AutorBD
 *       DESCRIÇÃO: Representação da classe de Banco AutorBD
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
    class AutorBD
    {

        ~AutorBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public int Incluir(Autor pobj_Autor)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_AUTOR " +
                              "( " +
                              "I_COD_NACIONALIDADE, " +
                              "S_NM_AUTOR, " +
                              "S_GEN_AUTOR, " +
                              "DT_NAS_AUTOR " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@I_COD_NACIONALIDADE, " +
                              "@S_NM_AUTOR, " +
                              "@S_GEN_AUTOR, " +
                              "@DT_NAS_AUTOR " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_AUTOR') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@I_COD_NACIONALIDADE", pobj_Autor.Cod_Nacionalidade);
            obj_Cmd.Parameters.AddWithValue("@S_NM_AUTOR", pobj_Autor.Nm_Autor);
            obj_Cmd.Parameters.AddWithValue("@S_GEN_AUTOR", pobj_Autor.Gen_Autor);
            obj_Cmd.Parameters.AddWithValue("@DT_NAS_AUTOR", pobj_Autor.Nas_Autor);

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

        public bool Alterar(Autor pobj_Autor)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_AUTOR SET " +
                              "I_COD_NACIONALIDADE = @I_COD_NACIONALIDADE, " +
                              "S_NM_AUTOR = @S_NM_AUTOR, " +
                              "S_GEN_AUTOR = @S_GEN_AUTOR, " +
                              "DT_NAS_AUTOR = @DT_NAS_AUTOR, " +
                              "WHERE I_COD_AUTOR = @I_COD_AUTOR ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_NACIONALIDADE", pobj_Autor.Cod_Nacionalidade);
            obj_Cmd.Parameters.AddWithValue("@S_NM_AUTOR", pobj_Autor.Nm_Autor);
            obj_Cmd.Parameters.AddWithValue("@S_GEN_AUTOR", pobj_Autor.Gen_Autor);
            obj_Cmd.Parameters.AddWithValue("@DT_NAS_AUTOR", pobj_Autor.Nas_Autor);

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

        public bool Excluir(Autor pobj_Autor)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_AUTOR " +
                              "WHERE I_COD_AUTOR = @I_COD_AUTOR ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_AUTOR", pobj_Autor.Cod_Autor);

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


        #region Método FindByCodAutor()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodAutor
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Autor FindByCodAutor(Autor pobj_Autor)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_AUTOR " +
                              "WHERE I_COD_AUTOR = @I_COD_AUTOR ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_AUTOR", pobj_Autor.Cod_Autor);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Autor.Cod_Nacionalidade = Convert.ToInt16(obj_Dtr["I_COD_NACIONALIDADE"].ToString());
                    pobj_Autor.Nm_Autor = obj_Dtr["S_NM_GENERO"].ToString();
                    pobj_Autor.Gen_Autor = obj_Dtr["S_GEN_AUTOR"].ToString();
                    pobj_Autor.Nas_Autor = Convert.ToDateTime(obj_Dtr["DT_NAS_AUTOR"].ToString());

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Autor;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Autor;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Autor;
            }
        }
        #endregion


        #region Método FindAllAutor()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllAutor
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Autor> FindAllAutor()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_AUTOR ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Autor> lista = new List<Autor>();

                if (obj_Dtr.HasRows)
                {
                    Autor obj_Autor = new Autor();

                    while (obj_Dtr.Read())
                    {
                        obj_Autor.Cod_Nacionalidade = Convert.ToInt16(obj_Dtr["I_COD_NACIONALIDADE"].ToString());
                        obj_Autor.Nm_Autor = obj_Dtr["S_NM_AUTOR"].ToString();
                        obj_Autor.Gen_Autor = obj_Dtr["S_GEN_AUTOR"].ToString();
                        obj_Autor.Nas_Autor = Convert.ToDateTime(obj_Dtr["DT_NAS_AUTOR"].ToString());

                        lista.Add(obj_Autor);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Autor>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Autor>();
            }
        }
        #endregion
    }
}