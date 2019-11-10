﻿using Banking.Application.Exceptions;
using Banking.Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Repositories.EFCore
{
    public class AccountRepository : EfCoreRepository<Account, BankingContext>
    {
        private readonly BankingContext _context;
        public AccountRepository(BankingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account> GetByIBanNumber(string ibanNumber)
        {
            var account = await _context.Account.FirstOrDefaultAsync(x => x.IBanNumber == ibanNumber);

            return account;
        }
    }
}
