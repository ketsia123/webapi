namespace WebApi.Controllers
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private static IList<User> Users { get; set; }
        static UsersController()
        {
            UsersController.Users = new List<User>() {
                new User(1, "User", "1", "Male", 20),
                new User(2, "User", "2", "Male", 20),
            };

        }
        [Route("")]
        [HttpGet()]
        public IList<User> GetUsers()
        {
            return UsersController.Users;
        }

        [Route("{userId}")]
        [HttpGet()]
        public User GetUser(int userId)
        {
            return UsersController.Users.FirstOrDefault(item => item.Id == userId);
        }

        [Route("")]
        [HttpPost()]
        public User CreateUser([FromBody]User user)
        {
            user.Id = UsersController.Users.Count + 1;
            UsersController.Users.Add(user);
            return user;
        }

        [Route("{userId}")]
        [HttpPut()]
        public void UpdateUser(int userId, [FromBody]User user)
        {
            User currentUser = UsersController.Users.FirstOrDefault(item => item.Id == userId);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Gender = user.Gender;
            currentUser.Age = user.Age;
        }

        [Route("{userId}")]
        [HttpDelete()]
        public User DeleteUser(int userId)
        {
            User currentUser = UsersController.Users.FirstOrDefault(item => item.Id == userId);
            UsersController.Users.Remove(currentUser);
            return currentUser;
        }
    }
}
