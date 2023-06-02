using ApiAppointmentReminder.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);


builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.RegisterRepository();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
