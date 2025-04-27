using BloodDonationSystem.Application.Models;

namespace BloodDonationSystem.Infrastucture.Cep;
public interface ICepService
{
    Task<ViaCepViewModel?> ConsultarCepAsync(string cep);
}
