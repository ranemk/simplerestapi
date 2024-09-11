namespace smarthousedevices.Models.Entities
{
    public class UpdateDeviceDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
        public required string Type { get; set; }
    }
}
