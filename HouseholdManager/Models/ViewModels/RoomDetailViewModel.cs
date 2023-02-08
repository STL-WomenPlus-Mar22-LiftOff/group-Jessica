using System.ComponentModel;

namespace HouseholdManager.Models.ViewModels
{
    public class RoomDetailViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomIcon { get; set; }
        public List<Mission> Missions { get; set; }

        [DisplayName("Dirt-O-Meter")]
        public int DirtLevel { get; set; }


        public RoomDetailViewModel()
        {
            RoomId = 0;
            RoomName = "";
            RoomIcon = "";
            Missions = new List<Mission>();
            DirtLevel = 0;
        }

        public RoomDetailViewModel(Room room, List<Mission> missions)
        {
            RoomId = room.RoomId;
            RoomName = room.Name;
            RoomIcon = room.Icon;
            Missions = missions;
            DirtLevel = room.DirtLevel;
        }
    }
}
