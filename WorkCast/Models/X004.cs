using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X004=55656636633

    public class X004 : Command
    {
        public ulong Pak { get; set; }
        public X004(Entities.Command command) : base(command)
        {
            Pak = UInt64.Parse(command.CommandString.Substring(5));
        }
    }
}
