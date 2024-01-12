namespace LookUpBrazil.API.ViewModels.Locations
{
    public class EditorLocationViewModel
    {
        public string State { get; set; }
        public string City { get; set; }
        public Guid CategoryId { get; set; } = Guid.Parse("7f154da9-313f-43c3-0e22-08dc139421ee");
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    }
}
