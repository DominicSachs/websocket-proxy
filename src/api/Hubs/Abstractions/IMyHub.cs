namespace Api.Hubs.Abstractions;

public interface IMyHub
{
    Task SendInformation(string message);
}
