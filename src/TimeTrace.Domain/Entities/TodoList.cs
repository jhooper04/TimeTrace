namespace TimeTrace.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Color Colour { get; set; } = Color.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
