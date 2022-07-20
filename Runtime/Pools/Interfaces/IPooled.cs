namespace Depra.ObjectPooling.Runtime.Pools.Interfaces
{
    /// <summary>
    /// Classes that implement <see cref="IPooled"/> will receive calls from the <see cref="IPool"/>.
    /// </summary>
    public interface IPooled : IRecycled
    {
        /// <summary>
        /// Invoked when the object is instantiated.
        /// </summary>
        void OnPoolCreate(IPool pool);

        /// <summary>
        /// Invoked when the object is grabbed from the pool.
        /// </summary>s
        void OnPoolGet();

        /// <summary>
        /// Invoked when the object is released back to the pool.
        /// </summary>
        void OnPoolSleep();
    }
}