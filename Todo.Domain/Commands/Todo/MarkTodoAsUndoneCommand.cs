using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string User { get; set; } = string.Empty;

        public MarkTodoAsUndoneCommand() { }

        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public void Validate()
        {
            AddNotifications(
                 new Contract<TodoItem>()
                    .Requires()            
                    .IsGreaterThan(User, 6, "User", "Usuário Inválido")
            );
        }
    }
}
