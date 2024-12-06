
using TodoList.DataAccess;

class TodoListManager
{
    private const string NOTODOMESSAGE = "No TODOs have been added yet.";
    private List<string> _todoList { get; }

    private readonly FileManager _fileManager = new FileManager("todolist.txt");

    public TodoListManager()
    {

        _todoList = _fileManager.FetchTodoList();

    }

    public void AddItem()
    {
        string providedDescription;

        do
        {
            Console.WriteLine("Enter the TODO description:");

            providedDescription = Console.ReadLine() ?? "";

        } while (!IsValidDescription(providedDescription));

        _todoList.Add(providedDescription);

        _fileManager.Store(_todoList);

        Console.WriteLine($"TODO successfully added: {providedDescription}");

    }

    public void DeleteItem()
    {

        if (_todoList.Count == 0)
        {
            Console.WriteLine(NOTODOMESSAGE);

            return;
        }

        int index;

        do
        {

            Console.WriteLine("Select the index of the TODO you want to remove:");

            ListItems();

        } while (!IsValidIndex(out index));

        int targetIndex = index - 1;

        string targetItem = _todoList[targetIndex];

        _todoList.RemoveAt(targetIndex);

        _fileManager.Store(_todoList);

        Console.WriteLine($"TODO removed: {targetItem}");

    }


    public void ViewList()
    {
        if (_todoList.Count == 0)
        {
            Console.WriteLine(NOTODOMESSAGE);

            return;
        }

        ListItems();
    }

    private void ListItems()
    {

        for (int i = 0; i < _todoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_todoList[i]}");
        }
    }

    private bool IsValidDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            Console.WriteLine("The description cannot be empty.");

            return false;
        }
        else if (_todoList.Contains(description))
        {
            Console.WriteLine("The description must be unique.");

            return false;
        }

        return true;
    }

    private bool IsValidIndex(out int index)
    {

        string providedIndex = Console.ReadLine() ?? "";

        if (string.IsNullOrEmpty(providedIndex))
        {

            index = 0;

            Console.WriteLine("Selected index cannot be empty.");

            return false;
        }
        else if (!int.TryParse(providedIndex, out index) || index < 1 || index > _todoList.Count())
        {
            Console.WriteLine("The given index is not valid.");

            return false;
        }

        return true;

    }
}

