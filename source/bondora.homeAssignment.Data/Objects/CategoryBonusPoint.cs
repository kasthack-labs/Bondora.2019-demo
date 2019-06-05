namespace bondora.homeAssignment.Data
{

    public class CategoryBonusPoint : IId, IDeleteable
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public long BonusPointsId { get; set; }
        public long ProductCategoryId { get; set; }
    }
}
