import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AuthPayload } from "../../models/auth.interface";
import { RoleEnum } from "../../models/app.interface";

interface AuthenticationState {
  isLogin?: boolean;
  id: number;
  token: string;
  firstName: string;
  lastName: string;
  avatar: string;
  role: RoleEnum;
  refreshToken?: string;
}

const initialState: AuthenticationState = {
  isLogin: false,
  id: -1,
  token: "",
  firstName: "",
  lastName: "",
  avatar: "",
  role: RoleEnum.USER
};

export const authSlice = createSlice({
  name: "@auth",
  initialState,
  reducers: {
    login: (state, action: PayloadAction<AuthPayload>) => {
      state.isLogin = true;
      state.id = action.payload.id || state.id;
      state.firstName = action.payload.firstName ?? "";
      state.lastName = action.payload.lastName ?? "";
      state.avatar = action.payload.avatar ?? "";
      state.role = action.payload.role ?? RoleEnum.USER;
      state.token = action.payload.token ?? "";
      state.refreshToken = action.payload.refreshToken;
    },
    logout: (state) => {
      state.isLogin = false;
      state.id = initialState.id;
      state.token = initialState.token;
      state.firstName = initialState.firstName;
      state.lastName = initialState.lastName;
      state.avatar = initialState.avatar;
      state.role = initialState.role;
      state.refreshToken = initialState.refreshToken;
    },
    setToken: (state, action: PayloadAction<string>) => {
      state.token = action.payload;
    },
    setRefreshToken: (state, action: PayloadAction<string>) => {
      state.refreshToken = action.payload;
    },
  },
});

export const { login, logout, setToken, setRefreshToken } =
  authSlice.actions;

export default authSlice.reducer;
