using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X008=http://www.workcast.net/images/123.jpg

    public class X008 : Command
    {
        public string SplashSource { get; set; }
        public X008(Entities.Command command) : base(command)
        {
            if (command.CommandString.IndexOf("X008=") != 0) throw new InvalidOperationException();

            SplashSource = command.CommandString.Substring(5);
        }
    }
}
