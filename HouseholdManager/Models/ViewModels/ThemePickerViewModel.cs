namespace HouseholdManager.Models.ViewModels
{
    public class ThemePickerViewModel
    {
        public string ID { get; set; }
        public string Text { get; set; }

        public List<ThemePickerViewModel> GetThemes()
        {
            List<ThemePickerViewModel> themeList = new List<ThemePickerViewModel>();
            themeList.Add(new ThemePickerViewModel { ID = "bootstrap5", Text = "Light Mode" });
            themeList.Add(new ThemePickerViewModel { ID = "bootstrap5-dark", Text = "Dark Mode" });
            return themeList;
        }
    }
}
