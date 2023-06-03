using Dapper;
using Npgsql;

public class ToDoListService
{
    TodoContext context;
    public ToDoListService (TodoContext context)
    {
        this.context=context;
    }

 public List<ToDoListDto>GetTodoApp(string? name)
    {
    using(var conn=context.CreateConnection() ){
        var sql="select id as Id,todoname TodoName ,status TodoStatus from todo";
        if (name!=null)
       sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<ToDoListDto>(sql, new { Name = name });
       return result.ToList();
    }
    }

      // get by id
     public ToDoListDto GetTodoAppById(int id)
    {
    using(var conn=context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,todoname TodoName ,status TodoStatus from todo where id=@ID";
       var result = conn.QuerySingle<ToDoListDto>(sql,new {Id=id});
       return result;
    }
    }



   public ToDoListDto AddTodoApp(ToDoListDto app)
    {
    using(var conn= context.CreateConnection()){
        var sql=$"insert into todo(id,todoname  ,status)values ( @Id,@TodoName, @TodoStatus) returning id";
       var result = conn.Execute(sql,new {app.Id,app.TodoName,app.TodoStatus});
       app.Id=result;
       return app;
    }
    }

        public ToDoListDto UpdateTodoApp(ToDoListDto app)
    {
    using(var conn= context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update todo set id=@Id,todoname=@AppName,status=@TodoStatus where id=@Id returning id";
       var result = conn.Execute(sql,new {app.Id,app.TodoName,app.TodoStatus});
       app.Id=result;
       return app;
    }
    }
       public  int DeleteAppTodo(int id)
    {
        using (var conn = context.CreateConnection())
        {
            var sql = $"Delete from todo where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }


}