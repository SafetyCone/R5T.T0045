using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class MethodOperator : IMethodOperator
    {
        #region Static
        
        public static MethodOperator Instance { get; } = new();

        #endregion
    }
}