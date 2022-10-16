using EasySchoolManagement.Data;
using EasySchoolManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasySchoolManagement.Repositories
{
    public class Studentrepository : IStudentrepository
    {
        private readonly AppDbContext _dbContext;

        public Studentrepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Student CRUD
        public List<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }


        public Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(c => c.Id == id);
        }


        public void AddOrUpdateStudent(Student student)
        {
            if (student.Id > 0)
                _dbContext.Entry(student).State = EntityState.Modified;
            else
                _dbContext.Students.Add(student);

            SaveChanges();
        }


        public void DeleteStudent(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(c => c.Id == id);
            _dbContext.Students.Remove(student);
            SaveChanges();
        }
        #endregion


        #region Private Methods
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion


    }
}
