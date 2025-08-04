using StudentsApp.Models;
using System.Linq;

namespace StudentsApp.Helpers
{
    public static class StudentHelper
    {
        public static string GetFullName(Student s)
        {
            return string.Join(" ", new[] { s.First_Name, s.Middle_Name, s.Last_Name }
                .Where(p => !string.IsNullOrEmpty(p)));
        }

        public static string GetInitials(Student s)
        {
            var firstInitial = !string.IsNullOrEmpty(s.First_Name) ? s.First_Name[0].ToString() : "";
            var lastInitial = !string.IsNullOrEmpty(s.Last_Name) ? s.Last_Name[0].ToString() : "";
            return (firstInitial + lastInitial).ToUpper();
        }
    }
}
