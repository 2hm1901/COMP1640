import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import {
  getStudentById,
  createStudent,
  updateStudent,
  deleteStudent,
  getAllStudents,
} from "../apis/student.api";
import toast from "react-hot-toast";

// Lấy danh sách sinh viên
export const useStudents = (searchTerm: string) => {
    return useQuery({
      queryKey: ["students", searchTerm], 
      queryFn: () => getAllStudents(searchTerm),
    });
  };

// Lấy sinh viên theo ID
export const useStudentById = (id: number) => {
    return useQuery({
      queryKey: ["student", id],
      queryFn: () => getStudentById(id),
    });
  };
  
  // Tạo sinh viên
  export const useCreateStudent = () => {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: createStudent,
      onSuccess: () => {
        toast.success("Thêm sinh viên thành công!");
        queryClient.invalidateQueries({ queryKey: ["students"] });
      },
      onError: (error: any) => {
        toast.error(error.response?.data || "Lỗi khi thêm sinh viên!");
      },
    });
  };
  
  // Cập nhật sinh viên
  export const useUpdateStudent = () => {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: updateStudent,
      onSuccess: () => {
        toast.success("Cập nhật sinh viên thành công!");
        queryClient.invalidateQueries({ queryKey: ["students"] });
      },
      onError: (error: any) => {
        toast.error(error.response?.data || "Lỗi khi cập nhật sinh viên!");
      },
    });
  };
  
  // Xóa sinh viên
  export const useDeleteStudent = () => {
    const queryClient = useQueryClient();
    return useMutation({
      mutationFn: deleteStudent,
      onSuccess: () => {
        toast.success("Xóa sinh viên thành công!");
        queryClient.invalidateQueries({ queryKey: ["students"] });
      },
      onError: (error: any) => {
        toast.error(error.response?.data || "Lỗi khi xóa sinh viên!");
      },
    });
  };