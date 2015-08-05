using myOC_WebApp.Controllers;
using myOC_WebApp.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace myOC_WebApp.Interfaces
{
    internal interface IManageController
    {
        Task<ActionResult> Index(ManageController.ManageMessageId? message);

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> RemoveLogin(string loginProvider, string providerKey);

        //
        // GET: /Manage/AddPhoneNumber
        ActionResult AddPhoneNumber();

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model);

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> EnableTwoFactorAuthentication();

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> DisableTwoFactorAuthentication();

        //
        // GET: /Manage/VerifyPhoneNumber
        Task<ActionResult> VerifyPhoneNumber(string phoneNumber);

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model);

        //
        // GET: /Manage/RemovePhoneNumber
        Task<ActionResult> RemovePhoneNumber();

        //
        // GET: /Manage/ChangePassword
        ActionResult ChangePassword();

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> ChangePassword(ChangePasswordViewModel model);

        //
        // GET: /Manage/SetPassword
        ActionResult SetPassword();

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        Task<ActionResult> SetPassword(SetPasswordViewModel model);

        //
        // GET: /Manage/ManageLogins
        Task<ActionResult> ManageLogins(ManageController.ManageMessageId? message);

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        ActionResult LinkLogin(string provider);

        //
        // GET: /Manage/LinkLoginCallback
        Task<ActionResult> LinkLoginCallback();

    }
}