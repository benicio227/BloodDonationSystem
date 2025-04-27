using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.UnitTests.Core;
public class DonationTests
{
    [Fact]
    public void Donation_ShouldBeCreatedWithCorrectValues()
    {

        var donorId = 1;
        var amountMl = 470;


        var donation = new Donation(donorId, amountMl);


        Assert.Equal(donorId, donation.DonorId);
        Assert.Equal(amountMl, donation.AmountMl);
     
    }

    [Fact]
    public void Delete_ShouldBeSetIsDeletedTrue()
    {

        var donation = DonationPropertiesTest();


        donation.Delete();


        Assert.True(donation.IsDeleted);
    }

    [Fact]
    public void Restore_ShouldBeSetDeletedFalse()
    {
        var donation = DonationPropertiesTest();

        donation.Restore();

        Assert.False(donation.IsDeleted);
    }

    public Donation DonationPropertiesTest()
    {
        return new Donation(1, 470);
    }
}
