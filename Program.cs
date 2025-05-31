using Microsoft.EntityFrameworkCore;
using QuizGame.Components;
using QuizGame.Data;
using QuizGame.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("PostgresConnection") ?? 
                       throw new InvalidOperationException("Connection string 'PostgresConnection'" +
                                                           " not found.");

builder.Services.AddDbContextFactory<QuizGameDbContext>((DbContextOptionsBuilder options) => 
    options.UseNpgsql(connectionString));

builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();