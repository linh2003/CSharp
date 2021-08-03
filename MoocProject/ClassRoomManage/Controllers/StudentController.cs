using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRoomManage.Entity;
using ClassRoomManage.Models;
using ClassRoomManage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomManage.Controllers
{
    public class StudentController : Controller
    {
        private readonly IClassRoomService<Student> _studentService;
        private readonly IClassRoomService<ClassRoom> _classroomService;
        public StudentController(IClassRoomService<Student> studentService, IClassRoomService<ClassRoom> classroomService)
        {
            _studentService = studentService;
            _classroomService = classroomService;
        }
        public IActionResult Index(int? pageNumber, string searchString)
        {
            var students = _studentService.Search(searchString).Select(student => new StudentIndexViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Birthday = student.Birthday,
                ClassRoomId = student.ClassRoomId,
                ClassRoom = student.ClassRoom
            }).ToList();
            int pageSize = 4;

            return View(ManageClassListPagination<StudentIndexViewModel>.Create(students, pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.classRooms = _classroomService.GetAllClassRoomForStudent().ToList();
            var model = new StudentCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Id = model.Id,
                    Name = model.Name,
                    Birthday = model.Birthday,
                    ClassRoomId = model.ClassRoomId
                };
                await _studentService.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.classRooms = _classroomService.GetAllClassRoomForStudent().ToList();
            return View();
        }
        public IActionResult Edit(string id)
        {
            ViewBag.classRooms = _classroomService.GetAllClassRoomForStudent().ToList();
            var student = _studentService.GetById(id);
            if(student == null)
            {
                return NotFound();
            }
            var model = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Birthday = student.Birthday,
                ClassRoomId = student.ClassRoomId,
                ClassRoom = student.ClassRoom
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var student = _studentService.GetById(model.Id);
                if(student == null)
                {
                    return NotFound();
                }
                student.Id = model.Id;
                student.Name = model.Name;
                student.Birthday = model.Birthday;
                student.ClassRoomId = model.ClassRoomId;
                student.ClassRoom = model.ClassRoom;
                await _studentService.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.classRooms = _classroomService.GetAllClassRoomForStudent();
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var student = _studentService.GetById(id);
            if(student == null)
            {
                return NotFound();
            }
            var model = new StudentDeleteViewModel()
            {
                Id = student.Id,
                Name = student.Name
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentDeleteViewModel model)
        {
            await _studentService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
