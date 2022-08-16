using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_BookStore
{
    class FuncGeral
    {
		/************************************************************************
					Método: StatusBtn
				 Parametro: Formulario Ativo e a varíavel int
					   obs: Responsável por trazer o status do botão
							na tela passado por parametro.

							Status (1, 2 ou 3)
							1 - 
							2 -	
							3 - 


		 */
		public void StatusBtn(Form pobj_Form, int p_Status)
        {
			foreach (Control pnl in pobj_Form.Controls)
            {
				if(pnl is Panel && pnl.Name == "pnl_Buttons")
                {
					foreach (Control btn in pnl.Controls)
                    {
						switch (p_Status)
                        {
							case 1:
                                {
									if (btn.Name == "btn_Novo")
                                    {
										btn.Enabled = true;
                                    }

									if (btn.Name == "btn_Alterar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Excluir")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Confirmar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Cancelar")
									{
										btn.Enabled = false;
									}
									break;
								}
								
							case 2:
                                {
									if (btn.Name == "btn_Novo")
									{
										btn.Enabled = true;
									}

									if (btn.Name == "btn_Alterar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Excluir")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Confirmar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Cancelar")
									{
										btn.Enabled = false;
									}
									break;
                                }
							case 3:
                                {
									if (btn.Name == "btn_Novo")
									{
										btn.Enabled = true;
									}

									if (btn.Name == "btn_Alterar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Excluir")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Confirmar")
									{
										btn.Enabled = false;
									}

									if (btn.Name == "btn_Cancelar")
									{
										btn.Enabled = false;
									}
									break;
								}
                        }
                    }
                }
            }
        }







	}
}
