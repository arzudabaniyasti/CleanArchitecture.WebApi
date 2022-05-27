using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public decimal Rate { get; set; } no rate in category
        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<int>>
        {
            private readonly ICategoryRepositoryAsync _categoryRepository;
            public UpdateCategoryCommandHandler(ICategoryRepositoryAsync categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<Response<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(command.Id);

                if (category == null)
                {
                    throw new ApiException($"Category Not Found.");
                }
                else
                {
                    category.Name = command.Name;
                    //product.Rate = command.Rate;
                    category.Description = command.Description;
                    await _categoryRepository.UpdateAsync(category);
                    return new Response<int>(category.Id);
                }
            }
        }
    }
}
