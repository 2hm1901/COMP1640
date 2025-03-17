import { useMutation } from "@tanstack/react-query";
import { useDispatch, useSelector, TypedUseSelectorHook } from "react-redux";
import { loginByEmail  } from "../apis/auth.api";
import { login, logout } from "../store/auth/auth.slice";
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

  // Define the type for the Redux state
  interface RootState {
    auth: { isLogin: boolean };
  }
  
  const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;
  export const useLogout = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const isLoggedIn = useTypedSelector(state => state.auth.isLogin); // Get login state
    return useMutation({
      // mutationFn: async () => {
      //   // dispatch(login({ token: "", refreshToken: "", id: -1 }));
      //   dispatch(logout());
      //   toast.success("Logged out successfully!");
      //   navigate("/");
      //   return Promise.resolve();
      // },
      mutationFn: async () => {
        console.log("Logout attempt. Current login status:", isLoggedIn);
        
        if (!isLoggedIn) {
          console.log("User is not logged in");
          toast("You are not currently logged in!", { icon: "❌" });
          return Promise.resolve();
        }
        
        console.log("Logging out...");
        dispatch(logout());
        
        toast.success("Logged out successfully!");
        navigate("/");
        return Promise.resolve();
      },
    });
  };
