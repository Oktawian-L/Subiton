using AutoMapper;
using SubitonAPI.Controllers;
using SubitonAPI.Data;
using SubitonTests.DummyData;
using System;
using Xunit;

namespace SubitonTests
{
    public class UsersWebApiTest
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        private UsersController _usersController;
        private IUserRepository _service;

        public UsersWebApiTest()
        {
            _service = new UserRepositoryDummy();
            _usersController = new UsersController(_service);
        }

        [Fact]
        public void AddingMethods_CorrectResult()
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