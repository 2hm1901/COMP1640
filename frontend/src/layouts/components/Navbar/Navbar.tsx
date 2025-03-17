import { Link } from "react-router-dom";
import "./NavBar.css";
import { ROUTE_PATH } from "../../../routes/route-path";
import { useSelector } from "react-redux";
import { accountFirstNameSelector } from "../../../store/auth/auth.selector";
import { useLogout } from "../../../services/auth.service";

function Navbar() {
  const { mutateAsync: logout } = useLogout();
  // const firstName = useSelector(accountFirstNameSelector);
  const handleLogout = async () => {
    await logout();
  };
  return (
    <div>
      <Link to={ROUTE_PATH.BLOG}>Blog</Link>
      <Link to={ROUTE_PATH.STUDENT_MANAGEMENT}>Student Management</Link>
      <Link to={ROUTE_PATH.SIGNUP}>Sign Up</Link>
      <Link to={ROUTE_PATH.LOGIN}>Login</Link>
      <Link to={ROUTE_PATH.STUDENT_DASHBOARD}>Student Dashboard</Link>
      <Link to={ROUTE_PATH.CHAT}>Chat</Link>
      <button onClick={handleLogout}>Logout</button>
    </div>
  );
}

export default Navbar;