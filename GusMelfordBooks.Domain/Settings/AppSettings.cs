using GusMelfordBooks.Infrastructure.Settings;

namespace GusMelfordBooks.Domain.Settings;

public class AppSettings
{
    public string AdminEmail { get; set; }
    public string AdminPassword { get; set; }
    public AuthOptions? AuthOptions { get; set; }
    public DatabaseSettings? DatabaseSettings { get; set; }
}