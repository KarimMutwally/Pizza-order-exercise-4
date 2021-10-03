using PIZZAAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
PizzaConfig config = new();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Pizza Order API");

app.MapGet("/menu", async () => {
    return await config.GetMenuAsync();
});

app.MapGet("/toppings", async () =>  {
    return await config.GetToppingsAsync();
});

app.MapPost("/order", async (Order order) => {
    await config.SaveOrder(order);
});

app.Run();
