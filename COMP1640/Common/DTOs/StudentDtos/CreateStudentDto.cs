﻿namespace Common.DTOs.StudentDtos;
public class CreateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] Avatar { get; set; }
}
