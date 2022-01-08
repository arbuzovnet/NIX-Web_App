namespace BL.DTO
{
    public class ChargerDTO : ProductDTO
    {
        public string Type { get; set; }
        public string Cable { get; set; }
        public string Connector { get; set; } 
        public bool FastCharging { get; set; }
    }
}
