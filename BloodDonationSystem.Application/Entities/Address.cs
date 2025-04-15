namespace BloodDonationSystem.Application.Entities;
public class Address
{
    public Address(int donorId, string street, string city, string state, string cep)
    {
        DonorId = donorId;
        Street = street;
        City = city;
        State = state;
        Cep = cep;
    }
    public int Id { get; private set; }
    public int DonorId {  get; private set; }
    public string Street {  get; private set; }
    public string City { get; private set; }
    public string State {  get; private set; }
    public string Cep {  get; private set; }
    public Donor? Donor { get; private set; }
}
