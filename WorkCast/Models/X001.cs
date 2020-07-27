using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X001ID=1234

    public class X001 : Command
    {
        public ushort PollId { get; set; }
        public X001(Entities.Command command) : base (command)
        {
            PollId = UInt16.Parse(command.CommandString.Substring(7));
        }
}
}
