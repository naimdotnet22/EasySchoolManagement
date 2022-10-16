using EasySchoolManagement.Models;
using EasySchoolManagement.Repositories;
using EasySchoolManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStudentrepository _repository;

        public StudentController(IStudentrepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index(string searchString)
        {
            try
            {
                var students = _repository.GetStudents();
                List<StudentListViewModel> studentList = new List<StudentListViewModel>();

                if (!string.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    var searchData = students.Where(c => c.RegistrationNo.ToLower().Contains(searchString) ||
                        c.FirstName.ToLower().Contains(searchString) || c.LastName.ToLower().Contains(searchString) ||
                        c.Email.ToLower().Contains(searchString) || c.CurrentClass.ToString().ToLower().Contains(searchString) ||
                        c.Address.ToLower().Contains(searchString)
                    );

                    foreach (var student in searchData)
                    {
                        StudentListViewModel model = new StudentListViewModel()
                        {
                            Id = student.Id,
                            FullName = student.FirstName + " " + student.LastName,
                            RegistrationNo = student.RegistrationNo,
                            CurrentClass = student.CurrentClass,
                            Gender = student.Gender,
                            Age = student.Age,
                            ContactNo = student.ContactNo,
                            Email = student.Email,
                            Address = student.Address,
                            CreatedBy = student.CreatedBy,
                            CreatedDate = student.CreatedDate
                        };
                        studentList.Add(model);
                    }
                    return View(studentList);
                }
                else
                {
                    foreach (var student in students)
                    {
                        StudentListViewModel model = new StudentListViewModel()
                        {
                            Id = student.Id,
                            FullName = student.FirstName + " " + student.LastName,
                            RegistrationNo = student.RegistrationNo,
                            CurrentClass = student.CurrentClass,
                            Gender = student.Gender,
                            Age = student.Age,
                            ContactNo = student.ContactNo,
                            Email = student.Email,
                            Address = student.Address,
                            CreatedBy = student.CreatedBy,
                            CreatedDate = student.CreatedDate
                        };
                        studentList.Add(model);
                    }
                    return View(studentList);
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Error Occured While Loading Data!";
                return View();
            }
        }

        public IActionResult SaveStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveStudent(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = GetLoggedInUser();
                var userDetail = _userManager.FindByIdAsync(user.Id.ToString());
                string userName = user.Result.UserName;

                Student student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegistrationNo = model.RegistrationNo,
                    CurrentClass = model.CurrentClass,
                    Gender = model.Gender,
                    Age = model.Age,
                    ContactNo = model.ContactNo,
                    Email = model.Email,
                    Address = model.Address,
                    CreatedBy = userName,
                    CreatedDate = DateTime.Now
                };
                _repository.AddOrUpdateStudent(student);
                return RedirectToAction("StudentDetails", new { id = student.Id });
            }
            ViewBag.Message = $"Error Occured While Saving Data!";
            return View();
        }


        public IActionResult UpdateStudent(int id)
        {
            try
            {
                if (id > 0)
                {
                    Student student = new Student();
                    student = _repository.GetStudentById(id);
                    if (student != null)
                    {
                        StudentUpdateViewModel model = new StudentUpdateViewModel()
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            RegistrationNo = student.RegistrationNo,
                            CurrentClass = student.CurrentClass,
                            Gender = student.Gender,
                            Age = student.Age,
                            ContactNo = student.ContactNo,
                            Email = student.Email,
                            Address = student.Address,
                            CreatedBy = student.CreatedBy,
                            CreatedDate = student.CreatedDate,
                        };
                        return View(model);
                    }
                }
                ViewBag.Message = $"Error Occured While Getting Data!";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Message = $"Error Occured While Getting Data!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentUpdateViewModel model)
        {
            try
            {
                Student student = new Student()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegistrationNo = model.RegistrationNo,
                    CurrentClass = model.CurrentClass,
                    Gender = model.Gender,
                    Age = model.Age,
                    ContactNo = model.ContactNo,
                    Email = model.Email,
                    Address = model.Address,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate
                };
                _repository.AddOrUpdateStudent(student);
                return RedirectToAction(nameof(StudentDetails), new { id = student.Id });
            }
            catch (Exception)
            {
                ViewBag.Message = $"Error Occured While Updating Data!";
                return View();
            }
        }


        public IActionResult StudentDetails(int id)
        {
            if (id > 0)
            {
                Student student = _repository.GetStudentById(id);
                if (student != null)
                {
                    StudentDetailViewModel model = new StudentDetailViewModel()
                    {
                        Id = student.Id,
                        FullName = student.FirstName + " " + student.LastName,
                        RegistrationNo = student.RegistrationNo,
                        CurrentClass = student.CurrentClass,
                        Gender = student.Gender,
                        Age = student.Age,
                        ContactNo = student.ContactNo,
                        Email = student.Email,
                        Address = student.Address,
                        CreatedBy = student.CreatedBy,
                        CreatedDate = student.CreatedDate
                    };
                    return View(model);
                }
            }
            return View();
        }


        public IActionResult DeleteStudent(int id)
        {
            if (id > 0)
            {
                _repository.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        #region Private Methods
        private async Task<ApplicationUser> GetLoggedInUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        #endregion

    }
}
