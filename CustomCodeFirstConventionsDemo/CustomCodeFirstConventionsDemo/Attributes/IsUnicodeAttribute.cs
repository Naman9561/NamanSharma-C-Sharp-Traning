using System;

namespace CustomCodeFirstConventionsDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class IsUnicodeAttribute : Attribute
    {
        public bool Unicode { get; }

        public IsUnicodeAttribute(bool isUnicode) => Unicode = isUnicode;
    }
}
