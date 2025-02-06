import { Link } from "react-router-dom";
import "./NavBar.css";
import { ROUTE_PATH } from "../../../routes/route-path";

function Navbar() {
  return (
    <div>
      <Link to={ROUTE_PATH.BLOG}>Blog</Link>
      <Link to={ROUTE_PATH.STUDENT_MANAGEMENT}>Student Management</Link>
    </div>
  );
}

export default Navbar;
