using Gifter2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gifter2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Gifter2.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile
                .Include(up => up.UserProfile)
                .OrderByDescending(p => p.DateCreated)
                .Take(3)
                .ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile
                .Include(p => p.UserProfile)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(UserProfile post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public void Update(UserProfile post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var userUserProfiles = _context.UserProfile.Where(p = p.UserProfileId == id);
            _context.UserProfile.RemoveRange(userUserProfiles);
            _context.SaveChanges();

            var user = GetById(id);
            _
        }
    }
}
