using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using SameApi.Business;
using SameApi.Business.Behaviors;
using SameApi.Business.User.Command;
using SameApi.Business.User.Query;
using SameApi.Db;

var builder = WebApplication.CreateBuilder(args);

// -------------------- CORS --------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDevClient", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:7171", "http://localhost:5173") //5173 pour le front
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// -------------------- Controllers --------------------
builder.Services.AddControllers();

// -------------------- Swagger --------------------
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Test",
        Version = "v1"
    });

    c.AddServer(new OpenApiServer
    {
        Url = "https://localhost:7171",
        Description = "Local dev server"
    });
});

// -------------------- Services --------------------
builder.Services.AddSameApibContext(builder.Configuration);
builder.Services.RegisterSameApiDbContainer();
builder.Services.AddAutoMapper(cfg => { }, typeof(SameApiProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommand>(); 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateUserCommand).Assembly,
        typeof(UpdateUserCommand).Assembly,
        typeof(DeleteUserCommand).Assembly,
        typeof(GetUserByIdQuery).Assembly,
        typeof(GetAllUserQuery).Assembly
    )
);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// -------------------- Middleware --------------------
app.UseCors("AllowReactDevClient");

if (app.Environment.IsDevelopment())
{
    // Swagger uniquement en développement
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Test v1");
        c.RoutePrefix = "swagger"; // Accessible via /swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { ok = true, dotnet = Environment.Version.ToString() }));


app.Run();