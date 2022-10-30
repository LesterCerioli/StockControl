namespace StockControl.Modules.Product.Models
{
    public class Product
    {
        publicstring ShortDescription { get; set; }

        publicstring Description { get; set; }

        public string Specification { get; set; }

        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public bool HasOptions { get; set; }

        public bool IsVisibleIndividually { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public bool StockTrackingIsEnabled { get; set; }

        public int StockQuantity { get; set; }

        [StringLength(450)]
        public string Sku { get; set; }

        [StringLength(450)]
        public string Gtin { get; set; }

        [StringLength(450)]
        public string NormalizedName { get; set; }

        public int DisplayOrder { get; set; }

        public long? VendorId { get; set; }

        public Media ThumbnailImage { get; set; }

        public IList<ProductMedia> Medias { get; protected set; } = new List<ProductMedia>();

        public IList<ProductLink> ProductLinks { get; protected set; } = new List<ProductLink>();

        public IList<ProductLink> LinkedProductLinks { get; protected set; } = new List<ProductLink>();

        public IList<ProductAttributeValue> AttributeValues { get; protected set; } = new List<ProductAttributeValue>();

        public IList<ProductOptionValue> OptionValues { get; protected set; } = new List<ProductOptionValue>();

        public IList<ProductCategory> Categories { get; protected set; } = new List<ProductCategory>();

        public IList<ProductPriceHistory> PriceHistories { get; protected set; } = new List<ProductPriceHistory>();

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public long? BrandId { get; set; }

        public Brand Brand { get; set; }

        public long? TaxClassId { get; set; }

        public TaxClass TaxClass { get; set; }
        
    }
}