import { createBrowserRouter } from "react-router-dom";
import { ROUTE_PATH } from "./route-path";
import DefaultLayout from "../layouts/DefaultLayout";
import Blog from "../pages/Common/Blog/Blog";
import StudentManagement from "../pages/Staff/StudentManagement/StudentManagement";
import SignUp from "../pages/Common/SignUp/SignUp";
import Login from "../pages/Common/Login/Login";

const router = createBrowserRouter([
  {
    path: "/",
    element: <DefaultLayout />,
    children: [
      {
        index: true,
        element: <Blog />,
      },
      {
        path: ROUTE_PATH.SIGNUP,
        element: <SignUp />,
      },
      {
        path: ROUTE_PATH.LOGIN,
        element: <Login />,
      },
      {
        path: ROUTE_PATH.STUDENT_MANAGEMENT,
        element: <StudentManagement />,
      },
    ],
  },
]);

export default router;
