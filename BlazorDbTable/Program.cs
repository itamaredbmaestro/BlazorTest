using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorDbTable.Data;
using Microsoft.AspNetCore.Hosting;
using BlazorDbTable;
using BlazorDbTable.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<EmployeeVM>();
builder.Services.AddSingleton<EMailsVM>();
builder.Services.AddSingleton<PerformanceVM>();
builder.Services.AddSingleton<HirarchialTreeVM>();
builder.Services.AddSingleton<DuplicatesVM>();

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
