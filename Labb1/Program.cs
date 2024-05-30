
using DesignPatterns.CreationalPatterns.FactoryMethodPattern;
using DesignPatterns.CreationalPatterns.SingeltonPattern;
using DesignPatterns.Utils;
using Labb1.StructuralPatterns.AdapterPattern;


// Use our singleton to ensure we have only one shopping cart per running instance of the software
ShoppingCart shoppingCart = ShoppingCart.GetInstance();

//Create our 4 different factories to create the 4 different subclasses: Electronics, Books, Foods, Drinks.
ElectronicsFactory electronicsFactory = new();
BookFactory bookFactory = new();
FoodFactory foodFactory = new();
DrinkFactory drinkFactory = new();

//Create our payment-gateway and -processor with the help from our adapter so that we can use PöyPal service
PöyPalGateway pöypalGateway = new();
IPaymentProcessor paymentProcessor = new PöyPalPaymentAdapter(pöypalGateway);

Console.WriteLine("Adding your products to the shopping cart.");
Console.WriteLine("\n\nPress any key to continue...\n\n");
Console.ReadKey();
Console.Clear();

// Add the product that our factories create directly to our shopping cart
shoppingCart.AddProduct(electronicsFactory.FactoryCreation("DigiWave V5 - Ultra Slim Smart Phone", "Brand *NEW* model! Many Wow!", Brand.DigiWave, 999.99m));
shoppingCart.AddProduct(electronicsFactory.FactoryCreation("DigiWave V5 PRO - Ultra Omega Slim Smart Phone", "Brand *NEW* Model! Sham Wow!", Brand.DigiWave, 1699.99m));
shoppingCart.AddProduct(electronicsFactory.FactoryCreation("VoltCore 85 S GRF-YY-F92 - Super Smart Phone!", "So Smart!", Brand.VoltCore, 1444.44m));
shoppingCart.AddProduct(electronicsFactory.FactoryCreation("TechNova phone", "It just works", Brand.TechNova, 15.73m));

shoppingCart.AddProduct(bookFactory.FactoryCreation("How To Tie Your Shoes", "820 Detailed Pages On How To Tie Your Shoes!", Brand.LitLoom, 63.20m));
shoppingCart.AddProduct(bookFactory.FactoryCreation("The Time I Met The Duke", "Titillating Story Of When I Met The Duke Of Holmsund", Brand.StoryVine, 49.99m));
shoppingCart.AddProduct(bookFactory.FactoryCreation("Danger In The Snow", "Detailed Explanation Of All 46 Finnish Words To Describe Different Types Of Snow!", Brand.PageTurner, 18.59m));
shoppingCart.AddProduct(bookFactory.FactoryCreation("Good Night Little Sailor", "A Extremely Detailed Description On How To Raise Alpacas", Brand.BookBliss, 23.50m));

shoppingCart.AddProduct(foodFactory.FactoryCreation("GLS - Giant Meat Slob", "So Tasty!", Brand.FreshBite, 29.99m));
shoppingCart.AddProduct(foodFactory.FactoryCreation("All Natural Horse Hair", "Farm To Table!", Brand.NutriHarvest, 99.99m));
shoppingCart.AddProduct(foodFactory.FactoryCreation("Homegrown Rabbit-Ears", "Very Natural! Pure Joy!", Brand.PurePlates, 169.99m));
shoppingCart.AddProduct(foodFactory.FactoryCreation("Ravager EXTREME", "5x 300g Burger Patties - 1x Bread", Brand.FreshBite, 3.25m));

shoppingCart.AddProduct(drinkFactory.FactoryCreation("Delicate Bath Water", "Freshly Taped Bath Water", Brand.SipSprings, 12.20m));
shoppingCart.AddProduct(drinkFactory.FactoryCreation("Moden Rain Water", "Very Modern And Great Test", Brand.AquaPulse, 69.99m));
shoppingCart.AddProduct(drinkFactory.FactoryCreation("Brewsky Bruh", "17% Brewski With The Boys", Brand.BevBurst, 3.99m));
shoppingCart.AddProduct(drinkFactory.FactoryCreation("Nicotine and Chamomile", "The Modern Take Definition Of What Perfect Tea Actually Tastes Like", Brand.RefreshBlend, 52.30m));
Console.WriteLine("\n\nYou will now get a description of all the products in your shopping cart.");
Console.WriteLine("\n\nPress any key to continue...\n\n");
Console.ReadKey();
Console.Clear();

Draw.PrintAllObjectsInfo(shoppingCart.GetProducts(), "Product Information", "Category");

Console.WriteLine("\n\nProceeding to checkout.");
Console.WriteLine("\n\nPress any key to continue...\n\n");
Console.ReadLine();
Console.Clear();

// getting the total amount to pay from our shopping cart
decimal totalAmount = shoppingCart.GetTotalAmount();
paymentProcessor.ProcessPayment(totalAmount);

Console.WriteLine("\n\nWe will now clear the shopping cart.");
Console.WriteLine("\n\nPress any key to continue...\n\n");
Console.ReadKey();
Console.Clear();

shoppingCart.ClearCart();

Console.WriteLine("\n\nPress any key to continue...\n\n");
Console.ReadKey();
Console.Clear();

Console.WriteLine("Thank you for shopping with us today.");
Console.WriteLine("\n\nPress any key to end...\n\n");
Console.ReadKey();

