using Microsoft.AspNetCore.Mvc;
using StudentProject.DTO;
using StudentProject.Models;
using StudentProject.Services;

namespace StudentProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string q)
        {
            ViewBag.Query = q;
            var students = await _service.GetStudentListAsync(q);
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string q)
        {
            var students = await _service.GetStudentListAsync(q);
            return Json(students);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);
            if (student is null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FullName,Email,Phone,JoinDate")] Student student)
        //{
        //    ModelState.Remove("Status");

        //    if (ModelState.IsValid)
        //    {
        //        if (await _service.EmailExistsAsync(student.Email))
        //        {
        //            ModelState.AddModelError("Email", "This email is already in use.");
        //            return View(student);
        //        }

        //        student.Status = "Active";
        //        student.CreatedAt = DateTime.Now;
        //        await _service.AddAsync(student);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            if(await _service.EmailExistsAsync(dto.Email))
            {
                ModelState.AddModelError(nameof(dto.Email), "Email already Exists.");
                return View(dto);
            }

            var student = new Student
            {
                FullName=dto.FullName,
                Email=dto.Email,
                Phone=dto.Phone,
                JoinDate=dto.JoinDate,
                Status="Active",
                CreatedAt=DateTime.Now,
            };
            await _service.AddAsync(student);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);
            if (student is null)
                return NotFound();

            var dto = new EditStudentDto
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                Phone = student.Phone,
                Status = student.Status,
                JoinDate = student.JoinDate
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("StudentId,FullName,Email,Phone,Status,JoinDate,CreatedAt")] Student student)
        //{
        //    if (id != student.StudentId)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        if (await _service.EmailExistsAsync(student.Email, student.StudentId))
        //        {
        //            ModelState.AddModelError("Email", "This email is already in use.");
        //            return View(student);
        //        }

        //        await _service.UpdateAsync(student);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}
        
public async Task<IActionResult> Edit(int id,EditStudentDto dto)
        {
            if (id != dto.StudentId)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            if (await _service.EmailExistsAsync(dto.Email, dto.StudentId))
            {
                ModelState.AddModelError(nameof(dto.Email), "Email already Exists.");
                return View(dto);
            }
            var student = await _service.GetByIdAsync(id);
            if (student is null)
                return NotFound();

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.Phone = dto.Phone;
            student.Status = dto.Status;
            student.JoinDate = dto.JoinDate;

            await _service.UpdateAsync(student);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);
            if (student is null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
