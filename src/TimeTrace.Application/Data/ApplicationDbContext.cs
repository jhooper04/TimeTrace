using System.Reflection;
using TimeTrace.Application.Common.Interfaces;
using TimeTrace.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TimeTrace.Application.Features.Identity;

namespace TimeTrace.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Component> Components => Set<Component>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<Issue> Isuues => Set<Issue>();
    public DbSet<IssueLabel> IssueLabels => Set<IssueLabel>();
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();
    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
