using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using dotenv.net;
using RockstarsIT_BLL;
using RockstarsIT_BLL.Interfaces;
using RockstarsIT_DAL;
using RockstarsIT_DAL.Data;
using RockstarsIT_DAL.Entities;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = DotEnv.Read()["DEFAULT_CONNECTION"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<UserEntity>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SurveyService>();
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();

builder.Services.AddScoped<SquadService>();
builder.Services.AddScoped<ISquadRepository, SquadRepository>();

builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();



builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Survey}/{action=Index}");
app.MapRazorPages();

app.Run();