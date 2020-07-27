namespace WorkCast.Models
{
    // /api/CommandQueue/Enqueue?comm=X003=http://www.workcast.co.uk/

    public class X003 : Command
    {
        public string Url { get; set; }
        public X003(Entities.Command command) : base(command)
        {
            Url = command.CommandString.Substring(5);
        }
    }
}
