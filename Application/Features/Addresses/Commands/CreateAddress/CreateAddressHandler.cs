using Application.Contracts.Features.Addresses.Commands.CreateAddress;
using Clients.Contracts;
using Domain.Entities.Addresses;
using Domain.Entities.Addresses.Parameters;
using Mediator;
using Persistence.Contracts;

namespace Application.Features.Addresses.Commands.CreateAddress;

internal sealed class CreateAddressHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<CreateAddressCommand, CreateAddressResponseDto>
{
    public async ValueTask<CreateAddressResponseDto> Handle(
        CreateAddressCommand request,
        CancellationToken cancellationToken)
    {
        var address = new Address(new CreateAddressParameters
        {
            Title = request.Body.Title,
            City = request.Body.City,
            Street = request.Body.Street,
            House = request.Body.House,
            Root = request.Body.Root,
            Number = request.Body.Number,
            Comment = request.Body.Comment,
            ClientId = currentClient.ClientId,
            TimeProvider = timeProvider
        });
        
        context.Addresses.Add(address);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateAddressResponseDto
        {
            AddressId = address.Id
        };
    }
}