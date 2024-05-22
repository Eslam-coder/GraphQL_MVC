using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLMVC.Data;
using GraphQLMVC.GraphQL;
using GraphQLMVC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarvedRockDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLPracticeDb")));

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductReviewRepository>();

//GraphQL Configurations
//builder.Services.AddScoped<IDepedencyResolver>(s => new FunceDepndencyResolver(s.GetRequiredService));
builder.Services.AddScoped<CarvedRockSchema>();
builder.Services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(CarvedRockSchema), ServiceLifetime.Scoped)
                //.AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//GraphQL Configurations
app.UseGraphQL<CarvedRockSchema>();
app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
