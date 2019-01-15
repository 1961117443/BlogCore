using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Common
{
    [AttributeUsage(AttributeTargets.Method,Inherited = true)]
    public class CachingAttribute:Attribute
    {
        public int AbsoluteExpiration { get; set; }
    }
}
