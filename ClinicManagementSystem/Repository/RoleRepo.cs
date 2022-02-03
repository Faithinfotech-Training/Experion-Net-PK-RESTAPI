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
    public class RoleRepo : IRoleRepo
    {
        private clinicalmanagementsystemContext _db;

        public RoleRepo(clinicalmanagementsystemContext db)
        {
            _db = db;
        }

        //-----------------Get Raw Table Data------------------------------------------------------------------------
        public async Task<List<Role>> GetAllRole()
        {
            return await _db.Role.ToListAsync();
        }


        //------------------Add Role--------------------------------------------------------------------------
        public async Task<int> AddRole(Role rl)
        {
            if (_db != null)

            {
                await _db.Role.AddAsync(rl);
                await _db.SaveChangesAsync();
                return rl.RoleId;
            }
            return 0;
        }

        //------------------Update Role--------------------------------------------------------------------------
        public async Task UpdateRole(Role rl)
        {
            _db.Entry(rl).State = EntityState.Modified;
            _db.Role.Update(rl);
            await _db.SaveChangesAsync();
        }


        //------------------Get Role By Id--------------------------------------------------------------------------
        public async Task<Role> GetByRoleId(int id)
        {
            if (_db != null)
            {
                var result = await _db.Role.FindAsync(id);
                return result;
            }
            return null;
        }


    }
}
