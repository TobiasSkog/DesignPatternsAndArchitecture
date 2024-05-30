# Om uppgiften

Denna uppgift handlar om att identifiera vanligt förekommande designmönster/arkitekturer i .NET i befintlig kod.

# Vad du ska göra

Du ska ladda hem och kolla igenom de fyra olika kodprojekten nedan för att avgöra vilket designmönster de använder. 

Varje kod använder ett designmönster och du ska för varje exempel (A-D) identifiera ett designmönster. 

Koder du ska ladda hem och kolla igenom:

- [x]  Code A
- [x]  Code B
- [x]  Code C
- [x]  Code D

Observera att koderna troligen inte går att köra och att du egentligen bara ska läsa igenom koden för att identifiera designmönster.

# Lösning

## Code A

Designmönster: Factory Method

**Interface**: IMeal<br>
Subklasser:<br>
 - Hamburger
 - GreenSalad


**Abstract Factory Method**<br>
    abstract class Restaurant<br>
	    Property abstract IMeal PrepareMainCourse();

**Concrete Factory Methods**<br>
 - class FastFoodRestaurant : Restaurant
  - Outputs: Hamburger
 - class VegetarianRestaurant : Restaurant
  - Outputs: GreenSalad

## Code B

Designmönster: Singleton

Privat konstruktör så att det inte går att skapa en instans av objektet utifrån.
Statisk metod för att skapa en instans av objektet där vi först kontrollerar om property _instance har ett värde, om den **INTE** har det så skapar vi en ny instans av objektet med den privata konstruktören och tilldelar det till _instance, returnerar _instance
Det finns också klasser med tråd säkra singletons där vi har `Padlock` en privat statiskt readonly object som en property och innan vi tilldelar ett värde så använder vi oss av `lock(Padlock)` där den första tråden som kommer hit kommer få värdet lock och fortsätta i koden medans resterande trådar får vänta på deras tur. På så sätt säkrar vi upp skapandet av objektet och ser till att om vi vid programstart har flera trådar som vill ha en instans av objektet så skapar vi inte flera.
```csharp
public static SimpleThreadSafetyGreeter Instance
{
    get
    {
        lock (Padlock)
        {
            if (_instance == null)
            {
                _instance = new SimpleThreadSafetyGreeter();
            }

            return _instance;
        }
    }
}
```

## Code C

Designmönster: Strategy

Alla delar av strategin är fördelade i sina egna klasser.

**Strategy Interface**<br>
    IShippingProvider med decimal CalculateCost(Order order);

**Concrete Strategy**<br>
 - FedEx med decimal CalculateCost(Order order) => 10;
 - RoyalMail med decimal CalculateCost(Order order) => 8.5m;
 - UnitedParcelService med decimal CalculateCost(Order order) => 9;

**Context**<br>
    ShippingCostCalculationService<br>
        ShippingCostCalculationService(IShippingProvider shippingCost) => _shippingProvider = shippingCost;<br>
        decimal Calculate(Order order) => _shippingProvider.CalculateCost(order);<br>

## Code D

Designmönster: Adapter 

### BillingSystemExample

**Adapter Interface**<br>
    ISalaryProcessor<br>
        void ProcessSalaries(string[,] employees);

**Adaptee Class**<br>
    ThirdPartyBillingSystem<br>
        void ProcessSalary(List<Employee> employees)

**Adapter Class**<br>
    HRSystem : ISalaryProcessor<br>
        private readonly ThirdPartyBillingSystem _thirdPartyBillingSystem;

HRSystem agerar som våran Adapter med sin implementation av ISalaryProcessor interface och översätter ProcessSalaries metoden till ProcessSalary metoden av ThirdPartyBillingSystem.

Adapterns jobb är att konvertera rå employee data från en 2d array av typen string till en lista av Employee objekt.

### MovieBroadcasterExample

**Adapter Interface**<br>
    IBroadcaster<br>
        void BroadcastToExternalPartners();

**Adaptee Class**<br>
    MovieRegistry<br>
        XDocument GetAll()

**Adapter Class**<br>
    Broadcast : IBroadcaster<br>
        private readonly MovieRegistry _movieRegistry;<br>
        private readonly ThirdPartyBroadcaster _thirdPartyBroadcaster;

Broadcast agerar som våran Adapter med sin implementation av IBroadcaster interface och översätter BroadcastToExternalPartners metoden till att interagera med MovieRegistry och ThirdPartyBroadcaster.

Adapterns jobb är att konvertera film data i XML format från MovieRegistry till JSON format som ThirdPartyBroadcaster behöver.