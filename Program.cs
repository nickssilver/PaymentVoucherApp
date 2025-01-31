using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentVoucherApp.Data;
using PaymentVoucherApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders(); // Clear default providers
builder.Logging.AddConsole();     // Add Console logging provider
builder.Logging.AddDebug();       // Optionally add Debug logging provider

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<PaymentVoucherDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the PaymentVoucherService as a scoped service
builder.Services.AddScoped<PaymentVoucherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages(); // For Razor Pages
app.MapBlazorHub();  // For Blazor Server
app.MapFallbackToPage("/_Host"); // Fallback route for Blazor Server

app.Run();