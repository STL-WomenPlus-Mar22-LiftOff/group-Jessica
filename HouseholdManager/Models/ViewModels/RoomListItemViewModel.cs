namespace HouseholdManager.Models.ViewModels
{
    public class RoomListItemViewModel
    {
        public RoomListItemViewModel(string name, string icon, int id = -1)
        {
            Id = id;
            Name = $"{icon} {name}";
            NameHtml = $"<text class='icon-font'>{icon}</text> {name}";
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public string NameHtml { get; set; }

    }
}
