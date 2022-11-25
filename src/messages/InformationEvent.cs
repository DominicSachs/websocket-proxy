namespace Messages;

public sealed class InformationEvent
{
    public InformationEvent(string information)
    {
        Information = information;
    }

    public string Information { get; }
}
