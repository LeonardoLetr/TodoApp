using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "UsuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "LeonardoGeraldo", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "LeonardoGeraldo", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "UsuarioA", DateTime.Now));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_LeonardoGeraldo()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("LeonardoGeraldo"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
