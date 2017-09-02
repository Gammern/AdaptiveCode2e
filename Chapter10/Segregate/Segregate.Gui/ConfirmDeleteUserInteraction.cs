using Segregate.Common;
using System;

namespace Segregate.Gui
{
    public class ConfirmDeleteUserInteraction : IUserInteraction
    {
        public bool Confirm(string message)
        {
            Console.WriteLine($"{message} [y/N]");
            var keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Y;
        }
    }
}
