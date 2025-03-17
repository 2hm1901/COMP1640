import { AxiosResponse } from "axios";
import fetchAPI from "../utils/fetchApi";
import createFormData from "../utils/formDataUtil";
import { LoginResponse, RegisterPayload, GetUserById } from "../models/auth.interface";


export const loginByEmail = async ({
  email,
  password,
}: {
  email: string;
  password: string;
}) => {
  const response: AxiosResponse<LoginResponse> = await fetchAPI.request({
    url: "/Auth/login",
    method: "post",
    data: { email, password },
  });
  return response;
};

export const refreshToken = async (refreshToken: string) => {
  const response: AxiosResponse<string> =  await fetchAPI.request({
    url: "/Auth/refresh",
    method: "post",
    data: { refreshToken },
  });
  return response;
};

export const logout = async () => {
  const response: AxiosResponse<string> = await fetchAPI.request({
    url: "/Auth/logout",
    method: "post",
  });
  return response;
};

export const createUser = async (user: RegisterPayload) => {
  // nếu chứa file thì chuyển sang form data
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

// export const getAllUser = async (searchTerm: string) => {
//   const response: AxiosResponse<string> = await fetchAPI.request({
//     url: "/User/get-all-users",
//     method: "get",
//     params: {
//       searchTerm,
//     },
//   });

//   return response.data;
// };

export const getUserById = async (id: number) => {
  const response: AxiosResponse<GetUserById> = await fetchAPI.request({
    url: `/User/get-user-by-id/${id}`,
    method: "get",
  });

  return response.data;
};

// export const updateUser = async (user: AuthInfo) => {
//   const response: AxiosResponse<string> = await fetchAPI.request({
//     url: "/User/update-user",
//     method: "put",
//     data: user,
//   });

//   return response.data;
// };

// export const deleteUser = async (id: number) => {
//   const response: AxiosResponse<string> = await fetchAPI.request({
//     url: `/User/delete-user`,
//     method: "delete",
//     data: { id },
//   });

//   return response.data;
// };