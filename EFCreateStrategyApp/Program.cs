
using EFCreateStrategyApp;

using (PersonAppContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Person person = new() { Name = "Person", Age = 22 };
    User user = new()
    {
        Name = "User",
        Age = 31,
        Login = "user@gmail.com",
        Password = "qwerty"
    };
    Admin admin = new()
    {
        Name = "Admin",
        Age = 38,
        Login = "admin@yandex.ru",
        Password = "hello"
    };
    Guest guest = new()
    {
        Name = "Guest",
        Age = 40,
        Email = "gueat@pochta.ru"
    };

    context.Persons.Add(person);
    context.Users.Add(user);
    context.Admins.Add(admin);
    context.Guests.Add(guest);

    context.SaveChanges();
}

using (PersonAppContext context = new())
{ 
    var persons  = context.Persons.ToList();
    foreach(var p in persons)
        Console.WriteLine($"{p.Name} {p.Age}");
    Console.WriteLine();

    var users = context.Users.ToList();
    foreach (var u in users)
        Console.WriteLine($"{u.Name} {u.Age} {u.Login} {u.Password}");
    Console.WriteLine();

    var guests = context.Guests.ToList();
    foreach (var g in guests)
        Console.WriteLine($"{g.Name} {g.Age} {g.Email}");
    Console.WriteLine();
}
