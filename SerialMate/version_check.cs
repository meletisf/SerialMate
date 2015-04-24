using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialMate
{
    class version_check
    {
        public string Version { get; private set; }
        public string Date { get; private set; }
        public string Changelog { get; private set; }

        public version_check(string version, string date, string changelog)
        {
            Version = version;
            Date = date;
            Changelog = changelog;
        }

        public override string ToString()
        {
            return Changelog;
        }
    
    }
}
