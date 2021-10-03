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
        public List<Pizza> menu { get; set; }
        public string picLocation { get; set; }
        public double pizzaPrice { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGetAsync()
        {
            menu = await _httpClient.GetFromJsonAsync<List<Pizza>>("http://localhost:5000/menu");
        }
    }
}