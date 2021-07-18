using ClassRoomManage.Entity;
using ClassRoomManage.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClassRoomManage.Services.Implementation
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly ApplicationDbContext _context;
        public ClassRoomService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ClassRoom obj)
        {
            await _context.ClassRooms.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public ClassRoom GetById(string id) =>
            _context.ClassRooms.Where(e => e.Id == id).FirstOrDefault();

        public IEnumerable<ClassRoom> GetAll() => _context.ClassRooms;

        public async Task Delete(string id)
        {
            var classroom = GetById(id);
            _context.Remove(classroom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id)
        {
            var classroom = GetById(id);
            _context.Update(classroom);
            await _context.SaveChangesAsync();
        }
    }
}
