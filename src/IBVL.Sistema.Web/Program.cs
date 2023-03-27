using IBVL.Sistema.Data.Identity;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using IBVL.Sistema.Ioc.DependencyInjectionConfig;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfraStructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

AddUsuarioPadrao(app);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
 void AddUsuarioPadrao(WebApplication app)
{
    ArgumentNullException.ThrowIfNull(app, nameof(app));

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var contextUser = services.GetRequiredService<UserManager<ApplicationUser>>();
        var contextRole = services.GetRequiredService<RoleManager<IdentityRole>>();
        DbInitializer.Initialize(contextUser, contextRole).Wait();
    }
    catch (Exception ex)
    {

    }


}

    internal class DbInitializer
{
    public static async Task Initialize(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
    {

        if (_roleManager.Roles.Any()) return;

        var admin = new IdentityRole
        {
            Name = "admin",
            NormalizedName = "admin".ToUpper()
        };
        await _roleManager.CreateAsync(admin);

        var getente = new IdentityRole
        {
            Name = "gerente",
            NormalizedName = "gerente".ToUpper()
        };
        await _roleManager.CreateAsync(getente);


        if (_userManager.Users.Any()) return;

        var usuarioAdmin = new ApplicationUser
        {
            Email = "admin.ibvl@ibvl.com.br",
            UserName = "admin",
            NormalizedUserName="ADMIN",
            NormalizedEmail = "admin.ibvl@ibvl.com.br".ToUpper(),
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        var usuarioAdminResult = await _userManager.CreateAsync(usuarioAdmin, "@AdminIBVL1");

        if (usuarioAdminResult.Succeeded)
        {
            await _userManager.AddToRoleAsync(usuarioAdmin, "admin");
        }


        var usuarioGerente = new ApplicationUser
        {
            Email = "gerente.ibvl@ibvl.com.br",
            NormalizedEmail = "gerente.ibvl@ibvl.com.br".ToUpper(),
            UserName = "gerente",
            NormalizedUserName = "gerente",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        var usuarioResult = await _userManager.CreateAsync(usuarioGerente, "@GerenteIBVL2");

        if (usuarioResult.Succeeded)
        {
            await _userManager.AddToRoleAsync(usuarioGerente, "gerente");
        }

    }
}