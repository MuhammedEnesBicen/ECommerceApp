using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {

        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
        {
            private readonly ICategoryRepository _categoryRepository;

            public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }

            public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var result = await _categoryRepository.GetAsync();
                return result;
            }
        }
    }
}