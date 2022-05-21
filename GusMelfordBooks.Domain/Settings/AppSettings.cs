using GusMelfordBooks.Infrastructure.Settings;

namespace GusMelfordBooks.Domain.Settings;

public class AppSettings
{
    public AuthOptions? AuthOptions { get; set; }
    public DatabaseSettings? DatabaseSettings { get; set; }
}