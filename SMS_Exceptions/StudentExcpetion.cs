using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Exceptions
{
    public class StudentExcpetion : Exception
    {
        public StudentExcpetion( string errMsg ) : base (errMsg)
        { 

        }
    }
}
