using Microsoft.EntityFrameworkCore;
using SeatManagement1.Models;
using SeatManagement1;
using SeatManagement1.Services;
using SeatManagement1.GenericRepository;
using SeatManagement1.GlobalException;
using SeatManagement1.Services.Interfaces;
using SeatManagement.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SeatContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddScoped<IRepository<City>, Repository<City>>();
builder.Services.AddScoped<ICityService, CityService>();


builder.Services.AddScoped<IRepository<Building>, Repository<Building>>();
builder.Services.AddScoped<IBuildingService, BuildingService>();


builder.Services.AddScoped<IRepository<Asset>, Repository<Asset>>();
builder.Services.AddScoped<IAssetService, AssetService>();




builder.Services.AddScoped<IRepository<CabinRoom>, Repository<CabinRoom>>();
builder.Services.AddScoped<ICabinRoomService, CabinRoomService>();


builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IRepository<Facility>, Repository<Facility>>();
builder.Services.AddScoped<IFacilityService, FacilityService>();

builder.Services.AddScoped<IRepository<MeetingRoomAssets>, Repository<MeetingRoomAssets>>();
builder.Services.AddScoped<IMeetingRoomAssetService, MeetingRoomAssetService>();

builder.Services.AddScoped<IRepository<MeetingRoom>, Repository<MeetingRoom>>();
builder.Services.AddScoped<IMeetingRoomService, MeetingRoomService>();


builder.Services.AddScoped<IRepository<Seat>, Repository<Seat>>();
builder.Services.AddScoped<ISeat, SeatService>();
builder.Services.AddCors(c => c.AddPolicy("CorsPolicy", corsBuilder =>
{
    corsBuilder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
}));



builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
 
   
    options.ExpireTimeSpan = TimeSpan.FromSeconds(300);
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User",
        policy => policy.RequireRole("User"));
}
);

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.SerializeAsV2=true;

    });
    app.UseSwaggerUI();
  
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
