using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Data;
using Module4HW3.Data.Entities;

namespace Module4HW3
{
    public class LazyLoadingWork
    {
        private readonly ApplicationDbContext _context;

        public LazyLoadingWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Run()
        {
            await FirstQuery();
            await SecondQuery();
            await ThirdQuery();
            await FourthQuery();
            await FifthQuery();
            await SixthQuery();
        }

        public async Task FirstQuery()
        {
            var officeEmployee = await _context.OfficeEntities
                .GroupJoin(
                _context.EmployeeEntities,
                office => office.OfficeId,
                employee => employee.OfficeId,
                (o, e) => new { office = o, employee = e })
                .SelectMany(
                officesEmployees => officesEmployees.employee.DefaultIfEmpty(),
                (o, e) => new { office = o.office, employee = e })
                .GroupJoin(
                _context.TitleEntities,
                employee => employee.employee.TitleId,
                title => title.TitleId,
                (e, t) => new { office = e.office, employee = e.employee, title = t })
                .SelectMany(
                employeesTitles => employeesTitles.title.DefaultIfEmpty(),
                (e, t) => new { office = e.office, employee = e.employee, title = t })
                .ToListAsync();
        }

        public async Task SecondQuery()
        {
            var secondQuery = await _context.EmployeeEntities.Select(s => EF.Functions.DateDiffMonth(s.HiredDate, DateTime.UtcNow)).ToListAsync();
        }

        public async Task ThirdQuery()
        {
            await ExecuteTransaction(async () =>
            {
                var employee = await _context.EmployeeEntities.FirstOrDefaultAsync();
                employee.FirstName = "Mary";
                await _context.SaveChangesAsync();
                var title = await _context.TitleEntities.FirstOrDefaultAsync();
                title.Name = "Title 1";
                await _context.SaveChangesAsync();
            });
        }

        public async Task FourthQuery()
        {
            await ExecuteTransaction(async () =>
            {
                await _context.AddAsync(new TitleEntity() { TitleId = 6, Name = "Title Six" });
                await _context.AddAsync(new ProjectEntity() { ProjectId = 6, ClientId = 1, Name = "ProjectSeven", Budget = 150000M, StartedDate = new DateTime(2019, 10, 01) });
                await _context.SaveChangesAsync();
                await _context.AddAsync(new EmployeeEntity() { EmployeeId = 6, FirstName = "SixN", SecondName = "SixL", DateOfBirth = new DateTimeOffset(new DateTime(1970, 05, 14)), HiredDate = new DateTimeOffset(new DateTime(2000, 02, 02)), OfficeId = 2, TitleId = 6 });
                await _context.SaveChangesAsync();
                await _context.AddAsync(new EmployeeProjectEntity() { EmployeeProjectId = 1, EmployeeId = 6, ProjectId = 6, Rate = 4500M, StartedDate = new DateTime(2020, 04, 01) });
                await _context.SaveChangesAsync();
            });
        }

        public async Task FifthQuery()
        {
            await ExecuteTransaction(async () =>
            {
                var employee = await _context.EmployeeEntities.OrderBy(e => e.EmployeeId).LastAsync();
                _context.EmployeeEntities.Remove(employee);
                await _context.SaveChangesAsync();
            });
        }

        public async Task<List<string>> SixthQuery()
        {
            var sixthQuery = _context.TitleEntities
                .Join(
                _context.EmployeeEntities,
                title => title.TitleId,
                employee => employee.TitleId,
                (t, e) => new { title = t, employee = e })
                .GroupBy(g => g.title.Name)
                .Select(s => s.Key)
                .Where(w => !EF.Functions.Like(w, "%a%"));

            return await sixthQuery.ToListAsync();
        }

        public async Task ExecuteTransaction(Func<Task> func)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await func.Invoke();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}