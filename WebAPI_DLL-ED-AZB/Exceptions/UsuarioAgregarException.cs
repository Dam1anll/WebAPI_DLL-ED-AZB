using System;

namespace WebAPI_DLL_ED_AZB.Exceptions
{
    public class UsuarioAgregarException : Exception
    {
        public UsuarioAgregarException(string message) : base(message)
        {
        }

        public UsuarioAgregarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
