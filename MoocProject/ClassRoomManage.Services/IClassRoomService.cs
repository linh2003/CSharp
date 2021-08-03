using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomManage.Services
{
    public interface IClassRoomService<T>
    {
        Task CreateAsync(T obj);
        T GetById(string id);
        Task UpdateAsync(T obj);
        Task Delete(string id);

        IEnumerable<T> GetAll();
        IEnumerable<SelectListItem> GetAllClassRoomForStudent();

        IEnumerable<T> Search(string data);
    }
}
