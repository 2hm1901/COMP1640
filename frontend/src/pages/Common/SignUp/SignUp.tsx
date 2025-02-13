import React, { useState } from "react";
import { useCreateUser } from "../../../services/user.service";
import toast from "react-hot-toast";
import { Link } from "react-router-dom";
import logo from "../../../assets/images/logo.png";
import education from "../../../assets/images/Education.png";
import user from "../../../assets/images/user.png";
import lock from "../../../assets/images/lock.png";
import upload from "../../../assets/images/upload.png";

function SignUp() {
  const { mutate: createUser } = useCreateUser();

  // State to store form data
  const [formData, setFormData] = useState({
    lastName: "",
    firstName: "",
    email: "",
    password: "",
    avatar: "",
    id: 0,
  });

  // Handle input change
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  // Handle form submit
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!formData.lastName || !formData.firstName || !formData.email || !formData.password || !formData.avatar) {
      toast.error("Please enter all required fields!");
      return;
    }

    createUser(formData, {
      onSuccess: () => {
        setFormData({ lastName: "", firstName: "", email: "", password: "", avatar: "", id: 0 }); // Reset form
        toast.success("User created successfully!");
      },
      onError: (error: any) => {
        const errorMessage = error.response?.data?.message || "Error when creating user!";
        toast.error(errorMessage);
      },
    });
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
        <div className="flex items-center mb-6">
          <img src={logo} alt="logo" className="w-32" />
          <div>
            <h2 className="text-3xl font-bold text-black">Website’s name</h2>
            <p className="text-sm text-gray-500">Enabling seamless connections between tutors and students</p>
          </div>
        </div>
        <div>
          <h2 className="text-2xl font-bold text-black">Register</h2>
        </div>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="grid grid-cols-2 gap-4">
            <input 
            type="text" 
            name="lastName" 
            placeholder="Last name" 
            value={formData.lastName} 
            onChange={handleChange} 
            className="border p-2 rounded-md w-full" />
            <input 
            type="text" 
            name="firstName" 
            placeholder="First name" 
            value={formData.firstName} 
            onChange={handleChange} 
            className="border p-2 rounded-md w-full" />
          </div>
          <div className="flex items-center border p-2 rounded-md">
            <img src={user} alt="user" className="h-5 w-5 mr-2" />
            <input 
            type="email" 
            name="email" 
            placeholder="Email" 
            value={formData.email} 
            onChange={handleChange} 
            className="w-full outline-none" />
          </div>
          <div className="flex items-center border p-2 rounded-md">
            <img src={lock} alt="lock" className="h-5 w-5 mr-2" />
            <input 
            type="password" 
            name="password" 
            placeholder="Password" 
            value={formData.password} 
            onChange={handleChange} 
            className="w-full outline-none" />
          </div>
          <div className="border p-2 rounded-md text-center flex flex-col items-center justify-center cursor-pointer">
            <span className="text-gray-500 mb-2">Upload your avatar here</span>
            <input 
            type="file" 
            name="avatar" 
            className="w-full h-full opacity-0" 
            onChange={handleChange} />
            <img src={upload} alt="upload" className="h-10 w-auto" />
          </div>
          <div className="flex items-center justify-between">
            <span className="text-sm text-gray-500">Already have an account?</span>
            <Link to="/login" 
            className="text-sm text-indigo-600 hover:text-indigo-500 
            underline font-bold">
              Sign In
            </Link>
          {/* </div>
          <div> */}
            <button
              type="submit"
              className="w-36 flex justify-center py-2 px-4 
              border border-transparent rounded-md shadow-sm 
              text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 
              focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
              Sign Up
            </button>
          </div>
        </form>
      </div>
      <img src={education} alt="Education" className="w-64 hidden lg:block bottom-4 right-4" />
    </div>
  );
}

export default SignUp;
