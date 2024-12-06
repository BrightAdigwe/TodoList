

bool canExit = false;

TodoListManager todoListManager = new TodoListManager();

string envNewLine = Environment.NewLine;

Console.WriteLine("Hello!");

do
{

    Console.WriteLine($"{envNewLine}What do you want to do?{envNewLine}[S]ee all TODOs{envNewLine}[A]dd a TODO{envNewLine}[R]emove a TODO{envNewLine}[E]xit");

    string providedOption = Console.ReadLine()?.ToLower() ?? "";

    switch (providedOption)
    {
        case "s":
            todoListManager.ViewList();
            break;
        case "a":
            todoListManager.AddItem();
            break;
        case "r":
            todoListManager.DeleteItem();
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

Environment.Exit(0);