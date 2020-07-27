namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=uvkh3ebclbfvkj4bvrjbjtrv4bhpight8ugih

    public class UnknownCommand : Command
    {
        public string Error { get; set; }
        public UnknownCommand(Entities.Command command) : base (command)
        {
            Code = "X000";
            Error = "Unrecognised Command";
        }
    }
}
