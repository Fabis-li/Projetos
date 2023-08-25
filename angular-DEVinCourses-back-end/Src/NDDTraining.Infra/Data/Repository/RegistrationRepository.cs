using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.DTOS;
using Microsoft.EntityFrameworkCore;

namespace NDDTraining.Infra.Data.Repository
{
    public class RegistrationRepository : BaseRepository<Registration, int>, IRegistrationRepository

    {

        public RegistrationRepository(NDDTrainingDbContext context) : base(context)
        {
        }

        public IList<Registration> GetAll()
        {
            return _context.Registrations.ToList();
        }


        public override void Insert(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }



       
        public bool RegistrationDuplicate(int id)
        {
            return _context.Registrations.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {

            var registration = _context.Registrations.Find(id);

            _context.Registrations.Remove(registration);
            _context.SaveChanges();
        }

        public bool DeleteNoRegistration(int userId)
        {
            var user = _context.Registrations.Find(userId);
            if (user == null) return true;
            else return false;

        }        

        public IQueryable<Registration> GetRegistrationsByUser(int id, Paging paging)
        {
            var teste = _context.Registrations.Where(r => r.UserId == id).Include(r => r.User);

            var registros = _context.Registrations.Where(r => r.UserId == id).Include(r => r.Training).Include(r => r.Training.Modules);//.Take(paging.Take).Skip(paging.Skip);

            return registros;
        }

        public IQueryable<Registration> GetRegistrationsByUserMostRecent(int id /*Paging paging*/)
        {
            return _context.Registrations.Where(r => r.UserId == id).Include(r => r.Training).OrderByDescending(d => d.RefreshDate);
        }

        public void Patch(int id, long refreshDate)
        {
            var registration = _context.Registrations.Find(id);

            registration.RefreshDate = refreshDate;
            _context.Registrations.Update(registration);
            _context.SaveChanges();
        }
  }

}