﻿using BlazorDemo.Shared.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemo.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private static List<LanguageApiModel> languages = new List<LanguageApiModel>()
        {
            new LanguageApiModel() { Name = "C", HasWasmCompiler = true },
            new LanguageApiModel() { Name = "Rust", HasWasmCompiler = true },
            new LanguageApiModel() { Name = "Go", HasWasmCompiler = true },
            new LanguageApiModel() { Name = "Java", HasWasmCompiler = false },
            new LanguageApiModel() { Name = "Python", HasWasmCompiler = false },
            new LanguageApiModel() { Name = "C#", HasWasmCompiler = true },
            new LanguageApiModel() { Name = "Kotlin", HasWasmCompiler = false },
            new LanguageApiModel() { Name = "Ruby", HasWasmCompiler = false },
        };

        [HttpGet]
        public List<LanguageApiModel> Get()
        {
            return languages;
        }

        [HttpPost]
        public IActionResult Post(LanguageApiModel model)
        {
            languages.Add(model);
            return Ok();
        }
    }
}
