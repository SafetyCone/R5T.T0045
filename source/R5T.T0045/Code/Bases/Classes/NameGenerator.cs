using System;


namespace R5T.T0045
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class NameGenerator : INameGenerator
    {
        #region Static
        
        public static NameGenerator Instance { get; } = new();
        
        #endregion
    }
}