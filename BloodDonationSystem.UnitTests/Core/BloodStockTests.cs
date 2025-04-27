using BloodDonationSystem.Application.Entities;

namespace BloodDonationSystem.UnitTests.Core;
public class BloodStockTests
{
    [Fact]
    public void BloodStock_ShouldBeCreatedWithCorrectValues()
    {
        //Arrange
        var bloodTye = "A+";
        var rgFactor = "R+";
        var amountMl = 0;
        var minimumAmountMl = 1000;

        //Act
        var bloodStock = new BloodStock(bloodTye, rgFactor, amountMl, minimumAmountMl);

        //Assert
        Assert.Equal(bloodTye, bloodStock.BloodType);
        Assert.Equal(rgFactor, bloodStock.RgFactor);
        Assert.Equal(amountMl, bloodStock.AmountMl);
        Assert.Equal(minimumAmountMl, bloodStock.MinimumAmountMl);
    }

    [Fact]
    public void Delete_ShouldBeSetIsDeletedTrue()
    {
      
        var bloodStock = BloodStockPropertiesTest();

       
        bloodStock.Delete();

     
        Assert.True(bloodStock.IsDeleted);
    }

    [Fact]
    public void Restore_ShouldBeSetDeletedFalse()
    {
        var bloodStock = BloodStockPropertiesTest();

        bloodStock.Restore();

        Assert.False(bloodStock.IsDeleted);
    }

    [Fact]
    public void UpdateAmount_ShouldShangeAmount()
    {
        var bloodStock = BloodStockPropertiesTest();

        bloodStock.AddAmount(470);

        Assert.Equal(470, bloodStock.AmountMl);
    }

    public BloodStock BloodStockPropertiesTest()
    {
        return new BloodStock("A+", "R+", 0, 1000);
    }
}
