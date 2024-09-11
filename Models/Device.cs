namespace smarthousedevices.Models
{
    public class Device
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
        public required string Type { get; set; }

    }
}
