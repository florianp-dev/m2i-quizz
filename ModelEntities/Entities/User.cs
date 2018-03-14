/// <remarks>
/// Florian POUCHELET
/// </remarks>

namespace ModelEntities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Society { get; set; }
        public bool IsAdmin { get; set; }

        public User(string fName, string lName, string pwd, bool isAdmin)
        {
            FirstName = fName;
            LastName = lName;
            Password = pwd;
            IsAdmin = isAdmin;
        }
    }
}
