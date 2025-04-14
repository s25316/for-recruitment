using GoF.Structural.Flyweight.Entities.TextEditors;
using GoF.Structural.Flyweight.Interfaces;

namespace GoF.Structural.Flyweight.Entities
{
    public class EditorsFlyweight
    {
        // Properties
        private readonly Dictionary<string, ITextEditor> _dictionary = new Dictionary<string, ITextEditor>();


        // Methods
        public ITextEditor GetEditor(string key)
        {
            if (!_dictionary.TryGetValue(key, out var editor))
            {
                switch (key.ToLower())
                {
                    case "normal":
                        editor = new TextEditor();
                        Console.WriteLine("Create Editor of Normal text");
                        break;
                    case "code":
                        editor = new CodeEditor();
                        Console.WriteLine("Create Editor of Code");
                        break;
                    default:
                        throw new KeyNotFoundException();
                }
                _dictionary[key] = editor;
            }
            return editor;
        }

        public int GetTotalEditors()
        {
            return _dictionary.Count;
        }
    }
}
