using ClassRoomManage.Entity;
using ClassRoomManage.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManage.Services.Implementation
{
    public class ClassRoomService : IClassRoomService<ClassRoom>
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

        public IEnumerable<ClassRoom> Search(string data)
        {
            if(String.IsNullOrEmpty(data))
            {
                return _context.ClassRooms.AsNoTracking().OrderBy(emp => emp.NameClassRoom);
            }
            return _context.ClassRooms.Where(e => e.NameClassRoom.Contains(data));
        }

        public IEnumerable<ClassRoom> GetAll() => _context.ClassRooms.AsNoTracking().OrderBy(emp => emp.NameClassRoom);

        public async Task Delete(string id)
        {
            var classroom = GetById(id);
            _context.Remove(classroom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ClassRoom obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllClassRoomForStudent()
        {
            var result = GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.NameClassRoom,
                Value = emp.Id
            });
            return result;
        }
    }
}
