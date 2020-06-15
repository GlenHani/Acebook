﻿using Acebook.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acebook.UnitTest
{
    [TestClass]
    public class AuthoTest
    {
        [TestMethod]
        public void SignInReturnTrue()
        {

            // Arrange

            var password = "MGzYMsUyPHfnIfSDNsdRrQ==";
            var userPasswordEntered = "Test";
            var validate = new AuthoRepository();

            // Act

            var result = validate.SignInValidation(password, userPasswordEntered);

            // Assert


            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void SignInReturnFalse()
        {

            // Arrange

            var password = "MGzYMsUyPHfnIfSDNsdRrQ==";
            var userPasswordEntered = "test";
            var validate = new AuthoRepository();

            // Act

            var result = validate.SignInValidation(password, userPasswordEntered);

            // Assert


            Assert.AreEqual(false, result);

        }


    }
}
