using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class CompilationUnitGenerator : ICompilationUnitGenerator
    {
        #region Static
        
        public static CompilationUnitGenerator Instance { get; } = new();
        
        #endregion
    }
}