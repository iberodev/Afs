using System;

namespace Afs.Diego.Data.Exceptions
{
    public class SettingsNotFoundException : Exception
    {
        public SettingsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public SettingsNotFoundException(string message) : base(message)
        {

        }
    }
}
