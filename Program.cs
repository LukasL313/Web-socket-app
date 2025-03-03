using Microsoft.AspNetCore.ResponseCompression;
using WebSocketApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddResponseCompression(opts => 
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat([ "application/octet-stream" ]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();
app.UseResponseCompression();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<SignalRHub>("/signalrhub");
app.Run();
