using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace StudentsAPI.interfaces
{
    public interface IRepository
    {
        List<Student> Get();
        Student Get(int id);
        public void Addstudent(Student student);
        Student updatestudent(Student request);
        public void Delete(int id);
    }

    public class studentRepo : IRepository
    {

        public List<Student> students = new List<Student>()
            {
                 new Student{Id=1,  Name="maha",Age=11,City="Ramallah"},

                new Student{Id=2,  Name="Jana",Age=20,City="Ramallah"},

            };
        private object student;

        public void Addstudent(Student student)
        {
            students.Add(student);
        }

        public void Delete(int id)
        {
            students.Remove((Student)student);

        }

        public List<Student> Get()
        {
            return students;
        }

        public Student Get(int Id)
        {
            return students.FirstOrDefault(f => f.Id == Id);
        }

        public Student updatestudent(Student request)
        {
            var student = students.Find(p => p.Id == request.Id);

            student.Id = request.Id;
            student.Name = request.Name;
            student.Age = request.Age;
            student.City = request.City;
            return student;

        }

        Student IRepository.updatestudent(Student request)
        {
            throw new NotImplementedException();
        }
    }
}

