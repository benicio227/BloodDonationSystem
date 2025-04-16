using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.Application.Models;
public class AddressViewModel
{
    public AddressViewModel(int id, int donorId, string street, string city, string state, string cep)
    {
        Id = id;
        DonorId = donorId;
        Street = street;
        City = city;
        State = state;
        Cep = cep;
    }
    public int Id { get; private set; }
    public int DonorId { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Cep { get; private set; }
    public Donor? Donor { get; private set; }

    public static AddressViewModel FromEntity(Address address)
    {
        return new AddressViewModel(address.Id, address.DonorId, address.Street, address.City, address.State, address.Cep);
    }
}
