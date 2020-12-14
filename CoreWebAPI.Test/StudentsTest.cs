using CoreWebAPI.Infrastructure;
using CoreWebAPI.Infrastructure.Interfaces;
using CoreWebAPI.Infrastructure.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWebAPI.Test
{
    public class StudentsTest
    {
        private Mock<IStudentsRepository> _studentRepository;
        private List<Students> students;

        [SetUp]
        public void Setup()
        {
            _studentRepository = new Mock<IStudentsRepository>();
            students = new List<Students>();
            students.Add(new Students { FirstName = "Anant", LastName = "Jaiswal", PhoneNumber = "9714252707", City = "Surat", });
            students.Add(new Students { FirstName = "Herry", LastName = "Ganeshwala", PhoneNumber = "8320535895", City = "Surat", });
        }

        [Test]
        public void TestGetAllStudents()
        {
            _studentRepository.Setup(a => a.GetAllStudent().Result).Returns(students.ToList());

            StudentsRepository studentsRepository = new StudentsRepository();
            var studentList = studentsRepository.GetAllStudent();

            Assert.IsTrue(studentList.Result.Count > 1);
        }

    }
}
