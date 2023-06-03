using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TodoAppControllers:ControllerBase
{
    
    private ToDoListService todoAppService; 
    public TodoAppControllers(ToDoListService todoAppService)
    {
        this.todoAppService=todoAppService;
    }

  [HttpPost("AddStudent")]
    
    public ToDoListDto AddStudent(ToDoListDto todoApp){
        return todoAppService.AddTodoApp(todoApp);
    }

    [HttpGet("GetApp")]
    public List<ToDoListDto>GetTodoApp(){
        return todoAppService.GetTodoApp(null);
    }
 
   [HttpGet("GetTodoApp")]
    public ToDoListDto GetStudent(int id){
        return todoAppService.GetTodoAppById(id);
    }
   

      [HttpDelete("Delete TodoApp")]
    public int DeleteAppTodo(int id){
        return todoAppService.DeleteAppTodo(id);
    }

      [HttpPut("Update TodoApp")]
    public ToDoListDto UpdateTodoApp(ToDoListDto student){
        return todoAppService.UpdateTodoApp( student);
    }

}