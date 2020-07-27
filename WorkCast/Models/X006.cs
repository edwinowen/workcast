using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X006=12345

    public class X006 : Command
    {
        public ushort PresenterId { get; set; }
        public X006(Entities.Command command) : base(command)
        {
            PresenterId = UInt16.Parse(command.CommandString.Substring(5));
        }
    }
}
