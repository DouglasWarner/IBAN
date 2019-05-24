using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbanNS;
using NUnit.Framework;

namespace IbanNS.Test
{
	[TestFixture]
	public class IbanTest
	{
		private string V = "ES7100302053091234567895";
		private Iban _iban;

		[SetUp]
		public void SetUp()
		{
			_iban = new Iban();
		}
		[Test]
		public void LongitudIbanCorrecto()
		{
			_iban.IBN = V;
			int LongitudMax = 24;

			Assert.AreEqual(LongitudMax, _iban.GetLength());
		}
		[Test]
		public void ValorAntesDePasarIban()
		{
			Assert.AreEqual(null, _iban.IBN);
		}
		[Test]
		public void ComprobarIbanCorrecto()
		{
			Assert.IsTrue(_iban.EsIbanValido(V));
		}
		[Test]
		public void ComprobarIbanEspañaCorrecto()
		{
			_iban.IBN = V;

			Assert.AreEqual("ES", _iban.IBN.Substring(0, 2));
		}
		[Test]
		public void LongitudIncorrecta()
		{
			try
			{
				_iban.EsIbanValido("ES710030203353091234567895");
				Assert.Fail("Falla porque supera la longitud permitida");
			}
			catch (LongitudIncorrecta)
			{
				// Funciona
			}
		}
		[Test]
		public void ParametrosIncorrectos()
		{
			try
			{
				_iban.EsIbanValido("ESAH51328745236541258525");
				Assert.Fail("Falla porque no se paso un iban");
			}
			catch (ParametrosIncorrectos)
			{
				// Funciona
			}
		}
	}
