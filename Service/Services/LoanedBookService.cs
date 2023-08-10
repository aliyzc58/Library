using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoanedBookService : GenericService<LoanedBook>, ILoanedBookService
    {
        public LoanedBookService(IGenericRepository<LoanedBook> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
