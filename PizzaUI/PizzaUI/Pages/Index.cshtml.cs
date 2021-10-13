using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaUI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using PizzaUI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PizzaUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        public List<Pizza>? Menu { get; set; }
        public List<Topping>? Toppings { get; set; }
        public string? PictureLocation { get; set; }
        public double PizzaPrice { get; set; }
        public List<Pizza>? PizzasSelected { get; set; }
        [BindProperty]
        [Required]
        public string PizzaSize { get; set; }
        [BindProperty]
        [Required]
        public string ClientName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGetAsync()
        {
            Menu = await _httpClient.GetFromJsonAsync<List<Pizza>>("http://localhost:5000/menu");
            if (!HttpContext.Session.Keys.Contains("menu"))
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "menu", Menu);
            };
            PizzasSelected = SessionHelper.GetObjectFromJson<List<Pizza>>(HttpContext.Session, "cart");
        }

        public void OnPostAddPizza(int pizzaID)
        {
            ViewData["PizzaSize"] = PizzaSize;
            Menu = SessionHelper.GetObjectFromJson<List<Pizza>>(HttpContext.Session, "menu");
            if (Menu != null)
            {
                var pizzaToAdd = from pizza in Menu
                                 where pizza.Id == pizzaID
                                 select pizza;
                if (pizzaToAdd != null)
                {
                    PizzasSelected = SessionHelper.GetObjectFromJson<List<Pizza>>(HttpContext.Session, "cart");
                    if (PizzasSelected == null)
                    {
                        PizzasSelected = new();
                    }
                    if (PizzaSize != null)
                    {
                        pizzaToAdd.First().UpdateSize(PizzaSize);
                        PizzasSelected.Add(pizzaToAdd.First());
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", PizzasSelected);
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostCompleteOrderAsync(string clientName)
        {
            PizzasSelected = SessionHelper.GetObjectFromJson<List<Pizza>>(HttpContext.Session, "cart");
            if (PizzasSelected != null)
            {
                Order order = new(clientName, PizzasSelected);
                await _httpClient.PostAsJsonAsync<Order>("http://localhost:5000/order", order);
                HttpContext.Session.Clear();
            }
            return RedirectToPage("Index");
        }

        public async Task<PartialViewResult> OnGetChooseToppgingsModalPartialAsync()
        {
            this.Toppings = await _httpClient.GetFromJsonAsync<List<Topping>>("http://localhost:5000/toppings");
            return new PartialViewResult
            {
                ViewName = "_ChooseToppings",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<List<Topping>>(ViewData, this.Toppings)
            };
        }

        public async Task OnPostAddCustomPizzaAsync(List<int> selectedToppingsIds, string pizzaName)
        {
            Toppings = await _httpClient.GetFromJsonAsync<List<Topping>>("http://localhost:5000/toppings");
            PizzasSelected = SessionHelper.GetObjectFromJson<List<Pizza>>(HttpContext.Session, "cart");
            if (PizzasSelected == null)
            {
                PizzasSelected = new();
            }
            if (PizzaSize != null)
            {
                List<Topping> selectedToppings = new();
                foreach (int id in selectedToppingsIds)
                {
                    var toppingToAdd = from topping in Toppings
                                       where topping.Id == id
                                       select topping;
                    if (toppingToAdd != null)
                    {
                        selectedToppings.Add(toppingToAdd.First());
                    }
                }
                Pizza customPizzaToAdd = new(-1, pizzaName, selectedToppings, PizzaSize, true);
                PizzasSelected.Add(customPizzaToAdd);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", PizzasSelected);
            }
        }
    }
}