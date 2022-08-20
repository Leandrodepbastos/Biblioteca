/****************************************************************
 *  NOME DA CLASSE: ItemBD
 *       DESCRIÇÃO: Representação da classe de Banco ItemBD
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
    class ItemBD
    {

        ~ItemBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ****************************************************************/

        public int Incluir(Item pobj_Item)
        {
            int Id = -1;


            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "INSERT INTO TB_ITEM " +
                              "( " +
                              "I_COD_LIVRO, " +
                              "I_COD_EMPRESTIMO " +
                              ") " +
                              "VALUES " +
                              "( " +
                              "@I_COD_LIVRO, " +
                              "@I_COD_EMPRESTIMO " +
                              "); " +
                              "SELECT IDENT_CURRENT ('TB_ITEM') AS ID_CURRENT";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@I_COD_LIVRO", pobj_Item.Cod_Livro);
            obj_Cmd.Parameters.AddWithValue("@I_COD_EMPRESTIMO", pobj_Item.Cod_Emprestimo);

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

        public bool Alterar(Item pobj_Item)
        {
            bool b_Alterado = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "UPDATE TB_ITEM SET " +
                              "I_COD_LIVRO = @I_COD_LIVRO, " +
                              "I_COD_EMPRESTIMO = @I_COD_EMPRESTIMO, " +
                              "WHERE I_COD_ITEM = @I_COD_ITEM ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_LIVRO", pobj_Item.Cod_Livro);
            obj_Cmd.Parameters.AddWithValue("@I_COD_EMPRESTIMO", pobj_Item.Cod_Emprestimo);
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

        public bool Excluir(Item pobj_Item)
        {
            bool b_Excluido = false;

            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "DELETE FROM TB_ITEM " +
                              "WHERE I_COD_ITEM = @I_COD_ITEM ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITEM", pobj_Item.Cod_Item);

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


        #region Método FindByCodItem()

        /****************************************************************
        *  NOME DO MÉTODO: FindByCodItem
        *       DESCRIÇÃO: Responsável por encontrar o registro na tabela
        *                  mediante ao parametro passado.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Item FindByCodItem(Item pobj_Item)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_ITEM " +
                              "WHERE I_COD_ITEM = @I_COD_ITEM ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ITEM", pobj_Item.Cod_Item);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Item.Cod_Livro = Convert.ToInt16(obj_Dtr["I_COD_LIVRO"].ToString());
                    pobj_Item.Cod_Emprestimo = Convert.ToInt16(obj_Dtr["I_COD_EMPRESTIMO"].ToString());

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return pobj_Item;
                }
                else
                {
                    obj_Con.Close();
                    return pobj_Item;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Item;
            }
        }
        #endregion


        #region Método FindAllItem()

        /****************************************************************
        *  NOME DO MÉTODO: FindAllItem
        *       DESCRIÇÃO: Responsável por encontrar todos os registros 
        *                  na tabela.
        *     DT. CRIAÇÃO: -
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: -
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Item> FindAllItem()
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_varDML = "SELECT * FROM TB_ITEM ";

            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);

            try
            {
                obj_Con.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Item> lista = new List<Item>();

                if (obj_Dtr.HasRows)
                {
                    Item obj_Item = new Item();

                    while (obj_Dtr.Read())
                    {
                        obj_Item.Cod_Item = Convert.ToInt16(obj_Dtr["I_COD_ITEM"].ToString());
                        obj_Item.Cod_Livro = Convert.ToInt16(obj_Dtr["I_COD_LIVRO"].ToString());
                        obj_Item.Cod_Emprestimo = Convert.ToInt16(obj_Dtr["I_COD_EMPRESTIMO"].ToString());

                        lista.Add(obj_Item);
                    }

                    obj_Con.Close();
                    obj_Dtr.Close();

                    return lista;
                }
                else
                {
                    obj_Con.Close();
                    return new List<Item>();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Item>();
            }
        }
        #endregion
    }
}