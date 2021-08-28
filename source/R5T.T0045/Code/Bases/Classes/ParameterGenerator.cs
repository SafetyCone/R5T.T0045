using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ParameterGenerator : IParameterGenerator
    {
        #region Static
        
        public static ParameterGenerator Instance { get; } = new();
        
        #endregion
    }
}