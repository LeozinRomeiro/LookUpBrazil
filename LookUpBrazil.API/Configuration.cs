namespace LookUpBrazil.Api
{
    public class Configuration
    {
        public static string UrlIbgeMunicipios = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios?orderBy=nome";
        public static string HttpClientName = "IbgeMunicipios";
        public static string JwtKey { get; set; } = "leo";
        public static string NameApi = "Chave Secreta";
        public static string KeyApi = "fds34dsd2354ewfrw";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public string Password { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
        }
    }
}
