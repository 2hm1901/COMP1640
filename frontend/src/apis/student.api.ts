import { AxiosResponse } from "axios";
import { CreateStudent, Student } from "../models/student.interface";
import fetchAPI from "../utils/fetchApi";

export const getAllStudents = async (searchTerm: string) => {
    const response: AxiosResponse<Student[]> =
    await fetchAPI.request({
        url: "/Student/get-all-students",
        method: "get",
        params: {
            searchTerm,
        },
    });

  return response.data;
};

export const getStudentById = async (id: number) => {
    const response: AxiosResponse<Student> =
    await fetchAPI.request({
        url: `/Student/get-student-by-id/${id}`,
        method: "get",
    });

  return response.data;
};

export const createStudent = async (student: CreateStudent) => {
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: "/Student/create-student",
        method: "post",
        data: student,
    });

  return response.data;
};

export const updateStudent = async (student: Student) => {
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: "/Student/update-student",
        method: "put",
        data: student,
    });

  return response.data;
};


export const deleteStudent = async (id: number) => {
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: `/Student/delete-student`,
        method: "delete",
        data: { id },
    });

  return response.data;
};