using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotinoTest.Shared.Exceptions
{
    public class NotinoValidationException : ArgumentException
    {
        public NotinoValidationException(string? message) : base(message)
        {
        }
    }
}
