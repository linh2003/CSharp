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
    public class StudentService : IClassRoomService<Student>
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Student obj)
        {
            await _context.Students.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var student = GetById(id);
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Student> GetAll() => _context.Students;

        public Student GetById(string id) => _context.Students.Where(e => e.Id == id).FirstOrDefault();

        public IEnumerable<Student> Search(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return _context.Students.AsNoTracking().OrderBy(emp => emp.Name);
            }
            return _context.Students.Where(e => e.Name.Contains(data));
        }

        public async Task UpdateAsync(Student obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllClassRoomForStudent()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.ClassRoom.NameClassRoom,
                Value = emp.ClassRoomId
            });
        }
    }
}
