﻿using BloodDonationSystem.Application.Models;
using MediatR;

namespace BloodDonationSystem.Application.Queries.GetAddressById;
public class GetAddressByIdQuery : IRequest<ResultViewModel<AddressViewModel>>
{
    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
