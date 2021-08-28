using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class NamespaceGenerator : INamespaceGenerator
    {
        #region Static

        public static NamespaceGenerator Instance { get; } = new();

        #endregion
    }
}
