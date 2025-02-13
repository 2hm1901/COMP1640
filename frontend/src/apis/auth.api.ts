import { AxiosResponse } from "axios";
import { AuthInfo, AuthPayload } from "../models/auth.interface";
import fetchAPI from "../utils/fetchApi";

export const getAllUser = async (searchTerm: string) => {
    const response: AxiosResponse<AuthInfo[]> =
    await fetchAPI.request({
        url: "/User/get-all-users",
        method: "get",
        params: {
            searchTerm,
        },
    });

  return response.data;
};

export const getUserById = async (id: number) => {
    const response: AxiosResponse<AuthInfo> =
    await fetchAPI.request({
        url: `/User/get-user-by-id/${id}`,
        method: "get",
    });

  return response.data;
};

export const createUser = async (user: AuthInfo) => {
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: "/User/create-user",
        method: "post",
        data: user,
    });

  return response.data;
};

export const updateUser = async (user: AuthInfo) => {
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: "/User/update-user",
        method: "put",
        data: user,
    });

  return response.data;
};

export const deleteUser = async (id: number) => {    
    const response: AxiosResponse<string> =
    await fetchAPI.request({
        url: `/User/delete-user`,
        method: "delete",
        data: { id },
    });

  return response.data;
}