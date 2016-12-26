using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AccountValidationService.Models;
using AccountValidationService.Tools;

namespace AccountValidationService.Controllers
{
    public class AccountsController : ApiController
    {
        private AccountValidationServiceContext db = new AccountValidationServiceContext();

        // GET: api/Accounts
        public IQueryable<AccountDTO> GetAccounts()
        {
            var accounts = from a in db.Accounts
                           select new AccountDTO()
                           {
                               Email = a.Email,
                               Iban = a.Iban,
                               Id = a.Id,
                               Username = a.Username
                           };

            return accounts;
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(AccountDTO))]
        public async Task<IHttpActionResult> GetAccount(int id)
        {

            var account = await db.Accounts.Select(b =>
              new AccountDTO()
              {

                  Username = b.Username,
                  Id = b.Id,
                  Iban = b.Iban,
                  Email = b.Email
              }).SingleOrDefaultAsync(b => b.Id == id);

            if (account == null)
            {
                return NotFound();
            }


            return Ok(account);
        }

        // GET: api/Accounts/?email=&username=&iban=
        [ResponseType(typeof(AccountLoginDTO))]
        public async Task<IHttpActionResult> GetAccount(string email, string username, string iban)
        {
            AccountLoginDTO account = new AccountLoginDTO(email, username, iban);
            account.ValidateInputAccount();

            //Invalid account parameters
            if (account.IsInputValid == false)  return Ok(account);


            //Valid account parameters
            AccountLoginDTO accountToSearch = await db.Accounts.Select(b =>
              new AccountLoginDTO()
              {
                  Username = b.Username,
                  Id = b.Id,
                  Iban = b.Iban,
                  Email = b.Email,
                  
              }).SingleOrDefaultAsync(b => b.Username == username && b.Email == email && b.Iban == iban);

            //Account not found
            if (accountToSearch == null)
            {
                account.DoesAccountExist = false;
                account.Id = 0;
                account.Username = null;
                account.Email = null;
                account.Iban = null;
                
                account.ErrorMessages.Add("Account not found !") ;
            }
            else
            {
                account = accountToSearch;

                account.IsInputValid = true;
                account.DoesAccountExist = true;
            }


            return Ok(account);
        }

        // PUT: api/Accounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccount(int id, Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.Id)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Accounts
        [ResponseType(typeof(AccountRegisterDTO))]
        public async Task<IHttpActionResult> PostAccount(Account account)
        {
            AccountRegisterDTO accountToRegister = new AccountRegisterDTO(account);
            accountToRegister.ValidateInputAccount();

            //Invalid account parameters
            if (accountToRegister.IsInputValid == false)
            {
                return Ok(accountToRegister);
                //return CreatedAtRoute("DefaultApi", new { id = accountToRegister.Id }, accountToRegister);

            }

            //Valid account parameters
            AccountRegisterDTO accountToSearch = await db.Accounts.Select(b =>
              new AccountRegisterDTO()
              {
                  //Id = b.Id,
                  Username = b.Username,
                  Iban = b.Iban,
                  Email = b.Email,

              }).FirstOrDefaultAsync(b => ( b.Username.Equals( accountToRegister.Username) || b.Email.Equals(accountToRegister.Email) || b.Iban.Equals(accountToRegister.Iban) ) );

            //Account already registered
            if (accountToSearch != null)
            {
                //accountToRegister = accountToSearch;
                //accountToRegister.Id = 0;
                accountToRegister.Clear();

                accountToRegister.IsInputValid = true;
                accountToRegister.DoesAccountExist = true;
                accountToRegister.IsRegistrationSuccessful = false;
                accountToRegister.ErrorMessages.Add("Account already exists !");
                accountToRegister.ErrorMessages.Add("Username, Email and IBAN have to be unique.");


                return Ok(accountToRegister);

            }
            else
            {

                accountToRegister.DoesAccountExist = false;
                accountToRegister.IsInputValid = true;
                //account.Id = 0;

                try
                {
                    db.Accounts.Add(account);
                    await db.SaveChangesAsync();


                    accountToRegister.IsRegistrationSuccessful = true;

                    //  return CreatedAtRoute("DefaultApi", new { id = accountToRegister.Id }, accountToRegister);
                    return CreatedAtRoute("DefaultApi", null, accountToRegister);



                }
                catch (Exception)
                {

                    accountToRegister.IsRegistrationSuccessful = false;
                }
                

            }

           // return CreatedAtRoute("DefaultApi", new { id = accountToRegister.Id }, accountToRegister);

            return Ok(accountToRegister);




            // New code:

            //var dto = new AccountRegisterDTO()
            //{
            //    Email = account.Email,
            //    Iban = account.Iban,
            //    Id = account.Id,
            //    Username = account.Username
            //};


            //return CreatedAtRoute("DefaultApi", new { id = account.Id }, dto);
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(Account))]
        public async Task<IHttpActionResult> DeleteAccount(int id)
        {
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            db.Accounts.Remove(account);
            await db.SaveChangesAsync();

            return Ok(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountExists(int id)
        {
            return db.Accounts.Count(e => e.Id == id) > 0;
        }
    }
}