namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X010=”Thanks Tom. I have a question on the 3rd point you made?”

    public class X010 : Command
    {
        public string Message { get; set; }
        public X010(Entities.Command command) : base(command)
        {
            Message = command.CommandString.Substring(5);
        }
    }
}
