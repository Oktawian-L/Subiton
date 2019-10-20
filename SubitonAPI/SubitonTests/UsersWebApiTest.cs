using AutoMapper;
using Moq;
using SubitonAPI.Controllers;
using SubitonAPI.Data;
using SubitonAPI.Models;
using SubitonTests.DummyData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

using Moq;

namespace SubitonTests
{
    public class UsersWebApiTest
    {
        [Fact]
        public void Users_GetExisting()
        {
            var mock = new Mock<IUserRepository>();
            var mockedMapper = new Mock<IMapper>();
            //mock.Setup(p => p.GetUser(1)).Returns(userMocked);
            UsersController home = new UsersController(mock.Object, mockedMapper.Object);
            var result = home.GetUser(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddingMethodsCorrectResult()
        {
            var expectedResult = 4;
            var a = 2;
            var b = 2;

            var result = a + b;

            Assert.IsType<int>(result);
            Assert.Equal(result, expectedResult);
        }
    }
}