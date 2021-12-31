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
    public class MarkTodoAsUndoneCommandTests
    {
        private static readonly Guid _id = Guid.NewGuid();
        private readonly MarkTodoAsUndoneCommand _invalidCommand = new(_id, "ticia");
        private readonly MarkTodoAsUndoneCommand _validCommand = new(_id, "Letícia Fernanda");

        public MarkTodoAsUndoneCommandTests()
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
