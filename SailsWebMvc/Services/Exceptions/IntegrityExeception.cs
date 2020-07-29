using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityExeception :ApplicationException
    {
        public IntegrityExeception(string message) : base(message)
        {

        }
    }
}
