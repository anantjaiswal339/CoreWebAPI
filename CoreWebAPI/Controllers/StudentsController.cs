using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPI.Infrastructure;
using CoreWebAPI.Infrastructure.Interfaces;
using CoreWebAPI.Infrastructure.Models;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        [ActionName("GetStudents")]
        public async Task<APIResponse> GetStudents()
        {
            APIResponse response = new APIResponse();
            try
            {
                var students = await _studentsRepository.GetAllStudent();
                if (students.Count > 0)
                {
                    response.ResponseData = students;
                    response.StatusCode = 200;
                }
                else
                {
                    response.StatusCode = 204;
                    response.StatusMessage = "No records found.";
                }
                
                return response;
                //return Ok(await _studentsRepository.GetAllStudent());
            }
            catch
            {
                response.StatusCode = 500;
                response.StatusMessage = "Failed to get students data.";
                return response;
            }
        }

        [HttpGet]
        [ActionName("GetStudent/{id}")]
        public async Task<APIResponse> Get(int id)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.ResponseData = await _studentsRepository.GetStudent(id);
                response.StatusCode = 200;
                return response;
            }
            catch
            {
                response.StatusCode = 500;
                response.StatusMessage = "Failed to get student data.";
                return response;
            }
        }

        [HttpPost]
        [ActionName("InsertStudent")]
        public async Task<APIResponse> Post([FromBody] StudentCreateViewModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                response.ResponseData = await _studentsRepository.InsertStudent(model);
                response.StatusCode = 200;
                return response;            
            }
            catch
            {
                response.StatusCode = 500;
                response.StatusMessage = "Failed to insert record.";
                return response;
            }
        }

        [HttpPut("{id}")]
        [ActionName("UpdateStudent")]
        public async Task<APIResponse> Put(int id, [FromBody] StudentCreateViewModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                model.StudentID = id;
                var student = await _studentsRepository.UpdateStudent(model);
                if (student != null)
                {
                    response.ResponseData = student;
                    response.ResponseData = "Record updated successfully.";
                    response.StatusCode = 200;
                }
                else
                {
                    response.ResponseData = "Record has been failed to update.";
                    response.StatusCode = 204;
                }
                return response;
            }
            catch
            {
                response.StatusCode = 500;
                response.StatusMessage = "Failed to update record.";
                return response;
            }
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteStudent")]
        public async Task<APIResponse> Delete(int id)
        {
            APIResponse response = new APIResponse();
            try
            {                
                await _studentsRepository.DeleteStudent(id);
                response.StatusCode = 200;
                response.StatusMessage = "Record has been deleted successfully!";
                return response;
            }
            catch
            {
                response.StatusCode = 500;
                response.StatusMessage = "Failed to delete record.";
                return response;
            }
        }
    }
}
