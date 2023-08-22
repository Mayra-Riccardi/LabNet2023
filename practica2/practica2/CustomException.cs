using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2
{
    public class CustomException : Exception
    {
        public CustomException() : base("Mensaje de error Custon Exception") 
        {

        }
    }
}