namespace SimplExServer.Model
{
    public class Theme
    {
        public string ThemeName { get; set; } = string.Empty;
        public override string ToString() => $"{ThemeName}";
    }
}
