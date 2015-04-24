using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SerialMate
{
    class netCheck
    {
        public static bool CheckForInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://internetlabs.eu"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
