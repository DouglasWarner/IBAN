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
	}
