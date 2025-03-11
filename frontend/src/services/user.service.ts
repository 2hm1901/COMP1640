// import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
// import {
//     createUser,
// } from "../apis/auth.api";
// import toast from "react-hot-toast";
// import axios from "axios";
// import { AuthPayload } from "../models/auth.interface";
// import fetchAPI from "../utils/fetchApi";

import { useMutation, useQueryClient } from "@tanstack/react-query";
import { createUser } from "../apis/auth.api";
import toast from "react-hot-toast";

// // Get all users
// export const useUsers = (searchTerm: string) => {
//     return useQuery({
//         queryKey: ["users", searchTerm],
//         queryFn: () => getAllUser(searchTerm),
//     });
// };

// // Get user by ID
// export const useUserById = (id: number) => {
//     return useQuery({
//         queryKey: ["user", id],
//         queryFn: () => getUserById(id),
//     });
// };

// // Create user
export const useCreateUser = () => {
    return useMutation({
        mutationFn: createUser,
        onSuccess: () => {
            toast.success("Create user successfully!");
        },
        onError: (error: any) => {
            toast.error(error.response?.data || "Error when create user!");
        },
    });
};

// // Update user
// export const useUpdateUser = () => {
//     const queryClient = useQueryClient();
//     return useMutation({
//         mutationFn: updateUser,
//         onSuccess: () => {
//             toast.success("Update user successfully!");
//             queryClient.invalidateQueries({ queryKey: ["users"] });
//         },
//         onError: (error: any) => {
//             toast.error(error.response?.data || "Error when update user!");
//         },
//     });
// };

// //Delete user
// export const useDeleteUser = () => {
//     const queryClient = useQueryClient();
//     return useMutation({
//         mutationFn: deleteUser,
//         onSuccess: () => {
//             toast.success("Delete user successfully!");
//             queryClient.invalidateQueries({ queryKey: ["users"] });
//         },
//         onError: (error: any) => {
//             toast.error(error.response?.data || "Error when delete user!");
//         },
//     });
// }

// //Login
// export const login = async (email: string, password: string): Promise<AuthPayload> => {
//     try {
//       const response = await fetchAPI.request({
//         url: "/login",
//         method: "post",
//         data: {
//           email,
//           password
//         }
//       });
//       return response.data;
//     } catch (error) {
//       if (error instanceof Error) {
//         throw new Error('Error logging in: ' + error.message);
//       } else {
//         throw new Error('An unknown error occurred.');
//       }
//     }
//   };