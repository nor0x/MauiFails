using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFails
{
    public class MyService
    {
        public string GetNowString()
        {
            return DateTime.Now.ToString();
        }
    }
}
