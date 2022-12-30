using _2ndApiTest6.Models;
using EF.Core.Repository.Interface.Manager;

namespace _2ndApiTest6.Interfaces.Manager
{
    public interface IStudentManager:ICommonManager<Student>
    {
        Student GetById(int id);
    }
}
