namespace Cleverence.Task_2
{
    public static class Server
    {
        public static int _count { get; private set; } = 0;
        private static ReaderWriterLockSlim _lock { get; } = new();

        public static int GetCount()
        {
            _lock.EnterReadLock();

            try
            {
                return _count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _lock.EnterWriteLock();

            try
            {
                _count += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}