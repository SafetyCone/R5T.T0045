using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class CodeFileOperator : ICodeFileOperator
    {
        #region Static
        
        public static CodeFileOperator Instance { get; } = new();

        #endregion
    }
}