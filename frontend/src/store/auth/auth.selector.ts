import { AppState } from "../store";

export const tokenSelector = (state: AppState) => state.auth.token;
export const refreshTokenSelector = (state: AppState) =>
  state.auth.refreshToken;

// export const accountSelector = (state: AppState) => state.auth.account;
export const isLoginSelector = (state: AppState) => state.auth.isLogin;
export const accountRoleSelector = (state: AppState) => state.auth.role;
export const accountIdSelector = (state: AppState) => state.auth.id;
export const accountFirstNameSelector = (state: AppState) => state.auth.firstName;
export const accountLastNameSelector = (state: AppState) => state.auth.lastName;
export const accountAvatarSelector = (state: AppState) => state.auth.avatar;
export const accountFullNameSelector = (state: AppState) => `${state.auth.firstName} ${state.auth.lastName}`;

