using Bll_Services;
using Core.Mapping;
using Core.Repositories;
using Core.ServicesBll;
using Dal_Repository_infrastracture;
using Dal_Repository_infrastracture.Data_Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ����� �������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<myContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("myContex")));

builder.Services.AddScoped<AddressInterfaceDAL, AddressDal>();
builder.Services.AddScoped<AddressInterfaceBLL, AddressBLL>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// ����� HTTPS �������
app.UseHttpsRedirection();
app.UseAuthorization();

// ����: ���� ����� ������
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "view.html" }
});
app.UseStaticFiles();

// �� ��� ��: ����� ����������
app.MapControllers();

// ���� ���������
app.Run();

