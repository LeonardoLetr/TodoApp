using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkTodoAsDoneCommandTests
    {
        private static readonly Guid _id = Guid.NewGuid();
        private readonly MarkTodoAsDoneCommand _invalidCommand = new(_id, "ticia");
        private readonly MarkTodoAsDoneCommand _validCommand = new(_id, "Letícia Fernanda");

        public MarkTodoAsDoneCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_commando_invalido()
        {
            Assert.AreEqual(_invalidCommand.IsValid, false);
        }

        [TestMethod]
        public void Dado_um_commando_valido()
        {
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}
