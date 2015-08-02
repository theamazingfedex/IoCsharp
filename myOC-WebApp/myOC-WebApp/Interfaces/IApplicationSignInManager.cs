using System.Threading.Tasks;

namespace myOC_WebApp.Controllers
{
    public interface IApplicationSignInManager
    {
        //ApplicationSignInManager(IApplicationUserManager userManager, IAuthenticationManager authenticationManager);
        //    : base(userManager, authenticationManager)
        //{
        //}

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        //{
        //    return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        //}

        //public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        //{
        //    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        //}
    }
}