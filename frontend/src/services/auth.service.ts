import { useMutation } from "@tanstack/react-query";
import { useDispatch } from "react-redux";
import { loginByEmail  } from "../apis/auth.api";
import { login } from "../store/auth/auth.slice";
import toast from "react-hot-toast";
import { useNavigate } from "react-router-dom";

export const useLogin = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    return useMutation({
      mutationFn: loginByEmail,
      onSuccess: (data) => {
        // dispatch(login(data.data));

        const { token, refreshToken, id, ...userInfo } = data.data;
        dispatch(login({ token, refreshToken, id: id || -1, ...userInfo }));

        if ('Token' in data.data) {
          delete data.data.Token;       
        }

        toast.success("Logged in successfully!");

        navigate("/")
      },
      onError: (error) => {
        toast.error(error.message || "Lỗi khi đăng nhập!");
      },
    });
  };