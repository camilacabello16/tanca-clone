using Service;
using Service.Entities;
using Service.MongoConnect;
using Service.Repository;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
        //.AllowCredentials();
    });

});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppSettings.Init(builder.Services, builder.Configuration);

builder.Services.AddScoped<IMongoBaseContext, MongoContext>();

builder.Services.AddScoped<IMongoRepository<Board>, MongoRepository<Board>>();
builder.Services.AddScoped<IMongoRepository<Employee>, MongoRepository<Employee>>();
builder.Services.AddScoped<IMongoRepository<Project>, MongoRepository<Project>>();
builder.Services.AddScoped<IMongoRepository<Request>, MongoRepository<Request>>();
builder.Services.AddScoped<IMongoRepository<TaskJob>, MongoRepository<TaskJob>>();
builder.Services.AddScoped<IMongoRepository<WorkShift>, MongoRepository<WorkShift>>();

//TODO: Service
builder.Services.AddScoped<BoardService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<RequestService>();
builder.Services.AddScoped<TaskJobService>();
builder.Services.AddScoped<WorkShiftService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
