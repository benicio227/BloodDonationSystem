using BloodDonationSystem.Application.Models;
using System.Text.Json;

namespace BloodDonationSystem.Infrastucture.Cep;
public class CepService : ICepService
{
    private readonly HttpClient _httpClient;

    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ViaCepViewModel?> ConsultarCepAsync(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ViaCepViewModel>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }
}
