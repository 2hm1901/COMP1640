import React, { useState } from "react";
import { Link } from "react-router-dom";
import toast from "react-hot-toast";
import logo from "../../../assets/images/logo.png";
import lock from "../../../assets/images/lock.png";
import user from "../../../assets/images/user.png";
import education from "../../../assets/images/Education.png";
import { useLogin } from "../../../services/auth.service";

function Login() {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const { isPending, mutateAsync } = useLogin();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!formData.email || !formData.password) {
      toast.error("Please enter all required fields!");
      return;
    }

    await mutateAsync({
      email: formData.email,
      password: formData.password,
    });
    
    
  };

  return (
    <div className="min-h-figma-2 flex flex-col items-center justify-center bg-figma">
      <div className="w-full bg-figma p-4">
      <div className="flex items-center mb-1 max-w-1xl mx-auto">
          <img src={logo} alt="logo" className="w-24" />
          <div className="ml-4">
            <h2 className="text-2xl font-bold text-black">Website’s name</h2>
            <p className="text-small-figma text-gray-500">Enabling seamless connections between tutors and students</p>
          </div>
        </div>
      </div>
      <div className="bg-white p-8 rounded-lg shadow-figma w-full max-w-md mt-6 space-y-6 relative">
        <div>
          <h2 className="text-2xl font-bold text-black">Login</h2>
        </div>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="flex items-center border p-figma rounded-md border-figma">
            <img src={user} alt="user" className="h-5 w-5 mr-2" />
            <input
              type="email"
              name="email"
              placeholder="Email"
              value={formData.email}
              onChange={handleChange}
              className="w-full outline-none text-form-figma"
            />
          </div>
          <div className="flex items-center border p-figma rounded-md border-figma">
            <img src={lock} alt="lock" className="h-5 w-5 mr-2" />
            <input
              type="password"
              name="password"
              placeholder="Password"
              value={formData.password}
              onChange={handleChange}
              className="w-full outline-none text-form-figma"
            />
          </div>
          <div className="flex items-center justify-\">
            <span className="text-sm text-gray-figma mr-1">Don't have an account?</span>
            <Link to="/signup" className="text-sm text-blue-figma hover:text-indigo-500 
            underline font-bold">
              Sign Up
            </Link>
          </div>
          <div className="flex justify-end">
            <button
              type="submit"
              className="w-32 flex justify-center py-2 px-4 border 
              border-transparent rounded-md shadow-sm text-sm font-bold
               text-white bg-button-figma hover:bg-button-hover-figma 
               focus:outline-none focus:ring-2 focus:ring-offset-2
                focus:ring-indigo-500"
            > Log In </button>
          </div>
        </form>
      </div>
      <div className="min-h-figma p-4 bg-figma">
        <img src={education} alt="Education" className="absolute bottom-4 right-50 w-64 hidden lg:block" />
      </div>    
    </div>
  );
}

export default Login;
