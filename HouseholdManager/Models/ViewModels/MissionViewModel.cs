using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HouseholdManager.Models.ViewModels
{
    public class MissionViewModel
    {
        //This should never be called, but a view model has to have 
        //a parameterless constructor
        public MissionViewModel() 
        {
            MissionId = -1;
            Point = 0;
        }

        public MissionViewModel(Mission mission) 
        {
            MissionId = mission.MissionId;
            MissionName = mission.MissionName;
            Point = mission.Point;
            DueDate = mission.DueDate;
            RoomName = mission.Room?.Name ?? string.Empty;
            RoomIcon = mission.Room?.Icon ?? string.Empty;
            MemberUserName = mission.Member?.UserName ?? string.Empty;
            MemberIcon = mission.Member?.Icon ?? string.Empty;
            Completed = mission.Completed;
        }

        public int MissionId { get; set; }

        public string MissionName { get; set; } = string.Empty;

        public string RoomName { get; set; } = string.Empty;

        public string RoomIcon { get; set; } = string.Empty;

        public int Point { get; set; }

        public DateTime DueDate { get; set; } = DateTime.Now;

        public string MemberUserName { get; set; } = string.Empty;

        public string MemberIcon { get; set; } = string.Empty;

        public bool Completed { get; set; } = false;
    }
}
