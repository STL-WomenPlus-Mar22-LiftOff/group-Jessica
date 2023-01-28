using System.ComponentModel;

namespace HouseholdManager.Models.ViewModels
{
    /// <summary>
    /// An extension of <see cref="EditMissionViewModel"></see> that includes room and member names/icons.
    /// </summary>
    public class FullMissionViewModel : EditMissionViewModel
    {
        public FullMissionViewModel(): base() 
        { 
            RoomName = string.Empty;
            RoomIcon = string.Empty;
            MemberName = string.Empty;
            MemberIcon = string.Empty;
        }

        /// <summary>
        /// Note that a query that gets a mission from the database for use
        /// with this view model must explicitly include the Mission and Room properties.
        /// </summary>
        public FullMissionViewModel(Mission mission) : base(mission) 
        {
            RoomName = mission.Room?.Name ?? string.Empty;
            RoomIcon = mission.Room?.Icon ?? string.Empty;
            MemberName = mission.Member?.DisplayName ?? string.Empty;
            MemberIcon = mission.Member?.Icon ?? string.Empty;
        }

        /* //Not currently in use
        public FullMissionViewModel(Mission mission, 
                                    string? member, 
                                    string? memberIcon, 
                                    string? room, 
                                    string? roomIcon) : base(mission)
        {
            RoomName = (room is null) ? string.Empty : room;
            RoomIcon = (roomIcon is null) ? string.Empty : roomIcon;
            MemberName = (member is null) ? string.Empty : member;
            MemberIcon = (memberIcon is null) ? string.Empty : memberIcon;
        }
        */

        [DisplayName("Member")]
        public string MemberName { get; set; }

        public string MemberIcon { get; set; }

        [DisplayName("Room")]
        public string RoomName { get; set; }

        public string RoomIcon { get; set;}
    }
}
