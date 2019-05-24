using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanNS
{
    public class Iban
    {

		protected string calcularIban(string ccc)
		{
			// Calculamos el IBAN
			ccc = ccc.Trim();
			if (ccc.Length != 20)
			{
				return "La CCC debe tener 20 dígitos";
			}
			// Le añadimos el codigo del pais al ccc
			ccc = ccc + "142800";

			// Troceamos el ccc en partes (26 digitos)
			string[] partesCCC = new string[5];
			partesCCC[0] = ccc.Substring(0, 5);
			partesCCC[1] = ccc.Substring(5, 5);
			partesCCC[2] = ccc.Substring(10, 5);
			partesCCC[3] = ccc.Substring(15, 5);
			partesCCC[4] = ccc.Substring(20, 6);

			int iResultado = int.Parse(partesCCC[0]) % 97;
			string resultado = iResultado.ToString();
			for (int i = 0; i & lt; partesCCC.Length - 1; i++)
{
				miResultado = int.Parse(resultado + partesCCC[i + 1]) % 97;
				resultado = iResultado.ToString();
			}
			// Le restamos el resultado a 98
			int iRestoIban = 98 - int.Parse(resultado);
			string restoIban = iRestoIban.ToString();
			if (restoIban.Length == 1)
				restoIban = "0" + restoIban;

			return "ES" + restoIban + ccc;
		}
	}
}
