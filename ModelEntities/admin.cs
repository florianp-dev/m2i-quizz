/// <remarks>
/// Florian POUCHELET
/// </remarks>

namespace ModelEntities
{
    public class Admin : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public Email EmailAddress { get; set; }

        private string _password;
        public string Password { get { return _password; } }

        public Admin(string pFName, string pLName, string pwd)
        {
            FirstName = pFName;
            LastName = pLName;
            _password = pwd;
        }

        public Admin(string pFName, string pLName, string pwd, string pTel) : this(pFName, pLName, pwd)
        {
            Tel = pTel;
        }

        public Admin(string pFName, string pLName, string pwd, Email pEmail) : this(pFName, pLName, pwd)
        {
            EmailAddress = pEmail;
        }

        public Admin(string pFName, string pLName, string pwd, string pTel, Email pEmail) : this(pFName, pLName, pwd)
        {
            Tel = pTel;
            EmailAddress = pEmail;
        }

    }
}
