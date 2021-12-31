using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateTodoHandlerTests
    {
        private static readonly Guid _id = Guid.NewGuid();
        private readonly UpdateTodoCommand _invalidCommand = new(_id, "", "");
        private readonly UpdateTodoCommand _validCommand = new(_id, "Titulo da Tarefa", "Leonardo Geraldo");

        private readonly TodoHandler _handler = new(new FakeTodoRepository());
        private GenericCommandResult _result = new();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult) _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_atualizar_a_tarefa()
        {
            _result = (GenericCommandResult) _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
