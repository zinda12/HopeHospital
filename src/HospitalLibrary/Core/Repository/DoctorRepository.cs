using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }
        public IEnumerable<Doctor> GetAllGeneralPracticioners()
        {
             return _context.Doctors.Where(d=>(d.Specialization==DoctorSpecialization.GENERAL_PRACTICIONER)).ToList();
            
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public List<Doctor> GetBySpecialization(DoctorSpecialization specialization)
            => _context.Doctors.Where(d => d.Specialization == specialization).ToList();

        public void Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}