using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaUI.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace PizzaUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        public List<Pizza>? Menu { get; set; }
        public string? PictureLocation { get; set; }
        public double PizzaPrice { get; set; }
        public List<Pizza>? PizzasSelected { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGetAsync()
        {
            Menu = await _httpClient.GetFromJsonAsync<List<Pizza>>("http://localhost:5000/menu");  
        }

        public async Task OnPostAddPizzaAsync(int pizzaId)
        {
            Menu = await _httpClient.GetFromJsonAsync<List<Pizza>>("http://localhost:5000/menu");
            var pizzaToAdd = from pizza in Menu
                               where pizza.Id == pizzaId
                               select pizza;
            if (pizzaToAdd != null) 
            {
                PizzasSelected.Add(pizzaToAdd.Single());
            }
        }
    }
}