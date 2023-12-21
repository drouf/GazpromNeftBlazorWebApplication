using Blazored.Modal;
using GazpromNeftBlazorWebApplication;
using GazpromNeftBlazorWebApplication.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using GazpromNeftBlazorWebApplication.Components.Pages;
using GazpromNeftBlazorWebApplication.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddTransient<ApiService, GazpromNeftApiService>();
builder.Services.AddSingleton(x => new ApiEndpointManagerService() 
    { ApiEndpoints = new List<ApiEndpoint>() { 
        new ApiEndpoint() { EndpointName = "User", EndpointUrl = "http://172.19.0.3:8080/User"} 
    } 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
