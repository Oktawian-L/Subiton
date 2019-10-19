using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SubitonAPI.Controllers;
using SubitonAPI.Data;

using System;

using Xunit;
using SubitonAPI.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SubitonTests.DummyData
{
    public class UserRepositoryDummy : IUserRepository
    {
        private readonly List<User> _expectedUsers;

        public UserRepositoryDummy()
        {
            _expectedUsers = new List<User>()
            {
                /*new ShoppingItem() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Manufacturer="Orange Tree", Price = 5.00M },
                new ShoppingItem() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Manufacturer="Cow", Price = 4.00M },
                new ShoppingItem() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Manufacturer="Uncle Mickey", Price = 12.00M }*/
            };
        }

        public IEnumerable<User> GetAllItems()
        {
            return _expectedUsers;
        }

        private User Add(User newItem)
        {
            newItem.Id = 12;
            _expectedUsers.Add(newItem);
            return newItem;
        }

        public User GetById(int id)
        {
            return _expectedUsers.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _expectedUsers.First(a => a.Id == id);
            _expectedUsers.Remove(existing);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int UserID)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}