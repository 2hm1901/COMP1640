import { RoleEnum } from "./app.interface";


export interface AuthInfo {
  id: number;
  email?: string;
  firstName?: string;
  lastName?: string;
  avatar?: string;
  role?: RoleEnum;
}

export interface AuthPayload {
  account: AuthInfo;
  accessToken: string;
  refreshToken?: string;
}
