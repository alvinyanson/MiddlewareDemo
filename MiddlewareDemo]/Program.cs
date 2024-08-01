var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    // Do work that can write to the Response.
//    Console.WriteLine("Before1");
//    await next.Invoke();
//    Console.WriteLine("After1");
//    // Do logging or other work that doesn't write to the Response.
//});

//app.Use(async (context, next) =>
//{
//    // Do work that can write to the Response.
//    Console.WriteLine("Before2");
//    await next.Invoke();
//    Console.WriteLine("After2");
//    // Do logging or other work that doesn't write to the Response.
//});

//app.Use(async (context, next) =>
//{
//    // Do work that can write to the Response.
//    Console.WriteLine("Before3");
//    await next.Invoke();
//    Console.WriteLine("After3");
//    // Do logging or other work that doesn't write to the Response.
//});

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from 2nd delegate.");
//});


//app.Run();


////This will not get called
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from 2nd delegate.");
//});


//output
//Before1
//Before2
//Before3
//Before3
//Before2
//Before1


//app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
//    appBuilder => HandleBranchAndRejoin(appBuilder));

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from non-Map delegate.");
//});

//app.Run();

//void HandleBranchAndRejoin(IApplicationBuilder app)
//{
//    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>();

//    app.Use(async (context, next) =>
//    {
//        var branchVer = context.Request.Query["branch"];
//        logger.LogInformation("Branch used = {branchVer}", branchVer);

//        // Do work that doesn't write to the Response.
//        await next();
//        // Do other work that doesn't write to the Response.
//    });
//}


app.Map("/map1", HandleMapTest1);

app.Map("/map2", HandleMapTest2);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from non-Map delegate.");
});

app.Run();

static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}

static void HandleMapTest2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 2");
    });
}



