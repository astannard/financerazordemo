using ServiceInterfaces.Model;

public interface IUserService
{
    Task<User> GetUser();
}