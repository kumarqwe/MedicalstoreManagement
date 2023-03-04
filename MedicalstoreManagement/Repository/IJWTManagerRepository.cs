using MedicalstoreManagement.Models;
using Newtonsoft.Json.Linq;

namespace MedicalstoreManagement.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
        


    }
}
