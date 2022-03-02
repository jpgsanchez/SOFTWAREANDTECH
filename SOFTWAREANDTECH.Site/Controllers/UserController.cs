using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using SOFTWAREANDTECH.Business.User;
using SOFTWAREANDTECH.Business.Gender;

using SOFTWAREANDTECH.Entities.DTOs;
using SOFTWAREANDTECH.Entities.Models;

namespace SOFTWAREANDTECH.Site.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ConsultaUsuario()
        {
            UserProcess process = new UserProcess();
            List<MUser> lst = process.GetUserList(new UserDTO());

            return Json(await Task.FromResult(lst));
        }

        public async Task<ActionResult> ConsultaGenero()
        {
            GenderProcess process = new GenderProcess();
            List<GenderDTO> lst = process.GetGenderList();

            return Json(await Task.FromResult(lst));
        }

        public async Task<ActionResult> GuardaUsuario(UserDTO obj)
        {
            try
            {
                UserProcess process = new UserProcess();
                bool correct = process.ProcesaInformacion(obj);

                return Json(await Task.FromResult(correct));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> EliminaUsuario(UserDTO obj)
        {
            try
            {
                UserProcess process = new UserProcess();
                bool correct = process.DeleteUser(obj);

                return Json(await Task.FromResult(correct));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}