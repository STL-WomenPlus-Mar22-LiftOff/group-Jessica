namespace HouseholdManager.Models.ViewModels
{
    public class ListMemberViewModel
    {
        public ListMemberViewModel() 
        {
            Id = string.Empty;
            Name = string.Empty;
        }

        public ListMemberViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}
