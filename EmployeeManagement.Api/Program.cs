using EmployeeManagement.Api;

var builder = WebApplication.CreateBuilder(args);

var originPolicy = "originPolicy";

CommonServices.ConfigureDb(builder.Services, builder.Configuration);
CommonServices.ConfigureRepositories(builder.Services);

builder.Services.AddControllers();

// Add services to the container.
// builder.Services.AddRazorPages();


// builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: originPolicy,
        policy =>
        {
            policy.WithOrigins("https://localhost:7076;https://192.168.100.192:7076;");
            policy.AllowCredentials();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithHeaders();
        });
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // app.UseHsts();
}



app.UseRouting();
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.UseCors(originPolicy);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
// app.MapRazorPages();
app.Run();

