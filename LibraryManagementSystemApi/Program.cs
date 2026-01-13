
#region Global Usings
// These namespaces will be available across the entire project
global using LibraryManagementSystemApi.Data;
global using LibraryManagementSystemApi.Models.DTOs;
global using LibraryManagementSystemApi.Models.Entites;
global using Microsoft.EntityFrameworkCore;
global using LibraryManagementSystemApi.Constants;
using LibraryManagementSystemApi.Repositories.Implementation;
using LibraryManagementSystemApi.Repositories.Interfaces;
using LibraryManagementSystemApi.Services.Implementation;
using LibraryManagementSystemApi.Services.Interfaces;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database configuration
builder.Services.AddDbContext<LibraryDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryManagementConnection")));

//Repository Registration 

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IBookTransactionRepository, BookTransactionRepository>();

//Services Registration
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

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

app.Run();
