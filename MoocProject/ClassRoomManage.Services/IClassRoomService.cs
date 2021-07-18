using ClassRoomManage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManage.Services
{
    public interface IClassRoomService
    {
        Task CreateAsync(ClassRoom obj);
        ClassRoom GetById(string id);
        Task UpdateAsync(string id);
        Task Delete(string id);
        IEnumerable<ClassRoom> GetAll();
    }
}
