using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class CompilationUnitOperator : ICompilationUnitOperator
    {
        #region Static

        public static CompilationUnitOperator Instance { get; } = new();

        #endregion
    }
}