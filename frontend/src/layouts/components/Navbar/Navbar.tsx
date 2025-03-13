import { NavLink } from "react-router-dom";
import "./NavBar.css";
import { ROUTE_PATH } from "../../../routes/route-path";
import { User } from "lucide-react";

function Navbar() {
  return (
    <header className="border-b border-gray-200 bg-white">
      <div className="container mx-auto px-4 py-3 flex items-center justify-between">
        <div className="flex items-center space-x-8">
          <div className="bg-gray-300 rounded-full px-4 py-2 text-gray-700 font-semibold">LOGO</div>
          <nav className="hidden md:flex space-x-8">
            <NavLink
              to={ROUTE_PATH.BLOG}
              className={({ isActive }) =>
                isActive ? "text-gray-900 border-b-2 border-gray-900 pb-3 font-medium" : "text-gray-600 hover:text-gray-900"
              }
            >
              Blog
            </NavLink>
            <NavLink
              to={ROUTE_PATH.STUDENT_DASHBOARD}
              className={({ isActive }) =>
                isActive ? "text-gray-900 border-b-2 border-gray-900 pb-3 font-medium" : "text-gray-600 hover:text-gray-900"
              }
            >
              Dashboard
            </NavLink>
          </nav>
        </div>
        <div className="flex items-center space-x-3">
          <span className="text-gray-700">Bui Minh</span>
          <div className="w-10 h-10 bg-blue-500 rounded-full flex items-center justify-center text-white">
            <User className="w-5 h-5" />
          </div>
        </div>
      </div>
    </header>
  );
}

export default Navbar;