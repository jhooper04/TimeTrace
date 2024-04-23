using System.Runtime.InteropServices;
using TimeTrace.Domain.Constants;
using TimeTrace.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TimeTrace.Application.Features.Identity;
using TimeTrace.Domain.ValueObjects;

namespace TimeTrace.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task _AddDefaultRole(string role)
    {
        var identityRole = new IdentityRole(role);

        if (_roleManager.Roles.All(r => r.Name != identityRole.Name))
        {
            await _roleManager.CreateAsync(identityRole);
        }
    }

    private async Task _AddDefaultUser(ApplicationUser user, string password, string[] roles)
    {
        if (_userManager.Users.All(u => u.UserName != user.UserName))
        {
            await _userManager.CreateAsync(user, password);
            if (roles.Length > 0)
            {
                await _userManager.AddToRolesAsync(user, roles);
            }
        }
    }

    public async Task TrySeedAsync()
    {
        // Add Default roles
        foreach (var roleProp in typeof(Roles).GetFields())
        {
            await _AddDefaultRole(roleProp.Name);
        }

        // Add Default users

        List<(ApplicationUser User, string Password, string[] Roles)> defaultUsers = new() {
            (new ApplicationUser { UserName = "admin@localhost", Email = "admin@localhost" }, "Administrator1!", new string[] { "Administrator" } ),
            (new ApplicationUser { UserName = "manager@localhost", Email = "manager@localhost" }, "Manager1!", new string[] { "Manager" } ),
            (new ApplicationUser { UserName = "contractor@localhost", Email = "contractor@localhost" }, "Contractor1!", new string[] { "Contractor" } ),
            (new ApplicationUser { UserName = "client@localhost", Email = "client@localhost" }, "Client1!", new string[] { "Client" } ),
        };
        
        foreach (var user in defaultUsers)
        {
            await _AddDefaultUser(user.User, user.Password, user.Roles);
        }

        if (!_context.Clients.Any())
        {
            var client = new Client
            {
                Name = "Acme LLC",
                BillingAddress = new Address("200 Acme RD", "San Antonio", "TX", "78114"),
                Color = Color.Blue,
                Contacts =
                {
                    new Contact { 
                        FirstName="Roger", LastName="Smitherson", 
                        Email="roger@acme.com", Fax="5553321010", Phone="5553322020", 
                        Address = new Address("130 Acme RD", "San Antonio", "TX", "78114"),
                    },
                    new Contact { 
                        FirstName="Dilon", LastName="Johnson", 
                        Email="dilon@acme.com", Fax="5553323030", Phone="5553324040",
                        Address = new Address("230 Someplace Ln", "San Antonio", "TX", "78114"),
                    },
                },
                Projects =
                {
                    new Project { Name="Inventory Management System", Description="Stock inventory tracking system", Color=Color.Orange, 
                        BudgetAmount=150_000, BudgetHours=2500, 
                        OrderDate = new DateTime(2023, 10, 15), 
                        ProjectBegin=new DateTime(2024, 1, 1), ProjectEnd=new DateTime(2024, 4, 1), 
                        OrderNumber="1001", ProjectNumber="101",
                        Components =
                        {
                            new Component { Name="Account", Description="User account management", Color=Color.Orange, BudgetHours=500, BudgetAmount=30_000 },
                            new Component { Name="Purchase Order", Description="Purchase Ordering", Color=Color.Orange, BudgetHours=500, BudgetAmount=30_000 },
                            new Component { Name="Deliveries", Description="Stock Delivery", Color=Color.Orange, BudgetHours=500, BudgetAmount=30_000 },
                            new Component { Name="Adjustments", Description="Stock adjustments", Color=Color.Orange, BudgetHours=500, BudgetAmount=30_000 },
                            new Component { Name="Reports", Description="Report generation system", Color=Color.Orange, BudgetHours=500, BudgetAmount=30_000 },
                        },
                    },
                    new Project { Name="Ecommerce Store", Description="Ecommerce store", Color=Color.Purple,
                        BudgetAmount=30_000, BudgetHours=500,
                        OrderDate = new DateTime(2022, 4, 6),
                        ProjectBegin=new DateTime(2023, 2, 1), ProjectEnd=new DateTime(2023, 4, 6),
                        OrderNumber="1002", ProjectNumber="102",
                        Components =
                        {
                            new Component { Name="Account", Description="User account management", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                            new Component { Name="Cart", Description="Shopping cart", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                            new Component { Name="Catalog", Description="Product catalog", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                            new Component { Name="Orders", Description="Order Fulfillment", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                            new Component { Name="Payments", Description="Payment", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                            new Component { Name="Reports", Description="Report generation system", Color=Color.Orange, BudgetHours=83, BudgetAmount=5_000 },
                        },
                    },
                },
            };

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();
        }

        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
