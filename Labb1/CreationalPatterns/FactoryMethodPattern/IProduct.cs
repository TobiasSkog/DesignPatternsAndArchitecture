namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern;
public interface IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }
}

public enum Category
{
    Electronics,
    Book,
    Food,
    Drink
}
public enum Brand
{
    // Electronics
    TechNova,
    DigiWave,
    Nextronix,
    VoltCore,
    // Books
    LitLoom,
    StoryVine,
    PageTurner,
    BookBliss,
    // Foods
    FreshBite,
    NutriHarvest,
    PurePlates,
    TasteBuds,
    // Drinks
    SipSprings,
    AquaPulse,
    BevBurst,
    RefreshBlend
}
