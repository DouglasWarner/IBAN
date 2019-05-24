using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IbanNS
{
	public class ParametrosIncorrectos : ArgumentException { };
	public class LongitudIncorrecta : ArgumentOutOfRangeException { };

	public class Iban
    {
		protected string calcularIban(string ccc)
		{
			if (!ComprobarLongitudCC(ref cc))
				throw new LongitudIncorrecta();
			if (!ComprobarPatronIban(cc))
				throw new ParametrosIncorrectos();

			// ES00 España
			string ES = cc + "142800";

			// Troceamos el ccc en partes (26 digitos)
			string[] partesCC = new string[5];
			TrocearCC(ES, ref partesCC);

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
		private void TrocearCC(string cc, ref string[] partesCC)
		{
			partesCC[0] = cc.Substring(0, 5);
			partesCC[1] = cc.Substring(5, 5);
			partesCC[2] = cc.Substring(10, 5);
			partesCC[3] = cc.Substring(15, 5);
			partesCC[4] = cc.Substring(20, 6);
		}
		private bool ComprobarLongitudCC(ref string cc)
		{
			for (int i = 0; i < cc.Length; i++)
			{
				if (cc[i] == ' ')
					cc = cc.Remove(i, 1);
			}
			if (cc.Length != 20)
				return false;
			return true;
		}
		private bool ComprobarPatronIban(string cc)
		{
			string patron = @"\A[A-Z]{2}[0-9]{22}\Z";
			Regex reg = new Regex(patron);

			return reg.IsMatch(cc);
		}
	}
}
