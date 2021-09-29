using MenuUssd.App.Interfaces;
using MenuUssd.App.Models;
using MenuUSSD.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuUSSD.App.Implementations
{
    public class MenusUSSDApp : IMenuApp
    {
        string response = string.Empty;
        private readonly IHandlerApp _handler;
        private readonly static string _errorContent = "END Erro!";

        public MenusUSSDApp(IHandlerApp handler)
        {
            _handler = handler;
        }
        public string Main(UssdModel model)
        {
          
            try
            {
                int[] backarr = _handler.Back(model.Text);


                switch (backarr.Length)
                {
                    case 0:
                        response = "CON Menus USSD\n";
                        response += "1-> Navegar\n";
                        response += "0-> Sair";

                        return response;
                    
                    case 1:
                        switch (backarr[0])
                        {
                            case 1:
                                response = "CON Menus USSD\n";
                                response += "O seu teleone é "+ model.PhoneNumber+ "\n";
                                response += "0-> Pagina Inicial";

                                return response;
                            default:
                                response += "END Menu Terminado";
                                break;
                        }
                        return response;
                    case 2:

                    case 4:
                        // code block
                        break;
                    default:
                        // code block
                        break;
                }




                return _errorContent;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex?.Message);
                return _errorContent;
            }
        }
    }
}
