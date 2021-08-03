using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassRoomManage.Services;
using ClassRoomManage.Models;
using ClassRoomManage.Entity;
using ClassRoomManage.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomManage.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService<ClassRoom> _classroomService;
        private readonly ApplicationDbContext db;
        public ClassRoomController(IClassRoomService<ClassRoom> classroomService)
        {
            _classroomService = classroomService;
        }
        public IActionResult Index(int? pageNumber,string searchString)
        {
            var classRooms = _classroomService.Search(searchString).Select(classRoom => new ClassRoomIndexViewModel
            {
                Id = classRoom.Id,
                NameClassRoom = classRoom.NameClassRoom,
                DescribeClassRoom = classRoom.DescribeClassRoom
            }).ToList();
            int pageSize = 4;

            return View(ManageClassListPagination<ClassRoomIndexViewModel>.Create(classRooms, pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ClassRoomCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassRoomCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var classroom = new ClassRoom
                {
                    Id = model.Id,
                    NameClassRoom = model.NameClassRoom,
                    DescribeClassRoom = model.DescribeClassRoom
                };
                await _classroomService.CreateAsync(classroom);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(string id)
        {
            var classroom = _classroomService.GetById(id);
            if(classroom == null)
            {
                return NotFound();
            }
            var model = new ClassRoomEditViewModel()
            {
                Id = classroom.Id,
                NameClassRoom = classroom.NameClassRoom,
                DescribeClassRoom = classroom.DescribeClassRoom

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClassRoomEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var classroom = _classroomService.GetById(model.Id);
                if(classroom == null)
                {
                    return NotFound();
                }
                classroom.Id = model.Id;
                classroom.NameClassRoom = model.NameClassRoom;
                classroom.DescribeClassRoom = model.DescribeClassRoom;
                await _classroomService.UpdateAsync(classroom);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var classroom = _classroomService.GetById(id);
            if(classroom == null)
            {
                return NotFound();
            }
            var model = new ClassRoomDeleteViewModel()
            {
                Id = classroom.Id,
                NameClassRoom = classroom.NameClassRoom
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClassRoomDeleteViewModel model)
        {
            await _classroomService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
