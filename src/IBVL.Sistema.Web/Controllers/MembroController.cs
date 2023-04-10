
using IBVL.Sistema.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using WSCorreiros;

namespace IBVL.Sistema.Web.Controllers
{
    public class MembroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(MembroDto membroDto)
            {
            if (!ModelState.IsValid) return BadRequest(membroDto);

            return View();
        }


        [HttpGet, ActionName("BuscaCep")]
        public async Task<IActionResult> Create(string cep)
        {
            var endereco = await BuscaCepAsync(cep);

            return View(endereco);
        }


        private async Task<EnderecoDto> BuscaCepAsync(string cep)
        {
            var ws = new AtendeClienteClient();
            consultaCEPResponse end = await ws.consultaCEPAsync(cep);

            EnderecoDto endereco = new()
            {
                CEP = cep,
                Logradouro = end.@return.end,
                Cidade = end.@return.cidade,
                Bairro = end.@return.bairro,
                Estado = end.@return.uf,
                Complemento = end.@return.complemento2

            };

            return endereco;

        }











    }

}

