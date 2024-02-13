using CollaberaCodingTask.Services;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<INewsService, NewsService>((httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
 });


builder.Services.AddControllers();
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
//app.UseCors(() =>
//{

//})

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
