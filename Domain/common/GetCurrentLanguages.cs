namespace Domain.common
{
    public static class GetCurrentLanguages
    {
        public static string CurrentLang { get; set; }
        public static string GetCurrentLang() { 
        return CurrentLang;
        }
    }
}
