using System;

namespace WebAPI_DLL_ED_AZB.Exceptions
{
    public class SensorTipoException : Exception
    {
        public string SensorNombre { get; set; }

        public SensorTipoException()
        {

        }

        public SensorTipoException(string message) : base(message)
        {

        }

        public SensorTipoException(string message, Exception inner) : base(message, inner)
        {

        }

        public SensorTipoException(string message, string sensorNombre) : this(message)
        {
            SensorNombre = sensorNombre;
        }
    }
}
