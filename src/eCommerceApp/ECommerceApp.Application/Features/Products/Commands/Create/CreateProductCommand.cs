using AutoMapper;
using ECommerceApp.Application.Features.Products.Dtos;
using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreateProductDto>
{
    public CreateProductDto createProductDto { get; set; }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _productRepository.CreateAsync(product);

            return Task.FromResult(_mapper.Map<CreateProductDto>(product));


        }
    }
}