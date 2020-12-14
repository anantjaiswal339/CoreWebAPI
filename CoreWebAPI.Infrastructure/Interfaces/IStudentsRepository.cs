using CoreWebAPI.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPI.Infrastructure.Interfaces
{
    public interface IStudentsRepository
    {
        public Task<List<Students>> GetAllStudent();
        public Task<Students> GetStudent(int studentID);
        public Task<Students> InsertStudent(StudentCreateViewModel student);
        public Task<Students> UpdateStudent(StudentCreateViewModel student);
        public Task DeleteStudent(int studentID);
    }
}