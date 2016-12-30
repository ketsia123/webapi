namespace WebApi.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "user")]
    public class User
    {
        public User(int id, string firstName, string lastName, string sex, int age)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = sex;
            this.Age = age;
        }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "gender")]
        public string Gender { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
    }
}