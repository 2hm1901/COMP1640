import { createBrowserRouter } from "react-router-dom";
import { ROUTE_PATH } from "./route-path";
import DefaultLayout from "../layouts/DefaultLayout";
import Blog from "../pages/Common/Blog/Blog";
import StudentManagement from "../pages/Staff/StudentManagement/StudentManagement";
import Chat from "../pages/Common/Chat/Chat"

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
        path: ROUTE_PATH.STUDENT_MANAGEMENT,
        element: <StudentManagement />,
      },
      {
        path: ROUTE_PATH.CHAT,
        element: <Chat />,
      }
    ],
  },
]);

export default router;
