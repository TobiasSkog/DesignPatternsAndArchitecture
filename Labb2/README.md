# Om uppgiften

Denna uppgift handlar om att identifiera vanligt f�rekommande designm�nster/arkitekturer i .NET i befintlig kod.

# Vad du ska g�ra

Du ska ladda hem och kolla igenom de fyra olika kodprojekten nedan f�r att avg�ra vilket designm�nster de anv�nder. 

Varje kod anv�nder ett designm�nster och du ska f�r varje exempel (A-D) identifiera ett designm�nster. 

Koder du ska ladda hem och kolla igenom:

- [x]  Code A
- [x]  Code B
- [x]  Code C
- [x]  Code D

Observera att koderna troligen inte g�r att k�ra och att du egentligen bara ska l�sa igenom koden f�r att identifiera designm�nster.

# L�sning

## Code A

Designm�nster: Factory Method

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

Designm�nster: Singleton

Privat konstrukt�r s� att det inte g�r att skapa en instans av objektet utifr�n.
Statisk metod f�r att skapa en instans av objektet d�r vi f�rst kontrollerar om property _instance har ett v�rde, om den **INTE** har det s� skapar vi en ny instans av objektet med den privata konstrukt�ren och tilldelar det till _instance, returnerar _instance
Det finns ocks� klasser med tr�d s�kra singletons d�r vi har `Padlock` en privat statiskt readonly object som en property och innan vi tilldelar ett v�rde s� anv�nder vi oss av `lock(Padlock)` d�r den f�rsta tr�den som kommer hit kommer f� v�rdet lock och forts�tta i koden medans resterande tr�dar f�r v�nta p� deras tur. P� s� s�tt s�krar vi upp skapandet av objektet och ser till att om vi vid programstart har flera tr�dar som vill ha en instans av objektet s� skapar vi inte flera.
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

Designm�nster: Strategy

Alla delar av strategin �r f�rdelade i sina egna klasser.

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

Designm�nster: Adapter 

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

HRSystem agerar som v�ran Adapter med sin implementation av ISalaryProcessor interface och �vers�tter ProcessSalaries metoden till ProcessSalary metoden av ThirdPartyBillingSystem.

Adapterns jobb �r att konvertera r� employee data fr�n en 2d array av typen string till en lista av Employee objekt.

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

Broadcast agerar som v�ran Adapter med sin implementation av IBroadcaster interface och �vers�tter BroadcastToExternalPartners metoden till att interagera med MovieRegistry och ThirdPartyBroadcaster.

Adapterns jobb �r att konvertera film data i XML format fr�n MovieRegistry till JSON format som ThirdPartyBroadcaster beh�ver.