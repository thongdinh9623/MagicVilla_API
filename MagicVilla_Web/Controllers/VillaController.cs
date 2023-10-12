using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService? _villaService;
        private readonly IMapper? _mapper;

        public VillaController(
            IVillaService villaService,
            IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateVilla(VillaCreateDto model)
        {
            if (ModelState.IsValid)
            {
                ApiResponse response
                    = await _villaService.CreateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO>? list = new();
            if (_villaService == null)
            {
                return View("Error");
            }
            ApiResponse response = await _villaService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                string? responseResult = Convert.ToString(response.Result);
                if (responseResult == null)
                {
                    return View("Error");
                }
                list = JsonConvert
                    .DeserializeObject<List<VillaDTO>>
                        (responseResult);
            }

            return View(list);
        }
    }
}
