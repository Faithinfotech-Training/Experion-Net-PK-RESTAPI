using ClinicManagementSystem.Models;
using ClinicManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class UsersRepo : IUsersRepo
    {
        private clinicalmanagementsystemContext _db;

        public UsersRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Users>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }


        //------------------Add Users--------------------------------------------------------------------------
        public async Task<int> AddUsers(Users usr)
        {
            if (_db != null)

            {
                usr.JoinDate = DateTime.Now;
                await _db.Users.AddAsync(usr);
                await _db.SaveChangesAsync();
                return usr.UserId;
            }
            return 0;
        }


        //------------------Add Users(Doctor)--------------------------------------------------------------------------
        public async Task<int> AddDoctor(AddDoctorView usr)
        {
            if (_db != null)

            {
               
                Users ur = new Users();
                ur.FirstName = usr.FirstName;
                ur.LastName = usr.LastName;
                ur.RoleId = 2;
                ur.JoinDate = new DateTime();
                ur.UserDob = usr.UserDob;
                ur.UserName = usr.UserName;
                ur.Password = usr.Password;
                ur.JoinDate = DateTime.Now;
                ur.City = usr.City;
                ur.State = usr.State;
                ur.Gender = usr.Gender;
                ur.Phone = usr.Phone;
                await _db.Users.AddAsync(ur);
                await _db.SaveChangesAsync();

                Doctor dr = new Doctor();
                dr.SpecializationId = usr.Specialization;
                dr.UserId = ur.UserId;
                await _db.Doctor.AddAsync(dr);
                await _db.SaveChangesAsync();

                return dr.DoctorId;
            }
            return 0;
        }



        //------------------Update Users--------------------------------------------------------------------------
        public async Task UpdateUsers(Users usr)
        {
            _db.Entry(usr).State = EntityState.Modified;
            _db.Users.Update(usr);
            await _db.SaveChangesAsync();
        }


        //------------------Get Users By Id--------------------------------------------------------------------------
        public async Task<Users> GetByUsersId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Users.FindAsync(id);
                return result;
            }
            return null;
        }


        public async Task<Users> GetUserByUserNamePassword(string userName, string passWord)
        {
            return await (
                _db.Users.Where(x => x.Password == passWord && x.UserName == userName)
                ).FirstOrDefaultAsync();
        }

        //--------------Update Doctor---------------------------------------------------------------
        public async Task UpdDoctor(AddDoctorView usr)
        {
            if (_db != null)

            {

                Users ur = new Users();
                ur.UserId = usr.UserId;
                ur.FirstName = usr.FirstName;
                ur.LastName = usr.LastName;
                ur.RoleId = 2;
                ur.JoinDate = new DateTime();
                ur.UserDob = usr.UserDob;
                ur.UserName = usr.UserName;
                ur.Password = usr.Password;
                ur.JoinDate = DateTime.Now;
                ur.City = usr.City;
                ur.State = usr.State;
                ur.Gender = usr.Gender;
                ur.Phone = usr.Phone;
                _db.Entry(ur).State = EntityState.Modified;
                _db.Users.Update(ur);
                await _db.SaveChangesAsync();

                Doctor dr = new Doctor();
                dr.DoctorId = usr.DoctorId;
                dr.SpecializationId = usr.Specialization;
                dr.UserId = usr.UserId;
                _db.Entry(dr).State = EntityState.Modified;
                _db.Doctor.Update(dr);
                await _db.SaveChangesAsync();

            }
            
        }

        //-------------Get Doctor Details By UserID------------------------------------------------
        public async Task<AddDoctorView> GetDoctorDetailsByUserID(int id)
        {
            return await (from user in _db.Users
                          join dr in _db.Doctor
                          on user.UserId equals dr.UserId
                          select new AddDoctorView
                          {
                              UserId = user.UserId,
                              DoctorId = dr.DoctorId,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              RoleId = user.RoleId,
                              JoinDate = (DateTime)user.JoinDate,
                              UserDob = (DateTime)user.UserDob,
                              UserName = user.UserName,
                              Password = user.Password,
                              City = user.City,
                              State = user.State,
                              Gender = user.Gender,
                              Phone = user.Phone,
                              Specialization = (int)dr.SpecializationId
                          }
                   ).FirstOrDefaultAsync();
                   
        }
    }
}
