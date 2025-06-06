import Navbar from "./components/Navbar/Navbar";
import { Outlet } from "react-router-dom";
import Footer from "./components/Footer/Footer";
import { Toaster } from "react-hot-toast";

function DefaultLayout() {
  return (
    <div>
      <Toaster />
      <Navbar />
      <Outlet />
      <Footer />
    </div>
  );
}

export default DefaultLayout;
