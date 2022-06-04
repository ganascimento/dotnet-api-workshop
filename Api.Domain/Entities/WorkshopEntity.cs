namespace Api.Domain.Entities
{
    public class WorkshopEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string Uf { get; set; }
        public int AuthId { get; set; }
        
        public virtual AuthEntity Auth { get; set; }
    }
}