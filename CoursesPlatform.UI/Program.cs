
using CoursePlatform.Infrastructure.Data;
using CoursesPlatform.UI.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;


var builder = WebApplication.CreateBuilder(args);

// Services Registration
builder.Services.ServiceConfiguration(builder.Configuration);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});


var app = builder.Build();

// Database Seed
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = new Seed_Category(context);
    seeder.Seed();
}

// Middlewares
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//app.UseHsts();                // 0
app.UseHttpsRedirection();       // 1
app.UseStaticFiles();            // 2
app.UseRouting();                // 3
app.UseAuthentication();         // 4
app.UseAuthorization();          // 5


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}"
     );
});


app.Run();
