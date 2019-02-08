//using BaseballCommander.BusinessLogic;
//using BaseballCommander.BusinessLogic.Interfaces;

using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace BaseballCommander.Api.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        public PlayerController()
        {
        }
    }
}