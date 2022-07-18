
using backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//ssbuilder.Services.AddControllers();


// Início conexão com o banco de dados   
//string stringDeConexao = builder.Configuration.GetConnectionString("conexaoMySQL");
//builder.Services.AddDbContext<DataContext>(opt => opt.UseMySql("", ServerVersion.AutoDetect("")));
//Console.WriteLine("Ola");

//var connectionString = builder.Configuration.GetConnectionString("conexaoMySQL");
//builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder => {
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddControllers();

builder.Services.AddDbContext<empresa_aguasContext>();

// Término da conexão com o banco de dados


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!!");
app.MapGet("/torneira", () => "Torneira");

app.Run();
