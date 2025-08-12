namespace eCommerce.Application.Services.Interfaces.Logging
{
    public interface IAppLogger<T>
    {
        void LogInfromation(string message);
        void LogWarning(string message);
        void LogError(Exception ex, string message);
    }
}
