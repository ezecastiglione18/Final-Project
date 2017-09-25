using System;

namespace MonoGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new Medium())
              game.Run();
        }
    }
#endif
}
