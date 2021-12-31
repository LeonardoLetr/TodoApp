using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;

        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
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
