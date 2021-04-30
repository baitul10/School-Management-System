using System.Threading.Tasks;

namespace Base.Interfaces
{
    public interface IUom
    {
        IStudentRepository studentRepository { get; }
        ISchoolRepository schoolRepository { get; }
        IClassRepository classRepository { get; }
    }
}
