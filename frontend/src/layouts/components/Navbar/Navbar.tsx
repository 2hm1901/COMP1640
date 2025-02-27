import { Link } from "react-router-dom";
import "./NavBar.css";
import { ROUTE_PATH } from "../../../routes/route-path";

function Navbar() {
  return (
    <header className="relative w-full bg-white">
      {/* Curved blue background element */}
      <div className="absolute top-0 right-0 w-1/3 h-full bg-blue-200 rounded-bl-[100%]" />

      <div className="relative flex items-center justify-between px-6 py-4 mx-auto max-w-7xl">
        {/* Logo */}
        <div className="flex items-center justify-center w-20 h-20 bg-gray-300 rounded-full">
          <span className="font-medium text-gray-800">LOGO</span>
        </div>

        {/* Navigation */}
        <nav className="flex space-x-10">
          <Link to={ROUTE_PATH.BLOG} className="px-2 py-1 text-lg font-medium text-black">
            Blog
          </Link>
          <Link to={ROUTE_PATH.BLOG} className="px-2 py-1 text-lg font-medium text-black border-b-2 border-black">
            Dashboard
          </Link>
          <Link to={ROUTE_PATH.BLOG} className="px-2 py-1 text-lg font-medium text-black">
            Document
          </Link>
        </nav>

        {/* User Profile */}
        <div className="flex items-center space-x-3">
          <span className="text-lg font-medium">Bui Minh</span>
          <div className="w-12 h-12 bg-blue-400 rounded-full"></div>
        </div>
      </div>
    </header>

  );
}

export default Navbar;
