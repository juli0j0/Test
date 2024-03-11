using TestServer.DB.Interfaces.Repositories;
using TestServer.DTO.General;

namespace TestServer.DB.Repositories
{
    internal class LoginRepository : ILoginRepository
    {
        private readonly string a = "";
        public bool ValidateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
