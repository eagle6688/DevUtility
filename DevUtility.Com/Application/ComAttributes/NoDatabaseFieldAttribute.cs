using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Application.ComAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class NoDatabaseFieldAttribute : Attribute
    {
    }
}