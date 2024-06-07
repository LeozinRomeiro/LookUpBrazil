using LookUpBrazil.Core.ObjectValues;
using LookUpBrazil.Core.Requests.City;
using LookUpBrazil.Core.Responses;
using LookUpBrazil.Test.Repositories;

namespace LookUpBrazil.Test.Handler;

[TestClass]
public class CityTest
{
    public FakeCityRepository CityRepository = new FakeCityRepository();
    [TestMethod]
    public void DadoUmCityValidoDeveRetornarSucesso()
    {
        var request = new ValidCityRequest
        {
            Name = new Name("Maringa")
        };

        var city = CityRepository.CityExists(request.Name.TextCompleted);

        Response<City?> response;

        if (city is null)
        {
            response = new Response<City?>(null, 300, "Cidade não é valida");
        }
        else
        {
            response = new Response<City?>(city);
        }

        Assert.IsTrue(response.IsSuccess);
    }
}