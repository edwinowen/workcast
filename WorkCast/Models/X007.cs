using System;

namespace WorkCast.Models
{
    public class X007 : Command
    {
        // /api/CommandQueue/Enqueue?comm=X007MEDI1=http://www.workcast.net/media/1234.mp4|MEDI2=http://www.workcast.net/media/4567.mp4

        public Media[] Media { get; set; }
        public X007(Entities.Command command) : base(command)
        {
            if (command.CommandString.IndexOf("X007") != 0) throw new InvalidOperationException();

            string[] args = command.CommandString.Substring(4).Split("|");

            Media[] Media = new Media[args.Length];

            for (int i = 0; i < Media.Length; i++)
            {
                string[] arg = args[i].Split("=");
                Media[i] = new Media { Id = arg[0], Source = arg[1] };
            }

            this.Media = Media;
        }
    }

    public class Media
    {
        public string Id { get; set; }
        public string Source { get; set; }
    }
}
