using Blazored.LocalStorage;
using Blazored.Toast;
using LeaveManagement.UI;
using LeaveManagement.UI.Services;
using LeaveManagement.UI.Services.IServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7145/") });
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();

await builder.Build().RunAsync();
