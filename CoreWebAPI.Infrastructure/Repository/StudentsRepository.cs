using CoreWebAPI.Infrastructure.Interfaces;
using CoreWebAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPI.Infrastructure.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        StudentsContext _context = new StudentsContext();        

        public async Task<List<Students>> GetAllStudent()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<Students> GetStudent(int studentID)
        {
            return await _context.Student.Where(x => x.StudentID == studentID).FirstOrDefaultAsync();
        }

        public async Task<Students> InsertStudent(StudentCreateViewModel student)
        {
            Students model = new Students();
            if (student != null)
            {
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.PhoneNumber = student.PhoneNumber;
                model.City = student.City;

                _context.Student.Add(model);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<Students> UpdateStudent(StudentCreateViewModel student)
        {
            var model = await _context.Student.Where(x => x.StudentID == student.StudentID).FirstOrDefaultAsync();
            if (model != null)
            {
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.PhoneNumber = student.PhoneNumber;
                model.City = student.City;

                _context.Student.Update(model);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task DeleteStudent(int studentID)
        {
            var model = await _context.Student.Where(x => x.StudentID == studentID).FirstOrDefaultAsync();
            if (model != null)
            {
                _context.Student.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
