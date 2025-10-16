using JadooTravel.Services.CategoryServices;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.ReservationServices;
using JadooTravel.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly ITestimonialService _testimonialService;

        public DashboardController(
            ICategoryService categoryService, 
            IDestinationService destinationService,
            IReservationService reservationService,
            ITestimonialService testimonialService)
        {
            _categoryService = categoryService;
            _destinationService = destinationService;
            _reservationService = reservationService;
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            // Verileri çek
            var destinations = await _destinationService.GetAllDestinationAsync();
            var categories = await _categoryService.GetAllCategoryAsync();
            var reservations = await _reservationService.GetAllReservationAsync();
            var testimonials = await _testimonialService.GetAllTestimonialAsync();

            // 1. Destination Analytics
            ViewBag.DestinationData = destinations.Select(d => new { 
                name = d.CityCountry, 
                price = d.Price 
            }).ToList();

            ViewBag.TotalDestinations = destinations.Count;
            
            if (destinations.Any())
            {
                ViewBag.AveragePrice = Math.Round(destinations.Average(d => d.Price), 0);
                ViewBag.MaxPrice = destinations.Max(d => d.Price);
                ViewBag.MinPrice = destinations.Min(d => d.Price);
            }
            else
            {
                ViewBag.AveragePrice = 0;
                ViewBag.MaxPrice = 0;
                ViewBag.MinPrice = 0;
            }

            // 2. Category Analytics
            ViewBag.TotalCategories = categories.Count;
            ViewBag.ActiveCategories = categories.Count; // Tüm kategoriler aktif sayılıyor
            ViewBag.PopularCategories = Math.Min(categories.Count, 3); // En fazla 3 popüler
            ViewBag.CategoryPercentage = categories.Count > 0 ? 100 : 0; // Tüm kategoriler aktif

            // 3. Testimonial Review Analytics (Revenue Analytics yerine)
            ViewBag.TotalTestimonials = testimonials.Count;
            
            if (testimonials.Any())
            {
                // Ortalama rating hesapla (1-5 arası)
                ViewBag.AverageRating = Math.Round(testimonials.Average(t => t.Rating), 1);
                
                // Rating dağılımı
                ViewBag.FiveStarCount = testimonials.Count(t => t.Rating == 5);
                ViewBag.FourStarCount = testimonials.Count(t => t.Rating == 4);
                ViewBag.ThreeStarBelowCount = testimonials.Count(t => t.Rating <= 3);
            }
            else
            {
                ViewBag.AverageRating = 0;
                ViewBag.FiveStarCount = 0;
                ViewBag.FourStarCount = 0;
                ViewBag.ThreeStarBelowCount = 0;
            }
            
            // Bu ay ve geçen ay geliri (örnek hesaplamalar)
            var currentMonth = DateTime.Now.Month;
            var currentMonthReservations = reservations.Count(r => r.ReservationDate.Month == currentMonth);
            var lastMonthReservations = reservations.Count(r => r.ReservationDate.Month == currentMonth - 1);
            
            ViewBag.MonthlyRevenue = currentMonthReservations * 1500;
            ViewBag.LastMonthRevenue = lastMonthReservations * 1500;

            // 4. Latest 5 Destinations (Top Paying Clients yerine)
            ViewBag.LatestDestinations = destinations
                .OrderByDescending(d => d.DestinationId) // En son eklenenler (Id'ye göre sıralama)
                .Take(5)
                .Select(d => new {
                    Id = d.DestinationId,
                    CityCountry = d.CityCountry,
                    Price = d.Price,
                    Description = d.Description,
                    AddedDate = DateTime.Now.AddDays(-new Random().Next(1, 30)) // Örnek tarih
                })
                .ToList();

            return View();
        }
    }
}
