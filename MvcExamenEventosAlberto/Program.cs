using Amazon.S3;
using MvcExamenEventosAlberto.Helpers;
using MvcExamenEventosAlberto.Models;
using MvcExamenEventosAlberto.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

string jsonSecrets =
    HelperSecretManager.GetSecretsAsync().GetAwaiter().GetResult();
            KeysModels keysModel =

    JsonConvert.DeserializeObject<KeysModels>(jsonSecrets);

builder.Services.AddSingleton<KeysModels>(x => keysModel);

// Add services to the container.
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddTransient<ServiceEventos>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
