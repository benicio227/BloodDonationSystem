using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.UnitTests.Core;
public class AddressTests
{
    [Fact]
    public void Address_ShouldBeCreatedWithCorrectValues()
    {
       
        var donorId = 1;
        var street = "Rua das flores";
        var city = "Aracaju";
        var state = "Sergipe";
        var cep = "12345678";

       
        var address = new Address(donorId, street, city, state, cep);

      
        Assert.Equal(donorId, address.DonorId);
        Assert.Equal(street, address.Street);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(cep, address.Cep);

    }

    [Fact]
    public void Delete_ShouldBeSetIsDeletedTrue()
    {
       
        var address = AddressPropertiesTest();

       
        address.Delete();

    
        Assert.True(address.IsDeleted);
    }

    [Fact]
    public void Restore_ShouldBeSetDeletedFalse()
    {
        var address = AddressPropertiesTest();

        address.Restore();

        Assert.False(address.IsDeleted);
    }

    public Address AddressPropertiesTest()
    {
        return new Address(1, "Rua dad flores", "Aracaju", "Sergipe", "12345678");
    }
}
