using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.UnitTests.Core;
public class DonorTests
{
    [Fact]
    public void Donor_ShouldBeCreatedWithCorrectValues()
    {
        //Arrange
        var fullName = "João da Silva";
        var email = "Joao@hotmail.com";
        var birthDate = new DateTime(1994, 04, 07);
        var gender = "Masculino";
        var weight = 80;
        var bloodType = "A+";
        var rgFactor = "R-";

        //Act
        var donor = new Donor(fullName, email, birthDate, gender, weight, bloodType, rgFactor);

        //Assert
        Assert.Equal(fullName, donor.FullName);
        Assert.Equal(email, donor.Email);
        Assert.Equal(birthDate, donor.BirthDate);
        Assert.Equal(gender, donor.Gender);
        Assert.Equal(weight, donor.Weight);
        Assert.Equal(bloodType, donor.BloodType);
        Assert.Equal(rgFactor, donor.RgFactor);
        Assert.False(donor.IsDeleted);
    }

    [Fact]
    public void Delete_ShouldBeSetIsDeletedTrue()
    {
        //Arrange
        var donor = DonorPropertiesTest();

        //Act
        donor.Delete();

        //Assert
        Assert.True(donor.IsDeleted);
    }

    [Fact]
    public void Restore_ShouldBeSetDeletedFalse()
    {
        var donor = DonorPropertiesTest();

        donor.Restore();

        Assert.False(donor.IsDeleted);
    }

    [Fact]
    public void UpdateEmail_ShouldShangeEmail()
    {
        var donor = DonorPropertiesTest();

        donor.UpdateEmail("novo@email.com");

        Assert.Equal("novo@email.com", donor.Email);
    }

    public Donor DonorPropertiesTest()
    {
        return new Donor("João da Silva", "Joao@hotmail.com", new DateTime(1994, 04, 07), "Masculino", 80, "A+", "R-");
    }
}
