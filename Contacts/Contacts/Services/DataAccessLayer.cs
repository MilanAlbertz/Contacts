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
            db.CreateTableAsync<LearnedSkill>();
        }

        //For Contact 
        public Task<int> RegisterUser(Contact contact)
        {
            return db.InsertAsync(contact);
        }
        public Task<List<Contact>> GetAllContacts() 
        {
            db.CreateTableAsync<Contact>();
            return db.Table<Contact>().OrderBy(d => d.Name).ToListAsync();
        }
        public Task<List<Contact>> GetAllUsers()
        {
            db.CreateTableAsync<Contact>();
            return db.Table<Contact>().Where(d => string.IsNullOrEmpty(d.Name)).OrderBy(d => d.Name).ToListAsync();
        }
        public Task<List<Contact>> GetAllLocalContacts()
        {
            return db.Table<Contact>().Where(d => string.IsNullOrEmpty(d.Username)).OrderBy(d => d.Name).ToListAsync();
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
        public Task<int> UpdateSkill(Skill skill)
        {
            return db.UpdateAsync(skill);
        }
        public Task<int> DeleteSkill(Skill skill)
        {
            return db.DeleteAsync(skill);
        }

        //For learned skill
        public Task<int> MakeLearnedSkill(LearnedSkill skill)
        {
            return db.InsertAsync(skill);
        }
        public Task<List<LearnedSkill>> GetAllLearnedSkills()
        {
            return db.Table<LearnedSkill>().ToListAsync();
        }
        public Task<int> UpdateLearnedSkill(LearnedSkill skill)
        {
            return db.UpdateAsync(skill);
        }
        public Task<int> DeleteLearnedSkill(LearnedSkill skill)
        {
            return db.DeleteAsync(skill);
        }
    }
}
