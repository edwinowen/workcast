using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X009=12345

    public class X009 : Command
    {
        public ushort UserId { get; set; }
        public X009(Entities.Command command) : base(command)
        {
            if (command.CommandString.IndexOf("X009=") != 0) throw new InvalidOperationException();

            UserId = UInt16.Parse(command.CommandString.Substring(5));
        }
    }
}
