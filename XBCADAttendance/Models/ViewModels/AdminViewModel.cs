﻿using Google.Apis.Admin.Directory.directory_v1.Data;
using System.Drawing;

namespace XBCADAttendance.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<TblUser> Users { get; set; }
        public List<TblStudent> Students { get; set; }
        public List<TblStaff> Staff { get; set; }
        public List<TblStaffLecture> StaffLectures { get; set; }

        public AdminViewModel() 
        {
            Users = DataAccess.GetAllUsers();
            Students = DataAccess.GetAllStudents();
            Staff = DataAccess.GetAllStaff();
            StaffLectures = DataAccess.GetStaffLectures();
        }

        public string GetID(TblUser user)
        {
            var student = Students.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (student != null)
            {
                return student.StudentNo;
            } else
            {
                var staff = Staff.Where(x => x.UserId == user.UserId).FirstOrDefault();
                if (staff != null)
                {
                    return staff.StaffId;
                }
            }

            return "ERROR";
        }

        public string GetRole(TblUser user)
        {
            var student = Students.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (student != null)
            {
                return "Student";
            } else
            {
                var staff = Staff.Where(x => x.UserId == user.UserId).FirstOrDefault();
                if (staff != null)
                {
                    var roles = DataAccess.GetAllRoles();

                    return roles.Where(x => x.RoleId == staff.RoleId).Select(x => x.RoleName).FirstOrDefault();
                }
            }

            return "ERROR";
        }

        public string GetLecturer(TblStaffLecture lecture)
        {
            var lecturer = DataAccess.context.TblStaffs.Where(x => x.UserId == lecture.UserId).Select(x => x.User).FirstOrDefault();

            if (lecturer != null)
            {
                return lecturer.UserName;
            }

            return "Error";
        }
    }
}