/****************************************************************
 *  NOME DA CLASSE: Connection
 *       DESCRIÇÃO: Representação da classe de conexão com o Banco
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

namespace System_BookStore
{
    class Connection
    {
        //Metodo Destruct
        ~Connection() { }

        /****************************************************************
       *  NOME DO MÉTODO: ConnectionPath
       *       DESCRIÇÃO: Responsável por retornar o Caminho da Conexão.
       *     DT. CRIAÇÃO: 05/07/2022
       *   DT. ALTERAÇÃO: --/--/---- ( -- )
       *      CRIADA POR: 
       ***************************************************************/

        public static string ConnectionPath()
        {
            return @"Data Source = (LocalDB)\MSSQLLocalDB; 
                    AttachDBFilename = C:\csharp\System_BookStore\System_BookStore\BD_BOOKLEND.mdf; 
                    Integrated Security = true; 
                    Connect Timeout = 10;";
        }








    }
}
