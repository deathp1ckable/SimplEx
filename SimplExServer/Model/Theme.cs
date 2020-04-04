using System;
namespace SimplExServer.Model
{
    public class Theme : ICloneable
    {
        public int ThemeNumber { get; set; }
        public string ThemeName { get; set; } = string.Empty;
        public object Clone() => MemberwiseClone();
    }
}
