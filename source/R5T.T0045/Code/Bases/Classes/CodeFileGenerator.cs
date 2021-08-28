using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class CodeFileGenerator : ICodeFileGenerator
    {
        #region Static

        public static CodeFileGenerator Instance { get; } = new();

        #endregion
    }
}