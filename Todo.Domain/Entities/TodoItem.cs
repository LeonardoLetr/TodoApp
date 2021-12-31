namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; } 

        public TodoItem(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public void MaskAsDone()
        {
            Done = true;
        }

        public void MaskAsUndone()
        {
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
