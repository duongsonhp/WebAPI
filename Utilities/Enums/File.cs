using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Enums
{
    public class File
    {
        public enum Operator
        {
            Read = 0,
            Write = 1,
            Remove = 2
        }

        public enum ConfigurationFile
        {
            ConnectionConfiguration = 0,
            ConnectionConfiguration2 = 1
        }

        public enum LogFile
        {
            ErrorLog = 0
        }
    }
}
