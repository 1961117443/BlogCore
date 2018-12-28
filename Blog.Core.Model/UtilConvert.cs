using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core
{
    public static class UtilConvert
    {
        public static long ObjToInt(this object data)
        {
            long l = 0;
            long.TryParse(data.ToString(), out l);
            return l;
        }

        public static string ObjToString(this object data)
        {
            return data.ToString();
        }
    }
}
