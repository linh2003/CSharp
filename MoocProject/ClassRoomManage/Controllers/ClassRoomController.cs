using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassRoomManage.Models;
using ClassRoomManage.Services;

namespace ClassRoomManage.Controllers
{
    
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService _classroomService;
        public ClassRoomController(IClassRoomService classroomService)
        {
            _classroomService = classroomService;
        }
        public IActionResult Index()
        {
            var classRooms = _classroomService.GetAll().Select(classRoom => new ClassRoomIndexViewModel
            {
                Id = classRoom.Id,
                NameClassRoom = classRoom.NameClassRoom,
                DescribeClassRoom = classRoom.DescribeClassRoom
            }).ToList();
            return View(classRooms);
        }
    }
}
