using System.Text.RegularExpressions;
using todos;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to your todo list.");
        bool start = true;
        List<Todos> todoList = new List<Todos>();

        do
        {
            if (start == false)
            {
                break;
            } else
            {
                Console.WriteLine("Do you want to create todo list for today?");
                string beginTodoForToday = Console.ReadLine();

                if (beginTodoForToday.ToLower() == "no")
                {
                    break;
                }

                while (beginTodoForToday.ToLower() == "yes")
                {
                    Todos todo = new Todos() { Todo = EnterTodo(), UniqueId = Guid.NewGuid() };

                    todoList.Add(todo);

                    Console.WriteLine("Do you want to add another todo?");

                    string anotherTodo = Console.ReadLine();

                    if (anotherTodo.ToLower() == "no")
                    {
                        start = false;
                        break;
                    } else
                    {
                        continue;
                    }
                }
            }
        } while (start == true);

        FetchTodos(todoList);

        Console.WriteLine("Do you want to edit any todo?");
        string editTodo = Console.ReadLine();

        while (editTodo.ToLower() == "yes")
        {
            Console.WriteLine("Enter index for which you want to update the todo : ");
            string position = Console.ReadLine();

            if (Regex.IsMatch(position, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Please enter a valid index.");
                continue;
            }

            int index = Convert.ToInt32(position);

            Console.WriteLine("Enter your new todo : ");
            ModifyTodo(todoList[index]);

            Console.WriteLine("Do you want to edit another todo?");
            string anotherTodo = Console.ReadLine();

            if (anotherTodo.ToLower() == "yes")
            {
                continue;
            } else
            {
                editTodo = "no";
                break;
            }
        }

        FetchTodos(todoList);

    }

    static bool BeginTodo(string answer, bool endTodoList) => answer.ToLower() == "yes" ? true : endTodoList;

    static string EnterTodo()
    {
        Console.WriteLine("Enter your todo : ");
        string todo = Console.ReadLine();

        return todo;
    }

    static void FetchTodos(List<Todos> todoList)
    {
        if (todoList.Count == 0)
        {
            Console.WriteLine("There are no todos for today.");
            Console.ReadKey();
        } else
        {
            Console.WriteLine("This is your todo list for today : ");

            for (int i=0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {todoList[i].Todo} => {todoList[i].check}");
            }

            Console.ReadKey();
        }
    }

    static void ModifyTodo(Todos todo)
    {
        string newTodo = Console.ReadLine();
        todo.Todo = newTodo;
    }
}
