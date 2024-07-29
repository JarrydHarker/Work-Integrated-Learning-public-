﻿namespace XBCADAttendance.Models
{
    public class DataAccess
    {
        public DbWilContext context = new DbWilContext();
        public static DataAccess instance = null;
        
        public DataAccess()
        { 
            
        }

        public static DataAccess GetContext()
        {
            if (instance == null)
            {
                instance = new DataAccess();
            }

            return instance;
        }

        //CRUD Operations

        //Create
        public string AddStudent(string userID, string studentNo, string userName, string passWord)
        {
            //userID = "TestUser";
            if (userID != null && studentNo != null && userName != null && passWord != null)
            {
                try
                {
                    TblUser newUser = new TblUser
                    {
                        UserId = userID,
                        UserName = userName,
                        Password = passWord

                    };

                    TblStudent newStudent = new TblStudent
                    {
                        StudentNo = studentNo,
                        UserId = userID,
                    };

                    context.TblUsers.Add(newUser);
                    context.TblStudents.Add(newStudent);
                    context.SaveChanges();

                    return "Success";

                } catch (Exception e)
                {
                    return e.ToString();
                }
            } else return "Please Fill in all fields";
        }

        //Read
        public List<TblStudent> GetAllStudents()
        {
            var data = context.TblStudents.ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        public List<LecturerReportViewModel> GetAllLectures()
        {
            var data = context.TblLectures.Join(context.TblStudents,
                         lecture => lecture.UserId,
                         student => student.UserId,
                         (lecture, student) => new LecturerReportViewModel(
                            lecture.UserId,
                            student.StudentNo,
                            lecture.LectureDate.ToString(),
                            "Yes",
                            8)).ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        public List<TblModule> GetAllModules()
        {
            var data = context.TblModules.ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        public List<TblUser> GetAllUsers()
        {
            var data = context.TblUsers.ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        public List<TblStaff> GetAllStaff()
        {
            var data = context.TblStaffs.ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        public List<TblRole> GetAllRoles()
        {
            var data = context.TblRoles.ToList();

            if (data != null)
            {
                return data;
            } else return null;
        }

        //Update

        //Delete
    }
}
