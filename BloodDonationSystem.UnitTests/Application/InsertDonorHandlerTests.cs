using BloodDonationSystem.Application.Commands.InsertDonor;
using BloodDonationSystem.Application.Entities;
using BloodDonationSystem.Core.Repositories;
using NSubstitute;

namespace BloodDonationSystem.UnitTests.Application;
public class InsertDonorHandlerTests
{
    [Fact]
    public async Task InputDataAreOk_Insert_Success_NSubstitute()
    {
        // Arrange
        var repository = Substitute.For<IDonorRepository>(); // Cria um falso repositório usando NSubstitute
                                                           // Esse substituto vai simular o comportamento da interface

        // Cria um doador com dados válidos
        var donor = new Donor("João da Silva", "joao@email.com", new DateTime(1994, 4, 7), "Masculino", 80, "A+", "R-");

        // Simula que não existe nenhum doador cadastrado com esse e-mail
        // O null! é só para o compilador não reclamar de null(você está dizendo: "confia em mim, é null mesmo")
        repository.GetByEmail(donor.Email).Returns((Donor)null!);

        //Simula que quando o método Add() for chamado com qualquer doador, ele vai retornar esse donor que você criou
        // Isso imita o que aconteceria se o banco salvasse e devolvesse o doador salvo
        repository.Add(Arg.Any<Donor>()).Returns(donor);

        // Cria o command com os dados do doador(é como se fosse a requisição da API)
        // Esses dados são passados para o Handler
        var command = new InsertDonorCommand
        {
            FullName = donor.FullName,
            Email = donor.Email,
            BirthDate = donor.BirthDate,
            Gender = donor.Gender,
            Weight = donor.Weight,
            BloodType = donor.BloodType,
            RgFactor = donor.RgFactor,
        };

        // Instancia o InsertDonorHandler, que é a classe que você quer testar
        // Você passa o repositório para ela
        var handler = new InsertDonorHandler(repository);


        //Act
        // Aqui chamamos o método que insere o doador
        // Ele vai utilizar o repositório que simulamos
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        // Verifica se o resultado foi um sucesso
        Assert.True(result.IsSuccess);
        // Verifica se o objeto retornado não está nulo
        Assert.NotNull(result.Data);

        // Garante que o nome do doador que foi retornado é o mesmo que foi enviado.
        Assert.Equal(command.FullName, result.Data.FullName);
    }


    [Fact]
    public async Task DonorAlreadyExists_ReturnsError()
    {
        // Arrange
        var repository = Substitute.For<IDonorRepository>();

        var existingDonor = new Donor("João da Silva", "joao@email.com", new DateTime(1994, 4, 7), "Masculino", 80, "A+", "R-");

        // Simula que o doador já existe no banco
        repository.GetByEmail(existingDonor.Email).Returns(existingDonor);

        var command = new InsertDonorCommand
        {
            FullName = existingDonor.FullName,
            Email = existingDonor.Email,
            BirthDate = existingDonor.BirthDate,
            Gender = existingDonor.Gender,
            Weight = existingDonor.Weight,
            BloodType = existingDonor.BloodType,
            RgFactor = existingDonor.RgFactor,
        };

        var handler = new InsertDonorHandler(repository);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.IsSuccess); // Esperamos falha
        Assert.Null(result.Data);       // Não retorna dados
        Assert.Equal("Já existe um doador com esse E-mail.", result.Message);
    }

    // O que acontece quando o teste roda?
    // 1 - O InsertDonorHandler é chamado de verdade no meu teste, igual na aplicação real
    // 2 - Só que o repositório(IDonorRepository) que ele usa não é de verdade, ele é um falso(Substitute.For<IDonorRepository>).
    // até porque não queremos nenhuma resposta real do banco de dados
    // 3 - Esse repositório fake obedece exatamente o que você mandou ele fazer: repository.GetByEmail(existingDonor.Email).Returns(existingDonor);
    // ou seja, quando o handler chamar o GetByEmail ele vai achar que já existe um doador
    // 4 - o handler.Handle() então vai seguir o normal do código: 
    // - Vê que já existe doador
    // - Retorna um ResultViewModel<DonorViewModel>.Error("Já existe um doador com esse E-mail.").
    // 5 - No final, o result.IsSuccess é false, porque foi construído com isSuccess: false.
}
