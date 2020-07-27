using System;

namespace WorkCast.Models
{
    public abstract class Command
    {
        public string Code { get; set; }
        public CommandInfo CommandInfo { get; set; }

        public Command(Entities.Command command)
        {
            Code = command.Code;
            CommandInfo = new CommandInfo(command);

            EventAction();
        }

        protected virtual void EventAction()
        {
            // Override this method to perform back end functions automatically
        }
    }

    public class CommandInfo
    {
        public string CommandString { get; set; }
        public DateTime EnqueueTime { get; set; }
        public DateTime? DequeueTime { get; set; }
        public bool Complete { get; set; }

        public CommandInfo(Entities.Command command)
        {
            CommandString = command.CommandString;
            EnqueueTime = command.EnqueueTime;
            DequeueTime = command.DequeueTime;
            Complete = command.Complete;
        }

    }
}
