
using webapi.Model;

public interface IAuthRepository
{
    Task<(int, string)> Registeration(RegistrationModel model, string role);
    Task<(int, string)> Login(LoginModel model);
 }