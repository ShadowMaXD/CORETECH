using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Business;
using Common;
using Common.Consts;
using CORETECH_WebApi.Helpers;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ========== ДОБАВЬ ЭТО - НАСТРОЙКА CORS ==========
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // Разрешить любые домены
              .AllowAnyMethod()      // GET, POST, PUT, DELETE, OPTIONS
              .AllowAnyHeader();     // Любые заголовки
    });

    // ИЛИ для продакшена - конкретные домены (раскомментируй и настрой)
    // options.AddPolicy("AllowFrontend", policy =>
    // {
    //     policy.WithOrigins(
    //             "http://localhost:3000",
    //             "http://localhost:5500",
    //             "http://localhost:8080",
    //             "https://твой-сайт.ру"
    //           )
    //           .AllowAnyMethod()
    //           .AllowAnyHeader()
    //           .AllowCredentials();
    // });
});
// ==================================================

builder.Services.AddScoped<_BL_Context>();

#region log4net
//builder.Services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.AddLog4Net("log4net.config");
//});
#endregion log4net

#region Swagger - часть 1

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(options =>
{
    string basePath = AppContext.BaseDirectory;
    var assembly = Assembly.GetExecutingAssembly();

    // 1. XML файл текущего проекта
    string xmlPath = Path.Combine(basePath, $"{assembly.GetName().Name}.xml");
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
    else
    {
        Console.WriteLine($"⚠️ XML файл API не найден: {xmlPath}");
    }

    // 2. XML файл для бизнес-сборки (если существует)
    try
    {
        // Получаем путь к сборке Business
        string businessXmlPath = Path.Combine(basePath, "Business.xml");

        // Альтернативный вариант, если GetAssemblyPath возвращает путь к папке
        if (_BL_Context.GetAssemblyPath != null)
        {
            string businessPath = _BL_Context.GetAssemblyPath;
            if (Directory.Exists(businessPath))
            {
                businessXmlPath = Path.Combine(businessPath, "Business.xml");
            }
            else if (File.Exists(businessPath))
            {
                businessXmlPath = businessPath.Replace(".dll", ".xml");
            }
        }

        if (File.Exists(businessXmlPath))
        {
            options.IncludeXmlComments(businessXmlPath);
            Console.WriteLine($"✅ Загружен XML бизнес-сборки: {businessXmlPath}");
        }
        else
        {
            Console.WriteLine($"⚠️ XML файл бизнес-сборки не найден: {businessXmlPath}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Ошибка при загрузке XML бизнес-сборки: {ex.Message}");
    }

    options.EnableAnnotations();
});

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

#endregion Swagger - часть 1


WebApplication app = builder.Build();

// ========== ДОБАВЬ ЭТО - ПОДКЛЮЧЕНИЕ CORS (ДО ВСЕХ app.Use...) ==========
app.UseCors("AllowAll");  // Используем политику "AllowAll"
// ИЛИ если используешь конкретные домены: app.UseCors("AllowFrontend");
// ========================================================================

#region Обработка исключений и ошибочного вызова страниц

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseExceptionHandler(exceptionHandlerApp =>
    //{
    //    exceptionHandlerApp.Run(Extension_ExceptionHandler.GetExceptionHandler(ReturnJsonResponse: false)); //Подключение обработчика ошибок, который пишет в логи все необработанные исключения
    //});
}

//app.UseStatusCodePages(Extension_StatusCodeHandle.GetStatusCodeHandler(ReturnJsonResponse: false)); // Обработка статус-кодов http кода 400 и выше, которые не имеют тела ответа (необработанные)

#endregion Обработка исключений


app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


#region Подключаем логи



#endregion Подключаем логи

ConfigurationManager config = builder.Configuration; //было раньше IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

string? config_val_str;
int? config_val_int;
bool? config_val_bool;

#if !DEBUG
config_val_str = config.GetSection("ConnectionStrings")["Connection_Base"];
if (string.IsNullOrWhiteSpace(config_val_str))
{
    throw new NullReferenceException("Не удалось считать параметр в appsettings.json ->ConnectionStrings:Connection_Base");
}
AppConfig.ConnectionString = config_val_str;
#else
AppConfig.ConnectionString = Consts_Debug.DB_ConnectionString;
#endif


#region Редирект на HTTPS

if (true)
{
    app.UseHttpsRedirection();
}

#endregion Редирект на HTTPS

#region swagger 

string urlPrefix = "swagger";

app.UseSwagger(option =>
{
    option.RouteTemplate = urlPrefix + "/{documentName}/swagger.json";
});

IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

app.UseSwaggerUI(option =>
{
    option.DocumentTitle = $"Api_Coretech";
    option.RoutePrefix = urlPrefix;

    foreach (ApiVersionDescription description in descriptions)
    {
        option.SwaggerEndpoint($"/{urlPrefix}/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

#endregion swagger 

app.Run();