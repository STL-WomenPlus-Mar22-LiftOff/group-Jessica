namespace HouseholdManager.Models.ViewModels
{
    public class RoomDetailViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomIcon { get; set; }
        public List<Mission> Missions { get; set; }


        public RoomDetailViewModel()
        {
            RoomId = 0;
            RoomName = "";
            RoomIcon = "";
            Missions = new List<Mission>();
        }

        public RoomDetailViewModel(int roomId, string roomName, string roomIcon, List<Mission> missions)
        {
            RoomId = roomId;
            RoomName = roomName;
            RoomIcon = roomIcon;
            Missions = missions;
        }
    }
}
