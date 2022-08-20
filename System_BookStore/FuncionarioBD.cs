/****************************************************************
 *  NOME DA CLASSE: FuncionarioBD
 *       DESCRIÇÃO: Representação da classe de Banco FuncionarioBD
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
    class FuncionarioBD
    {
        // Método Destruct
        ~FuncionarioBD() { }

        #region Método Incluir()
        /****************************************************************
        *  NOME DO MÉTODO: Incluir
        *       DESCRIÇÃO: Responsável por incluir o registro na tabela.
        *     DT. CRIAÇÃO: 05/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/

        public int Incluir(Funcionario pobj_Funcionario)
        {
            // CRIE UMA VARIAVEL QUE RECEBERA UM NUMERO ALEATORIO PARA O Cod. Id DO FUNCIONARIO
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

            //      @S_NM_FUNCIONARIO   COM  pobj_Funcionario.Nm_Funcionario
            //      @S_LOG_FUNCIONARIO  COM  pobj_Funcionario.Gen_Funcionario
            //      @S_PASS_FUNCIONARIO COM  pobj_Funcionario.Mail_Funcionario
            //      @S_CEL_FUNCIONARIO  COM  pobj_Funcionario.Cel_Funcionario
            //      @S_CPF_FUNCIONARIO  COM  pobj_Funcionario.CPF_Funcionario

            // LEMBRANDO QUE pobj_Funcionario É UM PARAMETRO QUE VAI RECEBER
            // NA TELA DO USUÁRIO AS INFORMACOES QUE ELE DIGITAR.


            obj_Cmd.Parameters.AddWithValue("@S_NM_FUNCIONARIO", pobj_Funcionario.Nm_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_LOG_FUNCIONARIO", pobj_Funcionario.Log_Funcionario);
            obj_Cmd.Parameters.AddWithValue("@S_PASS_FUNCIONARIO", pobj_Funcionario.Pass_Funcionario);

            //      NA s_var_DML FICARIAM ASSIM OS PARAMETROS:
            //
            //      "INSERT INTO TB_FUNCIONARIO " +
            //      "( " +
            //      "S_NM_FUNCIONARIO, " +
            //      "S_LOG_FUNCIONARIO, " +
            //      "S_PASS_FUNCIONARIO, " +
            //      "S_CEL_FUNCIONARIO, " +
            //      "S_CPF_FUNCIONARIO " +
            //      ") " +
            //      "VALUES " +
            //      "( " +                          EXEMPLO DE USUARIO:
            //      "leandro de paula bastos, " +               
            //      "masculino, " +              
            //      "leandro.pb.estudos@gmail.com, " +             
            //      "16999999999, " +
            //      "32145678912 " +
            //      "); " +
            //      "SELECT IDENT_CURRENT ('TB_FUNCIONARIO') AS ID_CURRENT";

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
        //  string s_varDML = "UPDATE TB_FUNCIONARIO SET " +
        //                    "S_NM_FUNCIONARIO  = @S_NM_FUNCIONARIO, " +
        //                    "S_LOG_FUNCIONARIO = @S_LOG_FUNCIONARIO, " +
        //                    "S_PASS_FUNCIONARIO= @S_PASS_FUNCIONARIO, " +
        //                    "S_CEL_FUNCIONARIO = @S_CEL_FUNCIONARIO, " +
        //                    "S_CPF_FUNCIONARIO = @S_CPF_FUNCIONARIO " +
        //                    "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO ";
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
        public bool Excluir(Funcionario pobj_Funcionario)
        {
            bool b_Excluido = false;

            //(05/07/2022 - mfacine) - Criar a Classe Connection
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
        *     DT. CRIAÇÃO: 25/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public Funcionario FindByCodFuncionario(Funcionario pobj_Funcionario)
        {
            //(25/07/2022 - mfacine) - Criar a Classe Connection
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
        *     DT. CRIAÇÃO: 25/07/2022
        *   DT. ALTERAÇÃO: --/--/---- ( -- )
        *      CRIADA POR: mFacine (Monstro)
        *      OBSERVAÇÃO: Utiliza a Classe Connection para acessar o BD.
        ***************************************************************/
        public List<Funcionario> FindAllFuncionario()
        {
            //(25/07/2022 - mfacine) - Criar a Classe Connection
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