namespace Wordle.Api.Data
{
    public class Setting
    {
        public int SettingId { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;

        public static string? GetSetting(string name, AppDbContext context)
        {
            return context.Settings.FirstOrDefault(s => s.Name == name)?.Value;
        }
        public static void SetSetting(string name, string value, AppDbContext context)
        {
            var setting = context.Settings.FirstOrDefault(s => s.Name == name);
            if (setting is null)
            {
                setting = new Setting { Name = name };
                context.Settings.Add(setting);
            }
            setting.Value = value;
            context.SaveChanges();
        }

    }
}
