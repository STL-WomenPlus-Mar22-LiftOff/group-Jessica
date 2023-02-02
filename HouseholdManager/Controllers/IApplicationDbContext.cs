using HouseholdManager.Models;

namespace HouseholdManager.Controllers
{
    internal interface IApplicationDbContext
    {
        Task CreateSendAsync(Send send);
        Task FindMessagePropertyFirstOrDefaultAsync(int? id);
        Task FindSendWithRelationsAsync(int id);
    }
}