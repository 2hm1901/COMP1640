import env from "../env";
import { login, logout } from "../../store/auth/auth.slice";
import { store } from "../../store/store";
import ConfigureAxios from "./configAxios";
import toast from "react-hot-toast";

const axiosInstance = new ConfigureAxios({
  configure: {
    baseURL: env.apiEndPoint,
    method: "GET",
    timeout: 10000,
  },
  getToken: () => {
    return store.getState().auth.token;
  },
  getRefreshToken: () => {
    return store.getState().auth.refreshToken || "";
  },
});

const fetchAPI = axiosInstance.create();

axiosInstance.Token({
  setCondition: (config) => {
    return !config.url?.includes("login");
  },
});

axiosInstance.refreshToken({
  setCondition(error) {
    return error.response?.status === 401;
  },
  axiosData(Token, refreshToken) {
    return {
      Token,
      refreshToken,
    };
  },
  success: (response, config) => {
    store.dispatch(
      login({
        id: response.data.id,
        firstName: response.data.firstName,
        lastName: response.data.lastName,
        avatar: response.data.avatar,
        role: response.data.role,
        token: response.data.Token,
        refreshToken: response.data.refreshToken,
      })
    );

    if (config.headers) {
      config.headers["Authorization"] = `Bearer ${response.data.Token}`;
    }
  },
  failure: (error) => {
    toast.error("Phiên đăng nhập hết hạn");
    store.dispatch(logout());
  },
});

export default fetchAPI;
