namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X005=”Sorry, these is a problem with the event. Please refresh your browser”

    public class X005 : Command
    {
        public string Message { get; set; }
        public X005(Entities.Command command) : base(command)
        {
            string message = command.CommandString.Substring(5);

            if (message.Length >= 500)
            {
                message = message.Substring(0, 497) + "...";
            }

            Message = message;
        }
    }
}
