/****************************************************************
 *  NOME DA CLASSE: AssociadoBD
 *       DESCRIÇÃO: Representação da classe de Banco AssociadoBD
 *                  da bibliotéca.
 *     DT. CRIAÇÃO: 05/07/2022
 *   DT. ALTERAÇÃO: --/--/---- ( -- )
 *      CRIADA POR: mFacine (Monstro)
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
        *     DT. CRIAÇÃO: 05/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public int Incluir(Associado pobj_Associado)
        {
            // CRIE UMA VARIAVEL QUE RECEBERA UM NUMERO ALEATORIO PARA O Cod. Id DO ASSOCIADO
            int Id = -1;

            //(05/07/2022 - mfacine) - Criar a Classe Connection

            // PRIMEIRAMENTE CRIAMOS UM OBJETO(obj_Con) QUE RECEBE POR PARAMETRO:  @"Data Source (LocalDB)\MSSQLLocalDB; AttachDBFilename = C:\csharp\System_BookStore\System_BookStore\BD_BOOKLEND.mdf; Integrated Security = true; Connect Timeout = 10;
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            // CRIADO O ojb_Con DA CLASSE SqlConnection 
            // GUARDADA A STRING DE CONEXÃO COM O BANCO, QUE ESTAVA NO return DA FUNCAO ConnectionPath() NA CLASSE Connection.cs

            // obj_Con = @"Data Source (LocalDB)\MSSQLLocalDB;
            //           AttachDBFilename = C:\csharp\System_BookStore\System_BookStore\BD_BOOKLEND.mdf;
            //           Integrated Security  =  true;
            //           Connect Timeout  =      10; 

            // CRIADO O OBJETO COM OS DADOS DE CONEXAO, PROSSEGUIMOS


            // CRIAMOS O COMANDO PARA INSERIR UM OBJETO NOVO NO BANCO:

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

            // CRIADA A STRING(s_varDML) CONTENDO OS COMANDOS PARA O BANCO:

            // CRIAMOS MAIS UM OBJETO(obj_Cmd)
            SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
            //                                 (COMANDO,  CONEXAO)

            // QUE VAI RECEBER POR PARAMETRO(s_varDML, obj_Con)

            // A ORDEM A SER EXECUTADA PELO BANCO:
            // s_varDML  UM INSERT PARA POPULAR OS PARAMETROS
            // E UM SELECT PARA DEFINIR O ID COM O NUMERO CORRENTE DA ORDEM DAS CRIACOES DOS OBJETOS

            // E OS PARAMETROS DA CONEXAO:
            // obj_Con @..... PARA O BANCO RECEBER E VALIDAR:

            //          "Data Source = (LocalDB)\MSSQLLocalDB;  NOME DO BANCO

            //          AttachDBFilename = C:\Users...          CAMINHO DO ARQUIVO .mdf

            //          Integrated Security = true;             USA A IDENTIDADE ATUAL DO WINDOWS ESTABELECIDA NO THREAD DO O.S.

            //          Connect Timeout = 10";                  TEMPO LIMITE PARA ESTABELECER UMA CONEXÃO COM O DB





            // CRIADO O obj_Cmd, É PRECISO AGORA POPULAR OS PARAMETROS:

            //      @S_NM_ASSOCIADO   COM  pobj_Associado.Nm_Associado
            //      @S_GEN_ASSOCIADO  COM  pobj_Associado.Gen_Associado
            //      @S_MAIL_ASSOCIADO COM  pobj_Associado.Mail_Associado
            //      @S_CEL_ASSOCIADO  COM  pobj_Associado.Cel_Associado
            //      @S_CPF_ASSOCIADO  COM  pobj_Associado.CPF_Associado

            // LEMBRANDO QUE pobj_Associado É UM PARAMETRO QUE VAI RECEBER
            // NA TELA DO USUÁRIO AS INFORMACOES QUE ELE DIGITAR.


            obj_Cmd.Parameters.AddWithValue("@S_NM_ASSOCIADO", pobj_Associado.Nm_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_GEN_ASSOCIADO", pobj_Associado.Gen_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_ASSOCIADO", pobj_Associado.Mail_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_ASSOCIADO", pobj_Associado.Cel_Associado);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_ASSOCIADO", pobj_Associado.CPF_Associado);

            //      NA s_var_DML FICARIAM ASSIM OS PARAMETROS:
            //
            //      "INSERT INTO TB_ASSOCIADO " +
            //      "( " +
            //      "S_NM_ASSOCIADO, " +
            //      "S_GEN_ASSOCIADO, " +
            //      "S_MAIL_ASSOCIADO, " +
            //      "S_CEL_ASSOCIADO, " +
            //      "S_CPF_ASSOCIADO " +
            //      ") " +
            //      "VALUES " +
            //      "( " +                          EXEMPLO DE USUARIO:
            //      "leandro de paula bastos, " +               
            //      "masculino, " +              
            //      "leandro.pb.estudos@gmail.com, " +             
            //      "16999999999, " +
            //      "32145678912 " +
            //      "); " +
            //      "SELECT IDENT_CURRENT ('TB_ASSOCIADO') AS ID_CURRENT";

            try
            {
                obj_Con.Open();  // ABRE A CONEXAO COM O BANCO

                Id = Convert.ToInt16(obj_Cmd.ExecuteScalar());
                //  ExecuteScalar() retorna uma consulta de quantas linhas e colunas estiverem salvas no banco

                obj_Con.Close(); // FECHA A CONEXAO COM O BANCO

                return Id; // RETORNA UM RESULTADO INT E SALVA NA VARIAVAL Id ESTABELICIDA NO INICIO DA FUNCAO
            }
            catch (Exception erro)   // EXCESSAO OU TRATAMENTO DE ERROS
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Id;
            }
        }
        #endregion // terminado //terminado
        // ok

        #region Método Alterar()

        /****************************************************************
        *  NOME DO MÉTODO: Alterar
        *       DESCRIÇÃO: Responsável por Alterar o registro na tabela.
        *     DT. CRIAÇÃO: 05/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        //  CRIAR UMA FUNCAO PUBLICA BOOLEANA COM OS PARAMETROS (OBJETO, PAR_OBJETO)
        //  {
        //
        //  Item - 1.CRIAR UMA VARIAVEL BOOLEANA CHAMADA ALTERADO QUE RECEBE = FALSE;
        //  
        //  Item - 2.CRIAR UM OBJETO DE CONEXAO UTILIZANDO A CLASSE SqlConnection DERIVADA DA BIBLIOTECA using System.Data.SqlClient;
        //
        //  Item - 3.CRIAR UMA VARIAVEL STRING CONTENDO O COMANDO UPDATE ESCRITO DENTRO DELA;
        //  
        //  string s_varDML = "UPDATE TB_ASSOCIADO SET " +
        //                    "S_NM_ASSOCIADO  = @S_NM_ASSOCIADO, " +
        //                    "S_GEN_ASSOCIADO = @S_GEN_ASSOCIADO, " +
        //                    "S_MAIL_ASSOCIADO= @S_MAIL_ASSOCIADO, " +
        //                    "S_CEL_ASSOCIADO = @S_CEL_ASSOCIADO, " +
        //                    "S_CPF_ASSOCIADO = @S_CPF_ASSOCIADO " +
        //                    "WHERE I_COD_ASSOCIADO = @I_COD_ASSOCIADO ";
        //
        //
        //  ,
        //  Item - 4.CRIAR UM OBJETO DA CLASSE SqlCommand Ex: SqlCommand obj_Cmd = new SqlCommand(s_varDML, obj_Con);
        //  CONTENDO POR PARAMETRO( STRING CONTENDO UPDATE(item3) ,  OBJETO COM A STRING DE CONEXAO(item2) )
        //
        //  Passo - 5. POPULAR 
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //  }
        //  .
        #endregion


        #region Método Excluir()

        /****************************************************************
        *  NOME DO MÉTODO: Excluir
        *       DESCRIÇÃO: Responsável por Excluir o registro na tabela.
        *     DT. CRIAÇÃO: 05/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public bool Excluir(Associado pobj_Associado)
        {
            bool b_Excluido = false;

            //(05/07/2022 - mfacine) - Criar a Classe Connection
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
        *     DT. CRIAÇÃO: 25/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Associado FindByCodAssociado(Associado pobj_Associado)
        {
            //(25/07/2022 - mfacine) - Criar a Classe Connection
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
        *     DT. CRIAÇÃO: 25/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Associado> FindAllAssociado()
        {
            //(25/07/2022 - mfacine) - Criar a Classe Connection
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