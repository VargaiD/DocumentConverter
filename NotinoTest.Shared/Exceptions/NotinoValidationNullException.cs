using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Shared.Exceptions
{
    public class NotinoValidationNullException : ArgumentNullException
    {
        public NotinoValidationNullException(string? paramName) : base(paramName)
        {
        }
    }
}
