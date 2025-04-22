using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class UpdateAddressViewModel
{
    public UpdateAddressViewModel(string street, string city, string state, string cep)
    {
        Street = street;
        City = city;
        State = state;
        Cep = cep;
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Cep { get; private set; }

    public UpdateAddressViewModel FromEntity(Address address)
    {
        return new UpdateAddressViewModel(address.Street, address.City, address.State, address.Cep);
    }
}
