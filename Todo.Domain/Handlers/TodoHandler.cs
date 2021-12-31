using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);
            }

            // Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salva no banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);
            }

            // Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            if (todo is null)
            {
                return new GenericCommandResult(
                   false,
                   "Ops, parece que sua consulta não é valida!",
                   new object());
            }

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(todo);

            //Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            if (todo is null)
            {
                return new GenericCommandResult(
                   false,
                   "Ops, parece que sua consulta não é valida!",
                   new object());
            }

            todo.MaskAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo); 
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada!",
                    command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            if (todo is null)
            {
                return new GenericCommandResult(
                   false,
                   "Ops, parece que sua consulta não é valida!",
                   new object());
            }

            todo.MaskAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
