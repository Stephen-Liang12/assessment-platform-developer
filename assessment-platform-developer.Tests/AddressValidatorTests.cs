using assessment_platform_developer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace assessment_platform_developer.Tests
{
	[TestClass]
	public class AddressValidatorTests
	{
		[TestMethod]
		public void AbleToReturnTrueForValidUSZipCode1()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "12345", Models.Countries.UnitedStates);
			Assert.IsTrue(addressValidator.ValidateAddress(address).Item1);
		}

		[TestMethod]
		public void AbleToReturnTrueForValidUSZipCode2()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "12345-1234", Models.Countries.UnitedStates);
			Assert.IsTrue(addressValidator.ValidateAddress(address).Item1);
		}

        [TestMethod]
        public void AbleToReturnFalseForEmptyUSZipCode()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "", Models.Countries.UnitedStates);
			Assert.IsFalse(addressValidator.ValidateAddress(address).Item1);
		}

        [TestMethod]
        public void AbleToReturnFalseForInvalidUSZipCode()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "1-1", Models.Countries.UnitedStates);
			Assert.IsFalse(addressValidator.ValidateAddress(address).Item1);
		}

		[TestMethod]
		public void AbleToReturnTrueForValidCanadaZipCode1()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "A1A1A1", Models.Countries.Canada);
			Assert.IsTrue(addressValidator.ValidateAddress(address).Item1);
		}

		[TestMethod]
		public void AbleToReturnTrueForValidCanadaZipCode2()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "A1A 1A1", Models.Countries.Canada);
			Assert.IsTrue(addressValidator.ValidateAddress(address).Item1);
		}

        [TestMethod]
        public void AbleToReturnFalseForEmptyCanadaZipCode()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "", Models.Countries.Canada);
			Assert.IsFalse(addressValidator.ValidateAddress(address).Item1);
		}

        [TestMethod]
        public void AbleToReturnFalseForInvalidCanadaZipCode1()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "1-1", Models.Countries.Canada);
			Assert.IsFalse(addressValidator.ValidateAddress(address).Item1);
		}

        [TestMethod]
        public void AbleToReturnFalseForInvalidCanadaZipCode2()
		{
			var addressValidator = new AddressValidator();
			var address = AddressFactory.CreateAddressInformation(string.Empty, string.Empty, 1, "A1A1A111", Models.Countries.Canada);
			Assert.IsFalse(addressValidator.ValidateAddress(address).Item1);
		}
	}
}
