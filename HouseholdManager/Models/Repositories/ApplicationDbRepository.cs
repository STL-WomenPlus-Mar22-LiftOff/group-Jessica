using HouseholdManager.Areas.Identity.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace HouseholdManager.Models.Repositories
{
    public interface IApplicationDbRepository
    {
        Task<List<MessageProperty>> ListAllMessagePropertyAsync();
        Task<MessageProperty> FindMessagePropertyFirstOrDefaultAsync(int? id);
        Task<int> CreateMessagePropertyAsync(MessageProperty messageProperty);
        Task<int> UpdateMessagePropertyAsync(MessageProperty messageProperty);
        Task<int> DeleteMessagePropertyAsync(MessageProperty messageProperty);

        Task<int> CreateSendAsync(Send send);
        Task<Send> FindSendWithRelationsAsync(int id);
        Task<Send> FindFirstPendingSendByHostAsync(string hostId);
        Task<int> UpdateSendAsync(Send send);

        Task<TwilioUser> FindUserByPhoneNumberAsync(string number);
        Task FindSendFirstOrDefaultAsync(int? id);
        Task FindFirstSendByHostAsync(string id);
    }

    public class ApplicationDbRepository : IApplicationDbRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MessageProperty>> ListAllMessagePropertyAsync()
        {
            return await _context.MessageProperty.ToListAsync();
        }

        public async Task<MessageProperty> FindMessagePropertyFirstOrDefaultAsync(int? id)
        {
            return await _context.MessageProperty.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> CreateMessagePropertyAsync(MessageProperty messageProperty)
        {
            _context.Add(messageProperty);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateMessagePropertyAsync(MessageProperty messageProperty)
        {
            _context.Add(messageProperty);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteMessagePropertyAsync(MessageProperty messageProperty)
        {
            _context.MessageProperty.Remove(messageProperty);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateSendAsync(Send send)
        {
            _context.Add(send);

            return await _context.SaveChangesAsync();
        }

        public async Task<Send> FindSendWithRelationsAsync(int id)
        {
            return await _context.Send
                .Where(r => r.Id == id)
                .Include(r => r.MessageProperty)
                .FirstAsync();
        }

        public async Task<Send> FindFirstPendingSendByHostAsync(string hostId)
        {
            return await _context.Send
                .Where(r => r.MessageProperty.UserId == hostId && r.Status == MessageStatus.Pending)
                .Include(r => r.MessageProperty)
                .FirstAsync();
        }

        public async Task<int> UpdateSendAsync(Send send)
        {
            _context.Send.Update(send);
            return await _context.SaveChangesAsync();
        }


        public async Task<TwilioUser> FindUserByPhoneNumberAsync(string number)
        {
            return await _context.TwilioUser.FirstAsync(u => u.PhoneNumber == number);
        }

        public Task<MessageProperty> FindVacationPropertyFirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

       

        public Task FindFirstSendByHostAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task FindSendFirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}