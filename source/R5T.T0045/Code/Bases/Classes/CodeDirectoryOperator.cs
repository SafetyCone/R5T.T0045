using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class CodeDirectoryOperator : ICodeDirectoryOperator
    {
        #region Static
        
        public static CodeDirectoryOperator Instance { get; } = new();

        #endregion
    }
}