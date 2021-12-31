using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateTodoCommandTests
    {
        private static readonly Guid _id = Guid.NewGuid();
        private readonly UpdateTodoCommand _invalidCommand = new(_id, "", "");
        private readonly UpdateTodoCommand _validCommand = new (_id, "Titulo da Tarefa", "Leonardo Geraldo");

        public UpdateTodoCommandTests()
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
