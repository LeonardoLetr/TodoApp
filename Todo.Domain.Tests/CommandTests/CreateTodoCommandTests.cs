using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    // Red, Green, Refactory
    
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new("Titulo da Tarefa", "Leonardo Geraldo", DateTime.Now);

    public CreateTodoCommandTests()
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