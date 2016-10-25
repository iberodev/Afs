namespace Afs.Diego.Common
{
    public static class Constants
    {
        public static class AppSettings
        {
            public const string APP_SETTINGS_FILE_NAME = "appsettings";
            public const string APP_SETTINGS_FILE_EXTENSION = "json";
            public const string APP_SETTINGS_FILE_FULLNAME = APP_SETTINGS_FILE_NAME + "." + APP_SETTINGS_FILE_EXTENSION;
        }

        public static class ApiSettings
        {
            public const string HEADER_MASHAPE_X_KEY = "X-Mashape-Key";
            public const string HEADER_ACCEPT = "Accept";
            public const string HEADER_ACCEPT_TEXT_PLAIN = "text/plain";
        }
    }
}
