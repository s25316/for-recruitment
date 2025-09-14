// Ignore Spelling: Pesel
namespace UnifiedModelingLanguage
{
    /// <summary>
    /// {abstract}
    /// </summary>
    public abstract class Example
    {
        /// <summary>
        /// UnderLined - class property and methods
        /// </summary>
        public static string TypeName => nameof(TypeName);

        public required string Name { get; set; } = null!;

        /// <summary>
        /// [0..1] - Optional Property
        /// </summary>
        public string? HandName { get; set; } = null;

        /// <summary>
        /// /HasHandName - Derived attribute [Get, Has, Is]  => used existing property
        /// </summary>
        public bool HasHandName => !string.IsNullOrEmpty(HandName);

        /// <summary>
        /// {unique}
        /// </summary>
        public string Pesel { get; set; } = null!;
    }
}
