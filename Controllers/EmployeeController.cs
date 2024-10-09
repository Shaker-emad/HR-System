using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project12.Models;
using System.Linq;


namespace project12.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Department = _context.Departments.ToList();
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            ViewBag.Department = _context.Departments.ToList(); // تحميل جميع الأقسام

            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult CreateEmp()
        {
            ViewBag.Department = _context.Departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CreateEmp(Employee employee)
        {
            if (employee.ImageFile != null)
            {
                // تحديد مسار حفظ الصورة
                var fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                var extension = Path.GetExtension(employee.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                var path = Path.Combine("wwwroot/Image/", fileName);

                // حفظ الصورة في المجلد
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    employee.ImageFile.CopyTo(fileStream);
                }

                // تخزين مسار الصورة في خاصية Image
                employee.Image = fileName;
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employee/EditEmp/1
        [HttpGet]
        public IActionResult EditEmp(int id)
        {
            // Retrieve the employee record
               var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id);


            if (employee == null)
            {
                return NotFound();
            }

            // Populate departments for the dropdown
            ViewBag.Departments = _context.Departments.ToList(); // Make sure to use 'Departments'

            return View(employee);
        }
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> EditEmp(Employee updatedEmployee)
        {
            ViewBag.Departments = _context.Departments.ToList();

            // حاول العثور على الموظف باستخدام معرّف الموظف
            var existingEmployee = _context.Employees.Find(updatedEmployee.EmployeeId);
            if (existingEmployee == null)
            {
                return NotFound(); // الموظف غير موجود
            }

            // تحديث الخصائص الأساسية
            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
            existingEmployee.Gender = updatedEmployee.Gender;
            existingEmployee.Position = updatedEmployee.Position;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.HireDate = updatedEmployee.HireDate;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Phone = updatedEmployee.Phone;
            existingEmployee.DepartmentId = updatedEmployee.DepartmentId;

            // تحديث الصورة إذا تم تحميل صورة جديدة
            if (updatedEmployee.ImageFile != null)
            {
                // حذف الصورة القديمة إذا كانت موجودة
                if (!string.IsNullOrEmpty(existingEmployee.Image))
                {
                    var oldImagePath = Path.Combine("wwwroot/Image", existingEmployee.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // حفظ الصورة الجديدة
                var fileName = Path.GetFileNameWithoutExtension(updatedEmployee.ImageFile.FileName);
                var extension = Path.GetExtension(updatedEmployee.ImageFile.FileName);
                var newImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                var path = Path.Combine("wwwroot/Image", newImageName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await updatedEmployee.ImageFile.CopyToAsync(fileStream);
                }

                // تحديث مسار الصورة
                existingEmployee.Image = newImageName;
            }

            // حفظ التغييرات
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }






    }

}

