import { useState } from "react";
import {
  useStudents,
  useDeleteStudent,
  useCreateStudent,
} from "../../../services/student.service";
import toast from "react-hot-toast";

function StudentManagement() {
  const searchTerm = ""; // Nếu cần, có thể thay bằng state từ input
  const { data: students, isLoading, error } = useStudents(searchTerm);
  const { mutate: deleteStudent } = useDeleteStudent();
  const { mutate: createStudent } = useCreateStudent();

  // State để lưu input từ form
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
  });

  // Xử lý thay đổi input
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  // Xử lý submit form
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!formData.firstName || !formData.lastName || !formData.email) {
      toast.error("Vui lòng nhập đầy đủ thông tin!");
      return;
    }

    createStudent(formData, {
      onSuccess: () => {
        setFormData({ firstName: "", lastName: "", email: "" }); // Reset form
      },
    });
  };

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Đã xảy ra lỗi!</p>;

  return (
    <div>
      <h2>Danh sách sinh viên</h2>

      {/* Form thêm sinh viên */}
      <form onSubmit={handleSubmit} className="mb-4 space-y-2">
        <input
          type="text"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
          placeholder="First Name"
          className="border p-2 rounded w-full"
        />
        <input
          type="text"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
          placeholder="Last Name"
          className="border p-2 rounded w-full"
        />
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Email"
          className="border p-2 rounded w-full"
        />
        <button
          type="submit"
          className="bg-blue-500 text-white p-2 rounded w-full hover:bg-blue-600"
        >
          Thêm sinh viên
        </button>
      </form>

      {/* Danh sách sinh viên */}
      <ul>
        {students?.map((student) => (
          <li
            key={student.id}
            className="flex justify-between items-center border-b py-2"
          >
            {student.fullName} - {student.email}
            <button
              className="text-red-600 hover:underline"
              onClick={() => deleteStudent(student.id)}
            >
              Xóa
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default StudentManagement;
