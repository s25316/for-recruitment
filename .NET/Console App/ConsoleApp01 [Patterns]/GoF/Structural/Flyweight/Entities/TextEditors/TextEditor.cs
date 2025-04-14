using GoF.Structural.Flyweight.Interfaces;

namespace GoF.Structural.Flyweight.Entities.TextEditors
{
    class TextEditor : ITextEditor
    {
        public void Edit(string text)
        {
            Console.WriteLine($"Edited: {text.ToLower().Trim()}");
        }
    }
}
