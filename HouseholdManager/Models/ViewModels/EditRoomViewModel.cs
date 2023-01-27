using System.ComponentModel.DataAnnotations;

namespace HouseholdManager.Models.ViewModels
{
    public class EditRoomViewModel
    {
        public EditRoomViewModel(string name, string icon)
        {
            //-1 should always be invalid
            Id = -1;
            Name = name;
            Icon = icon;
        }

        public EditRoomViewModel(int id, Room room) 
        { 
            Id = id;
            Name = room.Name;
            Icon = room.Icon;
        }

        public EditRoomViewModel(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            Icon = room.Icon;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Room names are limited to 50 characters.")]
        public string Name { get; set; }

        [StringLength(5, ErrorMessage = "Invalid icon.")]
        public string Icon { get; set; }
    }
}
