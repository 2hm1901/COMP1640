import axios, { AxiosResponse } from "axios";
import { AuthInfo } from "../models/auth.interface";
import fetchAPI from "../utils/fetchApi";
import createFormData from "../utils/formDataUtil";

//For Log In
const API_URL = 'http://localhost:7228';

export const login = async (email: string, password: string) => {
  const response = await fetchAPI.request<{ accessToken: string; refreshToken: string; user: AuthInfo }>({
    url: "/Auth/login",
    method: "post",
    data: { email, password },
  });
  return response;
};

export const refreshToken = async (refreshToken: string) => {
  const response = await fetchAPI.request<{ accessToken: string }>({
    url: "/Auth/refresh",
    method: "post",
    data: { refreshToken },
  });
  return response;
};

export const getAllUser = async (searchTerm: string) => {
  const response: AxiosResponse<AuthInfo[]> = await fetchAPI.request({
    url: "/User/get-all-users",
    method: "get",
    params: {
      searchTerm,
    },
  });

  return response.data;
};

export const getUserById = async (id: number) => {
  const response: AxiosResponse<AuthInfo> = await fetchAPI.request({
    url: `/User/get-user-by-id/${id}`,
    method: "get",
  });

  return response.data;
};

export const createUser = async (user: AuthInfo) => {
  const formData = createFormData(user);

  const response: AxiosResponse<string> = await fetchAPI.request({
    url: "/User/create-user",
    method: "post",
    headers: {
      "Content-Type": "multipart/form-data",
    },
    data: formData,
  });

  return response.data;
};

export const updateUser = async (user: AuthInfo) => {
  const response: AxiosResponse<string> = await fetchAPI.request({
    url: "/User/update-user",
    method: "put",
    data: user,
  });

  return response.data;
};

export const deleteUser = async (id: number) => {
  const response: AxiosResponse<string> = await fetchAPI.request({
    url: `/User/delete-user`,
    method: "delete",
    data: { id },
  });

  return response.data;
};