using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public string Title { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract<TodoItem>()
                    .Requires()
                    .IsGreaterThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .IsGreaterThan(User, 6, "User", "Usuário Inválido")
            );
        }
    }  
}
