using BloodDonationSystem.Application.Commands.InsertAddress;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Application.Models;
using BloodDonationSystem.Core.Repositories;
using BloodDonationSystem.Infrastucture.Cep;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application.Commands;
public class InsertAddressHandlerTests
{
    [Fact]
    public async Task AddressExists_Insert_Success()
    {
        //Arrange

        var repository = Substitute.For<IAddressRepository>();
        var cepService = Substitute.For<ICepService>();

        var command = new InsertAddressCommand
        {
            DonorId = 12345,
            Street = "Rua das Flores",
            Cep = "12345678"
        };

        var fakeCepInfo = new ViaCepViewModel
        {
            Logradouro = "Rua das Flores",
            Localidade = "Cidade X",
            Uf = "UF"
        };

        cepService.ConsultarCepAscyn(command.Cep).Returns(fakeCepInfo);

        var addedAddress = new Address(
            command.DonorId,
            fakeCepInfo.Logradouro,
            fakeCepInfo.Localidade,
            fakeCepInfo.Uf,
            command.Cep
        );

        repository.Add(Arg.Any<Address>()).Returns(addedAddress);

        var handler = new InsertAddressHandler(repository, cepService);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Data);
        Assert.Equal(command.DonorId, result.Data!.DonorId);
        Assert.Equal(fakeCepInfo.Logradouro, result.Data.Street);
        Assert.Equal(fakeCepInfo.Localidade, result.Data.City);
        Assert.Equal(fakeCepInfo.Uf, result.Data.State);
        Assert.Equal(command.Cep, result.Data.Cep);

    }

    [Fact]
    public async Task InvalidCep_ReturnsCep()
    {
        //Arrange
        var repository = Substitute.For<IAddressRepository>();
        var cepService = Substitute.For<ICepService>();

        var command = new InsertAddressCommand
        {
            DonorId = 1234,
            Cep = "00000-000",
            Street = "Rua das Flores"
        };

        cepService.ConsultarCepAscyn(command.Cep).Returns((ViaCepViewModel?)null);

        var handler = new InsertAddressHandler(repository, cepService);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("CEP inválido ou não encontrado.", result.Message);
    }

    [Fact]
    public async Task NoStreetFound_ReturnsError()
    {
        var repository = Substitute.For<IAddressRepository>();
        var cepService = Substitute.For<ICepService>();

        var fakeCepInfo = new ViaCepViewModel
        {
            Logradouro = "",
            Localidade = "São Paulo",
            Uf = "SP"
        };

        var command = new InsertAddressCommand
        {
            DonorId = 12345,
            Cep = "12345-3456",
            Street = "string"
        };

        cepService.ConsultarCepAscyn(command.Cep).Returns(fakeCepInfo);

        var handler = new InsertAddressHandler(repository, cepService);

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Não foi possível encontrar o nome da rua.", result.Message);
    }

    [Fact]
    public async Task DonorIdNotFound_ReturnsError()
    {
        //Arrange

        var repository = Substitute.For<IAddressRepository>();
        var cepService = Substitute.For<ICepService>();

        var fakeCepInfo = new ViaCepViewModel
        {
            Logradouro = "Rua Exemplo",
            Localidade = "São Paulo",
            Uf = "SP"
        };

        var command = new InsertAddressCommand
        {
            DonorId = 12345,
            Street = "Rua Exemplo",
            Cep = "1234-7678"
        };

        cepService.ConsultarCepAscyn(command.Cep).Returns(fakeCepInfo);

        repository.Add(Arg.Any<Address>()).Returns((Address?)null);

        var handler = new InsertAddressHandler(repository, cepService);

        var result = await handler.Handle(command, new CancellationToken());

        Assert.False(result.IsSuccess);
        Assert.Equal($"Nenhum ID {command.DonorId} foi encontrado.", result.Message);
    }
}
