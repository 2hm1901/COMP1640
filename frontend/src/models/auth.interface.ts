import { RoleEnum } from "./app.interface";


// export interface AuthInfo {
//   id?: number;
//   lastName?: string;
//   firstName?: string;
//   email?: string;
//   password?: string;
//   avatar?: File;
//   role?: RoleEnum;
// }

export interface AuthPayload {
  // account: AuthInfo;
  id?: number;
  token?: string;
  firstName?: string;
  lastName?: string;
  avatar?: string;
  role?: RoleEnum;
  refreshToken?: string;
}


export interface RegisterPayload {
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  avatar: File | undefined;
}

export interface LoginResponse {
  id: number;
  email: string;
  token: string;
  refreshToken: string;
  role: RoleEnum;
  firstName: string;
  lastName: string;
  avatar: string;
}