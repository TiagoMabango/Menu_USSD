using System;
using System.Diagnostics;
using MenuUssd.App.Interfaces;

namespace MenuUssd.App.Implementations
{
    public class HandlerApp : IHandlerApp
    {
        public int[] Request(string arg)
        {
            try
            {
                string[] strSplit = arg.Split('*');

                if (!string.IsNullOrEmpty(strSplit[0]))
                {
                    int[] ussdArr = Array.ConvertAll(strSplit, s => int.Parse(s));

                    return ussdArr;
                }
                return new int[] { };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex?.Message);
                return new int[] { };
            }
        }

        public int[] Back(string arg)
        {
            try
            {
                string[] strSplit = arg.Split('*');
                int arr_Length = strSplit.Length;

                // Verifica se o ultimo digito é igual a 0
                if ((strSplit[arr_Length - 1] == "0" || String.IsNullOrEmpty(strSplit[arr_Length - 1])) && arr_Length >= 2)
                {
                    // Reajustar o array para 1 passo
                    Array.Resize(ref strSplit, arr_Length - 2);
                }
                // Verifica se o ultimo digito é igual a 00
                else if ((strSplit[arr_Length - 1] == "00" || String.IsNullOrEmpty(strSplit[arr_Length - 1])) && arr_Length >= 2)
                {
                    // Reajustar o Array para o inicio
                    Array.Resize(ref strSplit, 0);
                }

                if (strSplit != null)
                {
                    int[] ussdArr = Array.ConvertAll(strSplit, s => int.Parse(s));

                    return ussdArr;
                }

                return new int[] { };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex?.Message);
                return new int[] { };
            }
        }

       
    }
}
