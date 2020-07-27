using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X002ID=1234|V=T|Q1=123|Q2=456|Q3=789

    public class X002 : Command
    {
        public ushort PollId { get; set; }
        public bool V { get; set; }
        public uint[] Q { get; set; }
        public X002(Entities.Command command) : base(command)
        {
            string[] args = command.CommandString.Substring(5).Split("|");

            PollId = UInt16.Parse(args[0].Substring(3));
            V = args[1].Substring(2) == "T" ? true : false;
            Q = new uint[args.Length - 2];

            for(int i = 0; i < Q.Length; i++)
            {
                Q[i] = UInt32.Parse(args[i + 2].Substring(3));
            }
        }
    }
}
