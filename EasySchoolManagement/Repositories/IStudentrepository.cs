using EasySchoolManagement.Models;
using System.Collections.Generic;

namespace EasySchoolManagement.Repositories
{
    public interface IStudentrepository
    {
        void AddOrUpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetStudents();
    }
}