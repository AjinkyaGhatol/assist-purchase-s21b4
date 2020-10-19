﻿using System.Collections.Generic;
using Xunit;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Backend.Repository;

namespace BackendControllersTests
{
    public class MailAlerterControllerTests
    {
        readonly DataModels.CustomerModel _customer = new DataModels.CustomerModel()
        {
            CustomerId = "219",
            CustomerName = "random_name",
            CustomerEmailId = "random_email@gmail.com",
            CustomerPhoneNumber = "12345678",
            DeviceId = "VUEX3"
        };
        Backend.Controllers.MailAlertController _controller = new Backend.Controllers.MailAlertController(new MailAlerterRepository());       
        [Fact]
        public void TestExpectingNewCustomerToBeAddedIfItDoesnotExist()
        {
            Assert.Equal("New Customer", _controller.CustomerAuthentication(_customer));
        }
        [Fact]
        public void TestExpectingExistingCustomerToBeAuthenticatedIfItExists()
        {
            _controller.CustomerAuthentication(_customer);
            Assert.Equal("Existing Customer", _controller.CustomerAuthentication(_customer));
        }
    }
}
