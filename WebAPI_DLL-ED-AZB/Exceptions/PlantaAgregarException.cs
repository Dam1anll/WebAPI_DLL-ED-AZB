using System;

namespace WebAPI_DLL_ED_AZB.Exceptions
{
    public class PlantaAgregarException : Exception 
    {
        public PlantaAgregarException(string message) : base(message)
        {
        }

        public PlantaAgregarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
