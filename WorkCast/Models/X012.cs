using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X012=http://www.workcast.net

    public class X012 : Command
    {
        public string Source { get; set; }
        public X012(Entities.Command command) : base(command)
        {
            Source = command.CommandString.Substring(5);
        }
    }
}
