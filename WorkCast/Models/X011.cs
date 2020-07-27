using System;

namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X011ON=677722341234|OFF=7384384734573845|ON=563647893904308478

    public class X011 : Command
    {
        public LiveIcon[] LiveIcons { get; set; }
        public X011(Entities.Command command) : base(command)
        {
            string[] args = command.CommandString.Substring(4).Split("|");

            LiveIcon[] LiveIcons = new LiveIcon[args.Length];

            for (int i = 0; i < LiveIcons.Length; i++)
            {
                string[] arg = args[i].Split("=");
                LiveIcons[i] = new LiveIcon
                {
                    Pak = UInt64.Parse(arg[1]),
                    Live = arg[0].Equals("ON") ? true : false
                };
            }

            this.LiveIcons = LiveIcons;
        }
    }

    public class LiveIcon
    {
        public ulong Pak { get; set; }
        public bool Live { get; set; }
    }
}
