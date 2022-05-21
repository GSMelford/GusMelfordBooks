using GusMelfordBooks.API;
using GusMelfordBooks.API.Middlewares;
using GusMelfordBooks.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);
AppSettings appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);
builder.Services.AddServices(appSettings);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
WebApplication app = builder.Build();

if (builder.Environment.IsDevelopment())  
{  
    app.UseDeveloperExceptionPage();  
}  
else  
{
    app.UseHsts();  
}
 
app.UseMiddleware(typeof(ExceptionMiddleware));
app.UseDefaultFiles();
app.UseStaticFiles();
 
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseEndpoints(endpoints => { endpoints.MapHealthChecks("/health"); });
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();