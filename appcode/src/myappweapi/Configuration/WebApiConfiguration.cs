namespace myappwebapi.Configuration;

using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using myappwebapi.Infrastructure.Auth;

public class myappwebapiConfiguration
{
    public static bool IsProduction() => EnvironmentName == Environments.Production;
    public static bool IsDevelopment() => EnvironmentName == Environments.Development;
    public static bool IsTest() => EnvironmentName == Environments.Staging;
    private static readonly string? EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    public string ApplicationUrl { get; set; } = string.Empty;

    public ConnectionStringConfiguration ConnectionStrings { get; set; } = new();
    public KeycloakConfiguration Keycloak { get; set; } = new();

    public SplunkConfiguration SplunkConfig { get; set; } = new SplunkConfiguration();


    // ------- Configuration Objects -------

    public class SplunkConfiguration
    {
        public string Host { get; set; } = string.Empty;
        public string CollectorToken { get; set; } = string.Empty;
    }



    public class ConnectionStringConfiguration
    {
        public string myappwebapiDatabase { get; set; } = string.Empty;
    }

    public class TelemeteryConfiguration
    {
        public string CollectorUrl { get; set; } = string.Empty;
        public bool LogToConsole { get; set; }

    }



    public class KeycloakConfiguration
    {
        public string RealmUrl { get; set; } = string.Empty;
        public string WellKnownConfig => KeycloakUrls.WellKnownConfig(this.RealmUrl);
        public string TokenUrl => KeycloakUrls.Token(this.RealmUrl);
        public string AdministrationUrl { get; set; } = string.Empty;
        public string AdministrationClientId { get; set; } = string.Empty;
        public string myappwebapiClientId { get; set; } = string.Empty;
        public string AdministrationClientSecret { get; set; } = string.Empty;
        public string BirthdateField { get; set; } = "birthdate";
    }


}
