/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System;
using System.Text.RegularExpressions;

namespace ModelEntities
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Tel { get; set; }
        Email EmailAddress { get; set; }
        string Password { get; }
    }

    public struct Email
    {
        static string pattern = @"\w+@\w+\.\w+";
        string value;

        public Email(string pValue)
        {
            value = null;
            if (!isValidPwd(pValue))
                throw new ArgumentException("L'email entré n'est pas un email valide");
            value = pValue;
        }

        private bool isValidPwd(string pwd)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            Match m = r.Match(pwd);

            return m.Success;   
        }
    }
}
