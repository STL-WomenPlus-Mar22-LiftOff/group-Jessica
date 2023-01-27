namespace HouseholdManager.Models.ViewModels
{
    public class ThemePickerViewModel
    {
        public string? Id { get; set; }
        public string? Text { get; set; }

        public List<ThemePickerViewModel> GetThemes()
        {
            List<ThemePickerViewModel> themeList = new List<ThemePickerViewModel>();
            themeList.Add(new ThemePickerViewModel { Id = "light", Text = "Light Theme" });
            themeList.Add(new ThemePickerViewModel { Id = "dark", Text = "Dark Theme" });
            themeList.Add(new ThemePickerViewModel { Id = "deepblue", Text = "Deep Blue Theme" });
            return themeList;
        }
    }
}
