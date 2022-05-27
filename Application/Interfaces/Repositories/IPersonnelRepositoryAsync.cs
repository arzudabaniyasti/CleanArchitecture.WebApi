using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPersonnelRepositoryAsync : IGenericRepositoryAsync<Personnel>
    {
        public Task<IReadOnlyList<Personnel>> GetPersonnelsWithRelationsAsync(int pageNumber, int pageSize);
        public Task<Personnel> GetPersonnelByIdWithRelationsAsync(int personnelId);
    }
}
