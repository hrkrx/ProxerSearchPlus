namespace ProxerSearchPlus.Caching
{
    /// <summary>
    /// This CustomAttribute is used for marking properties as id
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class IdColumn : System.Attribute
    {
        public IdColumn()
        {
        }
    }
}