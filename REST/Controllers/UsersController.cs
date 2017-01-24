using REST.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
namespace REST.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private static List<User> Users { get; set; }
        static UsersController()
        {
            UsersController.CreateTestUsers();
        }
        private static void CreateTestUsers()
        {
            UsersController.Users = new List<User>() {
                new User("TU","Tran", 20,"Male"),
                new User("TU 1","Tran", 20,"Male")
            };
        }
        [Route("")]
        [HttpGet()]
        public IList<User> GetUsers() {
            return UsersController.Users;
        }

        [HttpGet]
        [Route("{userId}")]
        public User GetUser(Guid userId) {
            return UsersController.Users.Find(user => user.Id == userId);
        }

        [HttpPost]
        [Route("")]
        public User CreateUser(User user) {
            user.Id = Guid.NewGuid();
            UsersController.Users.Add(user);
            return user;
        }
        [HttpPost]
        [Route("{userId}")]
        public void UpdateUser(Guid userId, User user) {
            Models.User currentUser = UsersController.Users.Find(item => item.Id==userId);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Age = user.Age;
            currentUser.Gender = user.Gender;
        }
   }
}
