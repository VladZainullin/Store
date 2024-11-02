using MediatR;

namespace Application.Contracts.Features.Carts.Commands.CleanCart;

public sealed record CleanCartCommand : IRequest;