using RestApiWithASPNETCalculator.Model;

namespace RestApiWithASPNETCalculator.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
        List<Person> FindAll();
    }
}
