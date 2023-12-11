using System;

namespace WebAPI_DLL_ED_AZB.Exceptions
{
    public class SensorAgregarException : Exception
    {
        public SensorAgregarException(string message) : base(message)
        {
        }

        public SensorAgregarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
