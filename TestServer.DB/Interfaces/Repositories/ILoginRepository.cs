using TestServer.DTO.General;

namespace TestServer.DB.Interfaces.Repositories
{
    internal interface ILoginRepository
    {
        bool ValidateUser(UserDTO user);
    }
}
