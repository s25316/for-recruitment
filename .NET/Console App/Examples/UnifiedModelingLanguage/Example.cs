// Ignore Spelling: Pesel
namespace UnifiedModelingLanguage
{
    public class Example
    {
        public static
        /// <summary>
        /// required property
        /// </summary>
        public required string Name
        { get; set; } = null!;
        public required string Surname { get; set; } = null!;

        /// <summary>
        /// Optional
        /// </summary>
        public string? HandName { get; set; } = null;

        /// <summary>
        /// Derived attribute [Get, Has, Is]  => used existing property
        /// </summary>
        public bool HasHandName => !string.IsNullOrEmpty(HandName);

        /// <summary>
        /// {unique}
        /// </summary>
        public string Pesel { get; set; } = null!;
    }
}
