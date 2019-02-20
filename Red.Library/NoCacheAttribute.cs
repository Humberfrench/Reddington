using System;
using System.Web.Mvc;

namespace Red.Library
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : OutputCacheAttribute
    {
        public NoCacheAttribute()
        {
            Duration = 1;
        }
    }
}