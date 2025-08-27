using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Data.DTOs.Address;
using Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Attributes;
using Services.Utilities;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area("UserPanel")]
    [ControllerInfo("آدرس ها", "پنل کاربری")]
    public class AddressController : Controller
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddressController(IUserRepository userRepository, IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(CancellationToken cancellationToken)
        {
            var addresses = _userAddressRepository.GetAddress(ClaimUtility.GetUserId(User));
            return View(addresses);
        }

        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View(new AddUserAddressDto());
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto address)
        {
            string userId = ClaimUtility.GetUserId(User);
            address.UserId = userId;
            _userAddressRepository.AddnewAddress(address);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var model = _userAddressRepository.GetById(id);
            await _userAddressRepository.DeleteAsync(model, cancellationToken);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_userAddressRepository.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UserAddressDto address, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(address);
            }
            var model = _mapper.Map<UserAddress>(address);
            await _userAddressRepository.UpdateAsync(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

    }
}
