//Video used for help: https://www.youtube.com/watch?v=VG0t-bZ26UQ
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Contacts.Models;

namespace Contacts.Services
{
    public class DataAccessLayer
    {
        private readonly SQLiteAsyncConnection db;

        public DataAccessLayer(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Contact>();
            db.CreateTableAsync<Skill>();
        }

        //For Contact 
        public Task<int> RegisterUser(Contact contact)
        {
            return db.InsertAsync(contact);
        }
        public Task<List<Contact>> GetAllContacts() 
        {
            return db.Table<Contact>().ToListAsync();
        }
        public Task<List<Contact>> GetAllContactNames()
        {
            return db.Table<Contact>().ToListAsync();
        }
        public Task<int> UpdateContact(Contact contact)
        {
            return db.UpdateAsync(contact);
        }
        public Task<int> DeleteContact(Contact contact)
        {
            return db.DeleteAsync(contact);
        }

        //For Skill
        public Task<int> MakeSkill(Skill skill)
        {
            return db.InsertAsync(skill);
        }
        public Task<List<Skill>> GetAllSkills()
        {
            return db.Table<Skill>().ToListAsync();
        }
        public Task<int> UpdateContact(Skill skill)
        {
            return db.UpdateAsync(skill);
        }
        public Task<int> DeleteContact(Skill skill)
        {
            return db.DeleteAsync(skill);
        }
    }
}
