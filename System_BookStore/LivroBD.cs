/****************************************************************
 *  NOME DA CLASSE: LivroBD
 *       DESCRIÇÃO: Representação da classe de Banco LivroBD
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
    class LivroBD
    {

        ~LivroBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public int Incluir(Livro pobj_Livro)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_LIVRO " +
                              "( " +
                              "I_COD_AUTOR, " +
                              "I_COD_GENERO, " +
                              "S_TIT_LIVRO, " +
                              "S_ISBN_LIVRO, " +
                              "S_LANG_LIVRO " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@I_COD_AUTOR, " +
                              "@I_COD_GENERO, " +
                              "@S_TIT_LIVRO, " +
                              "@S_ISBN_LIVRO, " +
                              "@DT_LANG_LIVRO " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_LIVRO') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@I_COD_AUTOR", pobj_Livro.Cod_Autor);
            obj_Cmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Livro.Cod_Genero);
            obj_Cmd.Parameters.AddWithValue("@S_TIT_LIVRO", pobj_Livro.Tit_Livro);
            obj_Cmd.Parameters.AddWithValue("@S_ISBN_LIVRO", pobj_Livro.ISBN_Livro);
            obj_Cmd.Parameters.AddWithValue("@DT_LANG_LIVRO", pobj_Livro.Lang_Livro);

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

        public bool Alterar(Livro pobj_Livro)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_LIVRO SET " +
                              "I_COD_AUTOR, = @I_COD_AUTOR, " +
                              "I_COD_GENERO, = @I_COD_GENERO, " +
                              "S_TIT_LIVRO, = @S_TIT_LIVRO, " +
                              "S_ISBN_LIVRO, = @S_ISBN_LIVRO " +
                              "S_LANG_LIVRO = @S_LANG_LIVRO " +
                              "WHERE I_COD_LIVRO = @I_COD_LIVRO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_AUTOR", pobj_Livro.Cod_Autor);
            obj_Cmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Livro.Cod_Genero);
            obj_Cmd.Parameters.AddWithValue("@S_TIT_LIVRO", pobj_Livro.Tit_Livro);
            obj_Cmd.Parameters.AddWithValue("@S_ISBN_LIVRO", pobj_Livro.ISBN_Livro);
            obj_Cmd.Parameters.AddWithValue("@S_LANG_LIVRO", pobj_Livro.Lang_Livro);

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

        public bool Excluir(Livro pobj_Livro)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_LIVRO " +
                              "WHERE I_COD_LIVRO = @I_COD_LIVRO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_LIVRO", pobj_Livro.Cod_Livro);

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


        #region Método FindByCodLivro()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodLivro
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Livro FindByCodLivro(Livro pobj_Livro)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_LIVRO " +
                              "WHERE I_COD_LIVRO = @I_COD_LIVRO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_LIVRO", pobj_Livro.Cod_Livro);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Livro.Cod_Autor = Convert.ToInt16(obj_Dtr["I_COD_AUTOR"].ToString());
                    pobj_Livro.Cod_Genero = Convert.ToInt16(obj_Dtr["I_COD_GENERO"].ToString());
                    pobj_Livro.Tit_Livro = obj_Dtr["S_TIT_LIVRO"].ToString();
                    pobj_Livro.ISBN_Livro = obj_Dtr["S_ISBN_LIVRO"].ToString();
                    pobj_Livro.Lang_Livro = obj_Dtr["S_LANG_LIVRO"].ToString();

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Livro;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Livro;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Livro;
            }
        }
        #endregion


        #region Método FindAllLivro()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllLivro
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Livro> FindAllLivro()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_LIVRO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Livro> lista = new List<Livro>();

                if (obj_Dtr.HasRows)
                {
                    Livro obj_Livro = new Livro();

                    while (obj_Dtr.Read())
                    {
                        obj_Livro.Cod_Livro = Convert.ToInt16(obj_Dtr["I_COD_LIVRO"].ToString());
                        obj_Livro.Cod_Autor = Convert.ToInt16(obj_Dtr["I_COD_AUTOR"].ToString());
                        obj_Livro.Cod_Genero = Convert.ToInt16(obj_Dtr["I_COD_GENERO"].ToString());
                        obj_Livro.Tit_Livro = obj_Dtr["S_TIT_LIVRO"].ToString();
                        obj_Livro.ISBN_Livro = obj_Dtr["S_ISBN_LIVRO"].ToString();
                        obj_Livro.Lang_Livro = obj_Dtr["S_LANG_LIVRO"].ToString();

                        lista.Add(obj_Livro);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Livro>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Livro>();
            }
        }
        #endregion
    }
}