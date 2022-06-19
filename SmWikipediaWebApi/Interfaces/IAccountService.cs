using SmWikipediaWebApi.Models;

namespace SmWikipediaWebApi.Interfaces
{
    public interface IAccountService
    {
        public void Add(AdministratorCreateDto adminDto);
        public string GenerateJwt(LoginDto login);
        public void Delete(int id);
        object GetAdmins();
    }
}
