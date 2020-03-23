using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TodoApp
{
    class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
    public partial class _Default : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            var baseUrl = "https://jsonplaceholder.typicode.com/todos";

            try
            {
                using var client = new HttpClient();
                using var response = await client.GetAsync(baseUrl);
                using var content = response.Content;

                var data = await content.ReadAsStringAsync();

                if (data == null) throw new Exception("no data");

                var todoList = JsonConvert.DeserializeObject<List<Todo>>(data);
                
                // simpan state
                Session["TodoList"] = data;

                //// bind todoList ke todoListRepeater
                TodoListRepeater.DataSource = todoList.Select(item => new
                {
                    Id = item.Id,
                    Title = item.Title
                }).ToList();
                TodoListRepeater.DataBind();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        protected void DeleteTodo(object sender, EventArgs e)
        {
            var todoList = JsonConvert.DeserializeObject<List<Todo>>(Session["TodoList"].ToString());
            var todoId = Int32.Parse(((Button)sender).CommandArgument);

            var newTodoList = todoList.Where(item => item.Id != todoId).Select(
                item => new
                {
                    Id = item.Id,
                    Title = item.Title
                });
            
            // simpan ke state
            Session["TodoList"] = JsonConvert.SerializeObject(newTodoList);

            // bind newTodoList ke todoListRepeater
            TodoListRepeater.DataSource = newTodoList.ToList();
            TodoListRepeater.DataBind();
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}