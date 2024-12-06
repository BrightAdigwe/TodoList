
namespace TodoList.DataAccess
{
    class FileManager
    {
        private readonly string _filePath;
        private static readonly string _delimiter = Environment.NewLine;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<string> FetchTodoList()
        {
            if(!File.Exists(_filePath)) return new List<string>();

            var fileContent = File.ReadAllText(_filePath);
            return fileContent.Split(_delimiter).ToList();
        }

        public void Store(List<string> todoList) { 
            File.WriteAllText(_filePath, string.Join(_delimiter, todoList)); 
        }
    }
}
