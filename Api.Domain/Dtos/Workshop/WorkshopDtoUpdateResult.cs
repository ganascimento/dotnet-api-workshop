namespace Api.Domain.Dtos.Workshop
{
    public class WorkshopDtoUpdateResult {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string Uf { get; set; }
    }
}