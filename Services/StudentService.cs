using Microsoft.EntityFrameworkCore;
using StudentsApp.Data;
using StudentsApp.Models;
using StudentsApp.Helpers;
using System.Linq.Expressions;

namespace StudentsApp.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students
                                 .Include(s => s.Phones)
                                 .Include(s => s.Emails)
                                 .Include(s => s.Addresses)
                                 .ToListAsync();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students
                                 .Include(x => x.Phones)
                                 .Include(x => x.Emails)
                                 .Include(x => x.Addresses)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task DeleteStudent(int id)
        {
            var student = await GetStudentById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateStudent(Student student)
        {
            var existingStudent = await _context.Students
                .Include(s => s.Addresses)
                .Include(s => s.Emails)
                .Include(s => s.Phones)
                .FirstOrDefaultAsync(s => s.Id == student.Id);

            if (existingStudent == null)
                throw new Exception("Student not found");

            existingStudent.Addresses.Clear();
            foreach (var addr in student.Addresses)
                existingStudent.Addresses.Add(addr);

            existingStudent.Emails.Clear();
            foreach (var email in student.Emails)
                existingStudent.Emails.Add(email);

            existingStudent.Phones.Clear();
            foreach (var phone in student.Phones)
                existingStudent.Phones.Add(phone);


            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            existingStudent.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        private async Task DeleteEntity<T>(DbSet<T> dbSet, Expression<Func<T, bool>> predicate) where T : class
        {
            var entity = await dbSet.FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public Task DeletePhone(int studentId, int phoneId)
        {
            return DeleteEntity(_context.Phones, x => x.Id == phoneId && x.StudentId == studentId);
        }

        public Task DeleteEmail(int studentId, int emailId)
        {
            return DeleteEntity(_context.Emails, x => x.Id == emailId && x.StudentId == studentId);
        }

        public Task DeleteAddress(int studentId, int addressId)
        {
            return DeleteEntity(_context.Addresses, x => x.AddressId == addressId && x.StudentId == studentId);
        }
    }
}
