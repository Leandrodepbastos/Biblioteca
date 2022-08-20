/****************************************************************
 *  NOME DA CLASSE: GeneroBD
 *       DESCRIÇÃO: Representação da classe de Banco GeneroBD
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
    class GeneroBD
    {

        ~GeneroBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public int Incluir(Genero pobj_Genero)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_GENERO " +
                              "( " +
                              "S_TIT_GENERO, " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@S_TIT_GENERO, " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_GENERO') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@S_TIT_GENERO", pobj_Genero.Tit_Genero);


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

        public bool Alterar(Genero pobj_Genero)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_GENERO SET " +
                              "S_TIT_GENERO  = @S_TIT_GENERO, " +
                              "WHERE I_COD_GENERO = @I_COD_GENERO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);
            obj_Cmd.Parameters.AddWithValue("@S_TIT_GENERO", pobj_Genero.Tit_Genero);

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
        public bool Excluir(Genero pobj_Genero)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_GENERO " +
                              "WHERE I_COD_GENERO = @I_COD_GENERO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);

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


        #region Método FindByCodGenero()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodGenero
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Genero FindByCodGenero(Genero pobj_Genero)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_GENERO " +
                              "WHERE I_COD_GENERO = @I_COD_GENERO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Genero.Tit_Genero = obj_Dtr["S_TIT_GENERO"].ToString();

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Genero;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Genero;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Genero;
            }
        }
        #endregion


        #region Método FindAllGenero()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllGenero
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public List<Genero> FindAllGenero()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_GENERO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Genero> lista = new List<Genero>();

                if (obj_Dtr.HasRows)
                {
                    Genero obj_Genero = new Genero();

                    while (obj_Dtr.Read())
                    {
                        obj_Genero.Cod_Genero = Convert.ToInt16(obj_Dtr["I_COD_GENERO"].ToString());
                        obj_Genero.Tit_Genero = obj_Dtr["S_TIT_GENERO"].ToString();

                        lista.Add(obj_Genero);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Genero>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Genero>();
            }
        }
        #endregion
    }
}