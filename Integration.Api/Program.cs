
using Integration.Application.Interfaces;
using Integration.Application.Services;
using Integration.Infra.Data;
using Integration.Infra.Repositories;
using Integration.Domain.Interfaces;
using Integration.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Gestor")
    ?? throw new InvalidOperationException(
        "Connection string 'Gestor' não foi configurada.");

builder.Services.AddScoped<IDbConnectionFactory>(sp =>
    new OdbcConnectionFactory(connectionString)
);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<IProdutoFiscalRepository, ProdutoFiscalRepository>();

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

builder.Services.AddScoped<ILocalRepository, LocalRepository>();
builder.Services.AddScoped<ILocalService, LocalService>();

builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
builder.Services.AddScoped<IVendedorService, VendedorService>();

builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

builder.Services.AddScoped<IOperacaoFiscalRepository, OperacaoFiscalRepository>();
builder.Services.AddScoped<IOperacaoFiscalService, OperacaoFiscalService>();

builder.Services.AddScoped<ISerieFiscalRepository, SerieFiscalRepository>();
builder.Services.AddScoped<ISerieFiscalService, SerieFiscalService>();

builder.Services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
builder.Services.AddScoped<ITransportadoraService, TransportadoraService>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
