using System;
using System.Collections.Generic;

namespace SimplExServer.Model
{
    public class Theme : ICloneable
    {
        public string ThemeName { get; set; } = string.Empty;
        public object Clone() => MemberwiseClone();
    }
}
