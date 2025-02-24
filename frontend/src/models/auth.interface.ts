import { RoleEnum } from "./app.interface";


export interface AuthInfo {
  id?: number;
  lastName?: string;
  firstName?: string;
  email?: string;
  password?: string;
  avatar?: File;
  role?: RoleEnum;
}

export interface AuthPayload {
  account: AuthInfo;
  accessToken: string;
  refreshToken?: string;
}
