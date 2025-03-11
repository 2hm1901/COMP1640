import React, { useState } from "react";
import toast from "react-hot-toast";
import { Link, useNavigate } from "react-router-dom";
import logo from "../../../assets/images/logo.png";
import education from "../../../assets/images/Education.png";
import user from "../../../assets/images/user.png";
import lock from "../../../assets/images/lock.png";
import upload from "../../../assets/images/upload.png";
import { useCreateUser } from "../../../services/user.service";
import { RegisterPayload } from "../../../models/auth.interface";

function SignUp() {
  const { mutate: createUser } = useCreateUser();
  const navigate = useNavigate();

  // State to store form data
  const [formData, setFormData] = useState<RegisterPayload>({
    lastName: "",
    firstName: "",
    email: "",
    password: "",
    avatar: undefined,
  });
  //For avatar preview
  const [avatarPreview, setAvatarPreview] = useState<string | null>(null);

  // Handle input change
  // const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
  //   setFormData({ ...formData, [e.target.name]: e.target.value });
  // };
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value, files } = e.target;
    if (name === "avatar" && files) {
      const file = files[0];
      setFormData({ ...formData, avatar: files[0] });
      setAvatarPreview(URL.createObjectURL(file));
    } else {
      setFormData({ ...formData, [name]: value });
    }
  };

  // Handle form submit
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!formData.lastName || !formData.firstName || !formData.email || !formData.password || !formData.avatar) {
      toast.error("Please enter all required fields!");
      return;
    }

    // console.log(formData);

    createUser(formData, {
      onSuccess: () => {
        navigate("/");
      },
      onError: (error: any) => {
      },
    });
  };

  return (
    <div className="min-h-screen flex flex-col items-center justify-between bg-figma">
      <div className="w-full bg-figma p-4 flex-shrink-0">
        <div className="flex items-center mb-1 max-w-1xl mx-auto">
          <img src={logo} alt="logo" className="w-24" />
          <div className="ml-4">
            <h2 className="text-2xl font-bold text-black">Website’s name</h2>
            <p className="text-small-figma text-gray-500">Enabling seamless connections between tutors and students</p>
          </div>
        </div>
      </div>
      <div className="flex flex-col items-center justify-center w-full max-w-md mt-6 relative flex-grow">
        <div className="bg-white p-8 rounded-lg shadow-figma space-y-3 w-full">
          <div>
            <h2 className="text-res-figma font-bold text-black">Register</h2>
          </div>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="grid grid-cols-2 gap-4">
              <input
                type="text"
                name="lastName"
                placeholder="Last name"
                value={formData.lastName}
                onChange={handleChange}
                className="rounded-md w-full p-figma border-figma text-form-figma"
              />
              <input
                type="text"
                name="firstName"
                placeholder="First name"
                value={formData.firstName}
                onChange={handleChange}
                className="p-figma border-figma rounded-md w-full text-form-figma"
              />
            </div>
            <div className="flex items-center p-figma border-figma rounded-md">
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
            <div className="flex items-center p-figma border-figma rounded-md">
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
            <div className="p-figma border-figma rounded-md text-center flex flex-col items-center justify-center cursor-pointer">
              <span className="text-gray-figma mb-2 text-form-figma">Upload your avatar here</span>
              <input
                type="file"
                name="avatar"
                className="w-full h-full opacity-0"
                onChange={handleChange}
              />
              {avatarPreview ? (
                <img src={avatarPreview} alt="avatar preview" className="h-40 w-auto" />
              ) : (
                <img src={upload} alt="upload" className="h-10 w-auto" />
              )}
            </div>
            <div className="flex items-center justify-between">
              <div className="flex items-center">
                <span className="text-sm text-gray-figma text-form-figma">Already have an account?</span>
                <Link
                  to="/login"
                  className="text-sm text-blue-figma text-form-figma hover:text-indigo-500 underline font-bold ml-1"
                >
                  Sign In
                </Link>
              </div>
              <button
                type="submit"
                className="w-36 flex justify-center py-2 px-4 text-form-figma
                border border-transparent rounded-md shadow-sm text-sm font-bold
                 text-white bg-button-figma hover:bg-button-hover-figma focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
              >
                Sign Up
              </button>
            </div>
          </form>
        </div>
      </div>
      <div className="min-h-figma p-4 bg-figma">
        <img src={education} alt="Education" className="absolute top-126 right-50 w-64 hidden lg:block" />
      </div>
    </div>
  );
}

export default SignUp;
