namespace MailSender.Mail
{
    /// <summary>
    /// Declares names of the settings
    /// </summary>
    public static class EmailSettingNames
    {
        public const string DefaultFromAddress = "mehmet@perk.com";

        public const string DefaultFromDisplayName = "";

        public static class Smtp
        {
            public const string Host = "";

            public const string Port = "";

            public const string UserName = "";

            public const string Password = "";

            public const string Domain = "";

            public const string EnableSsl = "";

            public const string UseDefaultCredentials = "";
        }
    }
}