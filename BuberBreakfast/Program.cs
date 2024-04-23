using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
{
    builder.Services.AddControllers();

    // every time the application instantiates an object that requests iBreakfastService in the constructor,
    // then use the breakfast service object as the implementation 

    builder.Services.AddSingleton<IBreakfastService, BreakfastService>();
    // for add singleton: every time someone requests a ibreakfastservice, use the SAME breakfastService.
    // also have addscoped: within the lifetime of a single request, 
    // addtransient: every time requests the interface, create a new breakfastservice object
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


