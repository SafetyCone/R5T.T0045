using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class PropertyGenerator : IPropertyGenerator
    {
        #region Static
        
        public static PropertyGenerator Instance { get; } = new();
        
        #endregion
    }
}