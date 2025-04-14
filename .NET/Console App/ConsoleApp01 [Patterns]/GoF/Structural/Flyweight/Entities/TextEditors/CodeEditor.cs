using GoF.Structural.Flyweight.Interfaces;

namespace GoF.Structural.Flyweight.Entities.TextEditors
{
    public class CodeEditor : ITextEditor
    {
        public void Edit(string text)
        {
            if (text.Trim().Last() == ';')
            {
                Console.WriteLine($"Valid code: {text.Trim()}");
            }
            else
            {
                Console.WriteLine($"Invalid code: {text.Trim()}");
            }
        }
    }
}
