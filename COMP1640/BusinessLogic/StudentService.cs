using AutoMapper;
using Common.DTOs.StudentDtos;
using Common.ViewModels.StudentVMs;
using DataAccess.Repository.Core;
using Models.Accounts;
using Models.Core;

namespace BusinessLogic;
public class StudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // get all students
    public async Task<IEnumerable<StudentVM>> GetAllStudents(GetAllStudentsDto dto)
    {
        IEnumerable<Account> students = [];

        if (dto.SearchTerm != null)
        {
            students = await _unitOfWork.Accounts.GetAllAsync(
                // Filter students by search term
                StudentVM => StudentVM.FirstName.Contains(dto.SearchTerm) ||
                StudentVM.LastName.Contains(dto.SearchTerm),

                // Teacher là foreign key nên cần include để lấy thông tin teacher
                includeProperties: "Teacher"
                );
        }
        else
        {
            students = await _unitOfWork.Accounts.GetAllAsync(includeProperties: "Teacher");
        }

        // Mapping account to StudentVM
        // Lý do mapping, bởi vì có một số thông tin không cần thiết cho người dùng (Account) nên sẽ lọc ra những thông tin cần thiết (StudentVM)
        IEnumerable<StudentVM> studentsVM = _mapper.Map<IEnumerable<StudentVM>>(students);

        return studentsVM;
    }

    // get student by id
    public async Task<StudentDetailVM> GetStudentById(int id)
    {
        Account? student = await _unitOfWork.Accounts.GetByIdAsync(id, includeProperties: "Teacher");

        StudentDetailVM studentDetailVM = _mapper.Map<StudentDetailVM>(student);

        return studentDetailVM;
    }

    // create student
    public async Task CreateStudent(CreateStudentDto dto)
    {
        Account student = new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Role = Role.STUDENT,
            CreatedDate = DateTime.Now,
        };

        await _unitOfWork.Accounts.AddAsync(student);
        await _unitOfWork.SaveAsync();
    }

    // update student
    public async Task UpdateStudent(UpdateStudentDto dto)
    {
        // tìm student với id
        Account? student = await _unitOfWork.Accounts.GetByIdAsync(dto.Id);

        // nếu student tồn tại
        if (student != null)
        {
            // cập nhật thông tin student
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;

            // lưu thay đổi
            await _unitOfWork.Accounts.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
        }
    }

    // delete student
    public async Task DeleteStudent(int id)
    {
        Account? student = await _unitOfWork.Accounts.GetByIdAsync(id);

        if (student != null)
        {
            await _unitOfWork.Accounts.DeleteAsync(student);
            await _unitOfWork.SaveAsync();
        }
    }






}
