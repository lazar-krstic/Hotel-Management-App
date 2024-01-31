using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Last name is required!")]
        public string LastName { get; set; }

        public RoomTypeModel RoomType { get; set; }
        public BookRoomModel(IDatabaseData db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            if (RoomTypeId > 0)
            {
                RoomType = db.GetRoomTypeById(RoomTypeId);
            }
        }
        public IActionResult OnPost()
        {
            db.BookGuest(FirstName, LastName, StartDate, EndDate, RoomTypeId);
            return RedirectToPage("/Index");
        }
    }
}