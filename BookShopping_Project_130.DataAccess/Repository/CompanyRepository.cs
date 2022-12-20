using BookShopping_Project_130.DataAccess.Data;
using BookShopping_Project_130.DataAccess.Repository.IRepository;
using BookShopping_Project_130.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping_Project_130.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, 
        ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
            :base(context)
        {
            _context = context;
        }
        public void Update(Company company)
        {
            _context.Update(company);
        }
    }
}
