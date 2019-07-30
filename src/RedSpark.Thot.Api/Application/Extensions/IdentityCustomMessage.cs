using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSpark.Thot.Api.Application.Extensions
{
    public class IdentityCustomMessage : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = "auth.error" }; }
        public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "auth.concurrency.failure" }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "auth.password.mismatch" }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "auth.invalid.token" }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "auth.login.already.associated" }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = "auth.invalid.username" }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = "auth.invalid.username" }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = "auth.duplicate.username" }; }
        // TODO: Terminar
    }
}
