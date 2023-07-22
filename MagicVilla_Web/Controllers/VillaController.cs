﻿using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();
            APIResponse response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                string? responseResult = Convert.ToString(response.Result);
                list = JsonConvert
                    .DeserializeObject<List<VillaDTO>>
                        (responseResult);
            }

            return View(list);
        }
    }
}
