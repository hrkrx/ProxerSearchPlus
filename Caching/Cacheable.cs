namespace ProxerSearchPlus.Caching
{
    /// <summary>
    /// This CustomAttribute is used for marking classes as cacheable
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class Cachable : System.Attribute
    {
        public Cachable()
        {
        }
        
        // This is a named argument
        public int NamedInt { get; set; }
    }
}