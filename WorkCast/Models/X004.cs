using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X004=55656636633

    public class X004 : Command
    {
        public ulong Pak { get; set; }
        public X004(Entities.Command command) : base(command)
        {
            if (command.CommandString.IndexOf("X004=") != 0) throw new InvalidOperationException();

            Pak = UInt64.Parse(command.CommandString.Substring(5));
        }
    }
}
