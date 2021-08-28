using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class DocumentationGenerator : IDocumentationGenerator
    {
        #region Static
        
        public static DocumentationGenerator Instance { get; } = new();
        
        #endregion
    }
}