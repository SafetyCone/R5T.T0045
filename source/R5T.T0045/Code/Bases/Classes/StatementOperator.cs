using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class StatementOperator : IStatementOperator
    {
        #region Static
        
        public static StatementOperator Instance { get; } = new();

        #endregion
    }
}