

List<string> todoList = new List<string>();

string providedOption;

bool canExit = false;

Console.WriteLine("Hello!");

do
{

    Console.WriteLine("\r\nWhat do you want to do?\r\n[S]ee all TODOs\r\n[A]dd a TODO\r\n[R]emove a TODO\r\n[E]xit");

    providedOption = Console.ReadLine() ?? "";

    switch (providedOption.ToLower())
    {
        case "s":
            ViewTodoList();
            break;
        case "a":
            AddTodoItem();
            break;
        case "r":
            DeleteTodoItem();
            break;
        case "e":
            Console.WriteLine("Exiting...");
            canExit = true;
            break;

        default:
            Console.WriteLine("Incorrect input");
            break;
    }



} while (!canExit);

void ViewTodoList()
{
    if (todoList.Count == 0)
    {
        LogEmptyTodoListMessage();

        return;
    }

    ListTodoItems();
}
void AddTodoItem()
{
    string providedTodoItem;

    do
    {
        Console.WriteLine("Enter the TODO description:");

        providedTodoItem = Console.ReadLine() ?? "";

    } while (!ProvidedTodoDescriptionIsValid(providedTodoItem));

    todoList.Add(providedTodoItem);

    Console.WriteLine($"TODO successfully added: {providedTodoItem}");

}

void DeleteTodoItem()
{

    if (todoList.Count == 0)
    {
        LogEmptyTodoListMessage();

        return;
    }

    int index;

    do
    {

        Console.WriteLine("Select the index of the TODO you want to remove:");

        ListTodoItems();

    } while (!handleProvidedIndex(out index));

    DestroyTodoItem(index - 1);

}

bool ProvidedTodoDescriptionIsValid(string providedTodoItem)
{
    if (string.IsNullOrEmpty(providedTodoItem))
    {
        Console.WriteLine("The description cannot be empty.");

        return false;
    }
    else if (todoList.Contains(providedTodoItem))
    {
        Console.WriteLine("The description must be unique.");

        return false;
    }

    return true;
}

void ListTodoItems()
{

    for (int i = 0; i < todoList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todoList[i]}");
    }
}

void DestroyTodoItem(int index)
{

    string targetTodoItem = todoList[index];

    todoList.RemoveAt(index);

    Console.WriteLine($"TODO removed: {targetTodoItem}");
}

bool handleProvidedIndex(out int index)
{

    string providedIndex = Console.ReadLine() ?? "";

    if (string.IsNullOrEmpty(providedIndex))
    {

        index = 0;

        Console.WriteLine("Selected index cannot be empty.");

        return false;
    }
    else if (!int.TryParse(providedIndex, out index) || index < 1 || index > todoList.Count())
    {
        Console.WriteLine("The given index is not valid.");

        return false;
    }

    return true;

}

void LogEmptyTodoListMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}

Environment.Exit(0);