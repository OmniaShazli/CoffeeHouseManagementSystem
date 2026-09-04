using CafeManagement.Core.Entities;
using global::CafeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Categories.AnyAsync())
                return;

            var categories = new[]
            {
            new Category { Name = "Hot Coffee" },
            new Category { Name = "Iced Coffee" },
            new Category { Name = "Tea" },
            new Category { Name = "Cold Drinks" },
            new Category { Name = "Desserts" },
            new Category { Name = "Bakery" },
            new Category { Name = "Breakfast" },
            new Category { Name = "Sandwiches" },
            new Category { Name = "Smoothies" },
            new Category { Name = "Fresh Juices" },
            new Category { Name = "Ice Cream" },
            new Category { Name = "Snacks" }
        };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var categoryIds = await context.Categories
                .ToDictionaryAsync(c => c.Name, c => c.Id);

            var items = new List<MenuItem>();

            void Add(
                string category,
                string name,
                decimal price,
                string description,
                string imageUrl)
            {
                items.Add(new MenuItem
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    IsAvailable = true,
                    ImageUrl = imageUrl,
                    CategoryId = categoryIds[category]
                });
            }

            Add("Hot Coffee", "Espresso", 45,
                "Rich and smooth single shot of espresso.",
                "https://images.unsplash.com/photo-1510707577719-ae7c14805e3a");

            Add("Hot Coffee", "Double Espresso", 60,
                "Double shot of bold and aromatic espresso.",
                "https://images.unsplash.com/photo-1510707577719-ae7c14805e3a");

            Add("Hot Coffee", "Americano", 55,
                "Espresso blended with hot water.",
                "https://images.unsplash.com/photo-1551030173-122aabc4489c");

            Add("Hot Coffee", "Cappuccino", 70,
                "Espresso with steamed milk and creamy foam.",
                "https://images.unsplash.com/photo-1710173472469-9d28e977914c?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y2FwcHVjY2lub3xlbnwwfDJ8MHx8fDA%3D");

            Add("Hot Coffee", "Caffe Latte", 75,
                "Smooth espresso with steamed milk.",
                "https://images.unsplash.com/photo-1561882468-9110e03e0f78");

            Add("Hot Coffee", "Flat White", 75,
                "Velvety espresso with perfectly steamed milk.",
                "https://plus.unsplash.com/premium_photo-1723291214437-09256cff6852?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8aG90JTIwQ2FyYW1lbCUyME1hY2NoaWF0b3xlbnwwfDJ8MHx8fDA%3D");

            Add("Hot Coffee", "Mocha", 80,
                "Espresso, chocolate and steamed milk.",
                "https://media.istockphoto.com/id/1141176330/photo/hot-chocolate-or-cocoa-on-wooden-table-background.webp?a=1&b=1&s=612x612&w=0&k=20&c=hsZr_RXw0ns80HcPx6-JHCRDn8c8nFJd66tDLiWv7y4=");

            Add("Hot Coffee", "Caramel Macchiato", 85,
                "Espresso, steamed milk and caramel flavor.",
                "https://media.istockphoto.com/id/2212070933/photo/tasty-latte-macchiato-in-glass-on-marble-table-closeup-coffee-drink.webp?a=1&b=1&s=612x612&w=0&k=20&c=rby0IWsw9kk_K3kswarx3-flJc47Rbsfg4oxED_7ubE=");

            Add("Hot Coffee", "Spanish Latte", 85,
                "Espresso with creamy milk and sweet condensed milk.",
                "https://images.unsplash.com/photo-1541167760496-1628856ab772");

            Add("Hot Coffee", "Hazelnut Latte", 85,
                "Creamy latte with a delicious hazelnut flavor.",
                
                "https://images.unsplash.com/photo-1632845407875-10b4d85e6bf8?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8TW9jaGF8ZW58MHx8MHx8fDA%3D");

            Add("Iced Coffee", "Iced Americano", 60,
                "Bold espresso served over ice.",
                "https://images.unsplash.com/photo-1752072251645-bad7014ae635?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDJ8fHxlbnwwfHx8fHw%3D");

            Add("Iced Coffee", "Iced Latte", 75,
                "Smooth espresso with cold milk and ice.",
                "https://images.unsplash.com/photo-1566704284379-0d6fdf3d229c?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fEljZWQlMjBMYXR0ZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Iced Coffee", "Iced Cappuccino", 75,
                "Cold cappuccino with creamy foam.",
                "https://images.unsplash.com/photo-1517701604599-bb29b565090c");

            Add("Iced Coffee", "Iced Mocha", 85,
                "Cold espresso with chocolate and milk.",
                "https://images.unsplash.com/photo-1579888071069-c107a6f79d82");

            Add("Iced Coffee", "Iced Caramel Macchiato", 90,
                "Iced espresso with milk and caramel.",
                "https://images.unsplash.com/photo-1662047102608-a6f2e492411f?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8SWNlZCUyMENhcmFtZWwlMjBNYWNjaGlhdG98ZW58MHx8MHx8fDA%3D");

            Add("Iced Coffee", "Iced Spanish Latte", 90,
                "Creamy Spanish latte served cold.",
                "https://media.istockphoto.com/id/2215304792/photo/cold-refreshing-iced-chai-tea-latte.webp?a=1&b=1&s=612x612&w=0&k=20&c=CaZPuAKgR5zwKdimxUkh3oNgRl1rlFBCTXazAUArTfo=");

            Add("Iced Coffee", "Iced Vanilla Latte", 85,
                "Refreshing iced latte with vanilla.",
                "https://media.istockphoto.com/id/1977903702/photo/dalgona-coffee-whipped-instant-coffee-in-a-glass-with-beans-and-shadow-on-a-light-background.webp?a=1&b=1&s=612x612&w=0&k=20&c=RWxqm1iST81bhBZRiYyp2YZ6E81pf0TzcOIayLd21Zg=");

            Add("Iced Coffee", "Iced Hazelnut Latte", 85,
                "Cold latte with roasted hazelnut flavor.",
                "https://images.unsplash.com/photo-1764298490445-6add12301888?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzB8fEljZWQlMjBMYXR0ZSUyMEhhemVsbnV0fGVufDB8fDB8fHww");

            Add("Iced Coffee", "Iced White Mocha", 90,
                "Iced espresso with creamy white chocolate.",
                "https://images.unsplash.com/photo-1570968915860-54d5c301fa9f");


            Add("Tea", "English Breakfast Tea", 40,
                "Classic rich black tea.",
                "https://media.istockphoto.com/id/1169880310/photo/cup-of-tea-isolated-on-white-background.webp?a=1&b=1&s=612x612&w=0&k=20&c=swSGyfziaPsbN61ryb6jDILCid9OnsbmbzR5evYCPnw=");

            Add("Tea", "Green Tea", 40,
                "Light and refreshing green tea.",
                "https://media.istockphoto.com/id/1279268425/photo/green-tea-and-tea-leaves-on-a-white-background-image-of-japanese-green-tea.webp?a=1&b=1&s=612x612&w=0&k=20&c=1nLo_1yfFsQ1ldk98e3piFx-XNmTRuvRhvcImyaVVl0=");

            Add("Tea", "Earl Grey Tea", 45,
                "Black tea with a delicate bergamot flavor.",
                "https://images.unsplash.com/photo-1498604636225-6b87a314baa0?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RWFybCUyMEdyZXklMjBUZWF8ZW58MHx8MHx8fDA%3D");

            Add("Tea", "Chamomile Tea", 45,
                "Aromatic and relaxing chamomile tea.",
                "https://media.istockphoto.com/id/1180894948/photo/cup-of-medicinal-chamomile-tea-chamomile-tea-on-the-wooden-table.webp?a=1&b=1&s=612x612&w=0&k=20&c=OPBpd1VCWmcavsfSVf4WTrMmunAsg5t5g9J3cpOKieg=");

            Add("Tea", "Mint Tea", 40,
                "Fresh and refreshing mint tea.",
                "https://images.unsplash.com/photo-1627435601361-ec25f5b1d0e5?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8TWludCUyMFRlYXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Tea", "Hibiscus Tea", 45,
                "Refreshing floral hibiscus tea.",
                "https://media.istockphoto.com/id/1192722029/photo/white-cup-of-healthy-hibiscus-tea-pouring-from-the-teapot-with-dried-hibiscus-flowers-on.webp?a=1&b=1&s=612x612&w=0&k=20&c=K4LNtTqa6Bwh9ntNzACL-L9Lr8V7MegPAUIeS-f6yno=");

            Add("Tea", "Peach Tea", 50,
                "Refreshing black tea with peach flavor.",
                "https://plus.unsplash.com/premium_photo-1663853293652-d99ebba231cf?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDh8fHxlbnwwfHx8fHw%3D");

            Add("Tea", "Lemon Tea", 45,
                "Black tea with fresh lemon.",
                "https://images.unsplash.com/photo-1637216789852-d2c6d5de6f68?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fExlbW9uJTIwVGVhfGVufDB8fDB8fHww");

            Add("Tea", "Chai Latte", 65,
                "Creamy milk tea with warm spices.",
                "https://media.istockphoto.com/id/1278225116/photo/masala-tea-flavoured-tea-chai-traditional-indian-hot-drink-with-various-spices-on-a-wooden.webp?a=1&b=1&s=612x612&w=0&k=20&c=F181oMzj4eB-zs22_DaJIurlEvmINauHbhDD01FOvls=");

            Add("Tea", "Matcha Latte", 75,
                "Smooth Japanese matcha blended with milk.",
                "https://images.unsplash.com/photo-1515823064-d6e0c04616a7");



        
            Add("Cold Drinks", "Coca-Cola", 35,
                "Classic chilled soft drink.",
                "https://images.unsplash.com/photo-1554866585-cd94860890b7");

            Add("Cold Drinks", "Pepsi", 35,
                "Classic chilled cola.",
                "https://images.unsplash.com/photo-1629203851122-3726ecdf080e");

            Add("Cold Drinks", "7UP", 35,
                "Refreshing lemon-lime soft drink.",
                "https://images.unsplash.com/photo-1624517286326-62fc932dffca?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8N1VQfGVufDB8fDB8fHww");

            Add("Cold Drinks", "Sprite", 35,
                "Crisp and refreshing lemon-lime drink.",
                "https://images.unsplash.com/photo-1680404005217-a441afdefe83?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U3ByaXRlfGVufDB8fDB8fHww");

            Add("Cold Drinks", "Schweppes", 40,
                "Refreshing sparkling ginger drink.",
                "https://images.unsplash.com/photo-1581006852262-e4307cf6283a");

            Add("Cold Drinks", "Sparkling Water", 35,
                "Chilled sparkling mineral water.",
                "https://images.unsplash.com/photo-1629470937827-9f1c9b9df448?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fHdhdGVyJTIwYm90dGVsfGVufDB8fDB8fHww");

         

            Add("Cold Drinks", "Lemon Soda", 45,
                "Sparkling soda with fresh lemon.",
                "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd");

          




            Add("Desserts", "Chocolate Cake", 75,
                "Rich and moist chocolate cake.",
                "https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Q2hvY29sYXRlJTIwY2FrZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Desserts", "Cheesecake", 85,
                "Creamy classic cheesecake.",
                "https://images.unsplash.com/photo-1524351199678-941a58a3df50?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Q2hlZXNlY2FrZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Desserts", "Brownie", 65,
                "Soft and fudgy chocolate brownie.",
                "https://images.unsplash.com/photo-1636743715220-d8f8dd900b87?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8QnJvd25pZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Desserts", "Red Velvet Cake", 80,
                "Soft red velvet cake with cream cheese.",
                "https://images.unsplash.com/photo-1586788680434-30d324b2d46f?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8cmVkJTIwdmVsdmV0JTIwY2FrZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Desserts", "Carrot Cake", 75,
                "Moist carrot cake with creamy frosting.",
                "https://media.istockphoto.com/id/487919471/photo/piece-of-carrot-cake.webp?a=1&b=1&s=612x612&w=0&k=20&c=-QmSzI0b5-QOBR3cdCEcxIy-oYGW6QAF6fNrPmv1bg8=");

            Add("Desserts", "Tiramisu", 85,
                "Classic Italian coffee-flavored dessert.",
                "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9");

            Add("Desserts", "Chocolate Mousse", 70,
                "Light and creamy chocolate mousse.",
                "https://media.istockphoto.com/id/1189235789/photo/chocolate-mousse-desserts-concept.webp?a=1&b=1&s=612x612&w=0&k=20&c=LfVrlg76WpxPfKZHUqBfqOHM8Db_XdOen4iQzb-SqGI=");

            Add("Desserts", "Apple Pie", 70,
                "Warm apple pie with cinnamon.",
                "https://plus.unsplash.com/premium_photo-1669557209263-94abeebafcdd?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fEFwcGxlJTIwUGllfGVufDB8fDB8fHww");

            Add("Desserts", "Lotus Cheesecake", 90,
                "Creamy cheesecake with Lotus biscuit.",
                "https://images.unsplash.com/photo-1708980108345-171931ad1fa8?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fExvdHVzJTIwQ2hlZXNlY2FrZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Desserts", "Molten Chocolate Cake", 90,
                "Warm chocolate cake with a soft center.",
                "https://images.unsplash.com/photo-1617305855058-336d24456869?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8TW9sdGVuJTIwQ2hvY29sYXRlJTIwQ2FrZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Bakery", "Croissant", 45,
                "Fresh buttery French croissant.",
                "https://images.unsplash.com/photo-1555507036-ab1f4038808a");

            Add("Bakery", "Chocolate Croissant", 55,
                "Buttery croissant filled with chocolate.",
                "https://images.unsplash.com/photo-1721324390033-661a350668d6?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Q2hvY29sYXRlJTIwQ3JvaXNzYW50fGVufDB8fDB8fHww");

            Add("Bakery", "Cheese Croissant", 55,
                "Fresh croissant filled with creamy cheese.",
                "https://images.unsplash.com/photo-1606758184328-faab9a86f4d3?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Q2hlZXNlJTIwQ3JvaXNzYW50fGVufDB8fDB8fHww");

            Add("Bakery", "Cinnamon Roll", 60,
                "Soft cinnamon roll topped with icing.",
                "https://images.unsplash.com/photo-1585190775852-3e6bb2b80184?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fENpbm5hbW9uJTIwUm9sbHxlbnwwfHwwfHx8MA%3D%3D");

            Add("Bakery", "Blueberry Muffin", 55,
                "Soft muffin packed with blueberries.",
                "https://images.unsplash.com/photo-1607958996333-41aef7caefaa");

            Add("Bakery", "Chocolate Muffin", 55,
                "Soft and rich chocolate muffin.",
                "https://images.unsplash.com/photo-1616631124190-fa90afc46fa7?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Q2hvY29sYXRlJTIwTXVmZmlufGVufDB8fDB8fHww");

            Add("Bakery", "Plain Donut", 40,
                "Fresh classic glazed donut.",
                "https://images.unsplash.com/photo-1693923169788-7bedd08be501?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fFBsYWluJTIwRG9udXR8ZW58MHx8MHx8fDA%3D");

            Add("Bakery", "Chocolate Donut", 45,
                "Soft donut covered with chocolate.",
                "https://images.unsplash.com/photo-1631143070457-c1aecc92abbc?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Q2hvY29sYXRlJTIwRG9udXR8ZW58MHx8MHx8fDA%3D");

            Add("Bakery", "Danish Pastry", 50,
                "Fresh buttery Danish pastry.",
                "https://images.unsplash.com/photo-1666114265205-394e9d5848c6?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RGFuaXNoJTIwUGFzdHJ5fGVufDB8fDB8fHww");

            Add("Bakery", "Apple Danish", 55,
                "Flaky Danish pastry filled with apple.",
                "https://images.unsplash.com/photo-1671759545288-2d7fa26d6b9e?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fERhbmlzaCUyMFBhc3RyeXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Breakfast", "Classic Omelette", 75,
                "Fresh eggs cooked with herbs.",
                "https://media.istockphoto.com/id/2267548508/photo/omelette-served-for-breakfast.webp?a=1&b=1&s=612x612&w=0&k=20&c=ATAd7o8vW5JduF2B_7RuJ9xhMC1glQRVFXWiaxbaDE8=");

            Add("Breakfast", "Cheese Omelette", 85,
                "Fluffy omelette with melted cheese.",
                "https://images.unsplash.com/photo-1668283653825-37b80f055b05?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fENoZWVzZSUyME9tZWxldHRlfGVufDB8fDB8fHww");

            Add("Breakfast", "Scrambled Eggs", 75,
                "Creamy scrambled eggs.",
                "https://images.unsplash.com/photo-1687630433653-e6c9faec95b3?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U2NyYW1ibGVkJTIwRWdnc3xlbnwwfHwwfHx8MA%3D%3D");

            Add("Breakfast", "Fried Eggs", 65,
                "Fresh fried eggs served warm.",
                "https://images.unsplash.com/photo-1694103198478-1f6d40027768?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8RnJpZWQlMjBFZ2dzfGVufDB8fDB8fHww");

            Add("Breakfast", "Egg & Cheese Toast", 80,
                "Toasted bread with egg and melted cheese.",
                "https://images.unsplash.com/photo-1525351484163-7529414344d8");

            Add("Breakfast", "Avocado Toast", 95,
                "Toasted bread topped with fresh avocado.",
                "https://images.unsplash.com/photo-1541519227354-08fa5d50c44d");

            Add("Breakfast", "Pancakes", 85,
                "Fluffy pancakes served with syrup.",
                "https://images.unsplash.com/photo-1528207776546-365bb710ee93");

            Add("Breakfast", "French Toast", 80,
                "Golden French toast with sweet syrup.",
                "https://images.unsplash.com/photo-1484723091739-30a097e8f929");

            Add("Breakfast", "Breakfast Croissant", 90,
                "Croissant filled with eggs and cheese.",
                "https://images.unsplash.com/photo-1555507036-ab1f4038808a");

            Add("Breakfast", "Full Breakfast Plate", 120,
                "Eggs, toast and delicious breakfast sides.",
                "https://images.unsplash.com/photo-1513442542250-854d436a73f2");

            Add("Sandwiches", "Chicken Sandwich", 95,
                "Grilled chicken with fresh vegetables.",
                "https://images.unsplash.com/photo-1603903631889-b5f3ba4d5b9b?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fENoaWNrZW4lMjBTYW5kd2ljaHxlbnwwfHwwfHx8MA%3D%3D");

            Add("Sandwiches", "Crispy Chicken Sandwich", 105,
                "Crispy chicken with fresh toppings.",
                "https://images.unsplash.com/photo-1705131186176-1c7cdb830815?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8Q3Jpc3B5JTIwQ2hpY2tlbiUyMFNhbmR3aWNofGVufDB8fDB8fHww");

            Add("Sandwiches", "Grilled Chicken Sandwich", 105,
                "Grilled chicken with cheese and vegetables.",
                "https://images.unsplash.com/photo-1715262346522-ef72f19f0170?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8R3JpbGxlZCUyMENoaWNrZW4lMjBTYW5kd2ljaHxlbnwwfHwwfHx8MA%3D%3D");

            Add("Sandwiches", "Turkey & Cheese Sandwich", 100,
                "Turkey slices with melted cheese.",
                "https://images.unsplash.com/photo-1553909489-cd47e0907980");

            Add("Sandwiches", "Club Sandwich", 120,
                "Classic layered chicken club sandwich.",
                "https://plus.unsplash.com/premium_photo-1738802845911-809a01acfa50?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8Q2x1YiUyMFNhbmR3aWNofGVufDB8fDB8fHww");

            Add("Sandwiches", "Tuna Sandwich", 95,
                "Tuna with fresh vegetables and sauce.",
                "https://media.istockphoto.com/id/174639800/photo/tuna-fish-salad-sandwich.webp?a=1&b=1&s=612x612&w=0&k=20&c=GKSubNY5FeKqrIBNU62Bl9u1zREOL5RwJlmO74OTBJY=");

            Add("Sandwiches", "Beef Sandwich", 115,
                "Tender beef with fresh toppings.",
                "https://images.unsplash.com/photo-1554433607-66b5efe9d304?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8QmVlZiUyMFNhbmR3aWNofGVufDB8fDB8fHww");

            Add("Sandwiches", "Chicken Caesar Wrap", 105,
                "Chicken, lettuce and Caesar dressing.",
                "https://images.unsplash.com/photo-1626700051175-6818013e1d4f");

            Add("Sandwiches", "Halloumi Sandwich", 90,
                "Grilled halloumi with fresh vegetables.",
                "https://images.unsplash.com/photo-1528735602780-2552fd46c7af");

            Add("Sandwiches", "Mozzarella & Tomato Sandwich", 85,
                "Fresh mozzarella, tomato and herbs.",
                "https://images.unsplash.com/photo-1539252554453-80ab65ce3586?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8TW96emFyZWxsYSUyMCUyNiUyMFRvbWF0byUyMFNhbmR3aWNofGVufDB8fDB8fHww");

            Add("Smoothies", "Strawberry Smoothie", 70,
                "Fresh strawberry blended smoothie.",
                "https://images.unsplash.com/photo-1647275485937-890ba327b0ae?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fFN0cmF3YmVycnklMjBTbW9vdGhpZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Smoothies", "Mango Smoothie", 75,
                "Sweet and creamy mango smoothie.",
                "https://media.istockphoto.com/id/964759112/photo/mango-in-a-glass-jar-mason-on-the-old-wooden-background.webp?a=1&b=1&s=612x612&w=0&k=20&c=vCJQ-h1AcDKdqGTE-m3C3kX5kzeIUQpx_3WM7RhX6lw=");

            Add("Smoothies", "Banana Smoothie", 65,
                "Creamy banana smoothie.",
                "https://images.unsplash.com/photo-1685967836529-b0e8d6938227?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8QmFuYW5hJTIwU21vb3RoaWV8ZW58MHx8MHx8fDA%3D");

            Add("Smoothies", "Mixed Berry Smoothie", 80,
                "Fresh blend of mixed berries.",
                "https://images.unsplash.com/photo-1600718374662-0483d2b9da44?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8TWl4ZWQlMjBCZXJyeSUyMFNtb290aGllfGVufDB8fDB8fHww");

            Add("Smoothies", "Peach Smoothie", 70,
                "Refreshing fresh peach smoothie.",
                "https://plus.unsplash.com/premium_photo-1663091544172-794c537af00c?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8UGVhY2glMjBTbW9vdGhpZXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Smoothies", "Pineapple Smoothie", 75,
                "Tropical pineapple smoothie.",
                "https://images.unsplash.com/photo-1666181767084-91e0cd358adf?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8UGluZWFwcGxlJTIwU21vb3RoaWV8ZW58MHx8MHx8fDA%3D");

            Add("Smoothies", "Kiwi Smoothie", 75,
                "Fresh and refreshing kiwi smoothie.",
                "https://images.unsplash.com/photo-1610970881699-44a5587cabec?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8S2l3aSUyMFNtb290aGllfGVufDB8fDB8fHww");

            Add("Smoothies", "Strawberry Banana Smoothie", 75,
                "Delicious strawberry and banana blend.",
                "https://images.unsplash.com/photo-1589733955941-5eeaf752f6dd?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U3RyYXdiZXJyeSUyMEJhbmFuYSUyMFNtb290aGllfGVufDB8fDB8fHww");

            Add("Smoothies", "Mango Banana Smoothie", 75,
                "Creamy mango and banana blend.",
                "https://images.unsplash.com/photo-1623065422902-30a2d299bbe4?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8TWFuZ28lMjBCYW5hbmElMjBTbW9vdGhpZXxlbnwwfHwwfHx8MA%3D%3D");

            

            Add("Fresh Juices", "Fresh Orange Juice", 55,
                "Freshly squeezed orange juice.",
                "https://images.unsplash.com/photo-1600271886742-f049cd451bba");

            Add("Fresh Juices", "Fresh Lemon Juice", 50,
                "Refreshing freshly squeezed lemon juice.",
                "https://images.unsplash.com/photo-1507281549113-040fcfef650e?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8RnJlc2glMjBMZW1vbiUyMEp1aWNlfGVufDB8fDB8fHww");

            Add("Fresh Juices", "Fresh Mango Juice", 65,
                "Sweet and fresh mango juice.",
                "https://images.unsplash.com/photo-1546173159-315724a31696");

            Add("Fresh Juices", "Fresh Strawberry Juice", 65,
                "Fresh strawberry juice.",
                "https://images.unsplash.com/photo-1683531658992-b78c311900a3?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJlc2glMjBTdHJhd2JlcnJ5JTIwSnVpY2V8ZW58MHx8MHx8fDA%3D");

           
            Add("Fresh Juices", "Fresh Watermelon Juice", 55,
                "Refreshing watermelon juice.",
                "https://images.unsplash.com/photo-1567587407679-8187b3b972aa?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8RnJlc2glMjBXYXRlcm1lbG9uJTIwSnVpY2V8ZW58MHx8MHx8fDA%3D");

            Add("Fresh Juices", "Fresh Pineapple Juice", 65,
                "Fresh tropical pineapple juice.",
                "https://images.unsplash.com/photo-1666181898487-c57bf1da263f?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fEZyZXNoJTIwUGluZWFwcGxlJTIwSnVpY2V8ZW58MHx8MHx8fDA%3D");

            Add("Fresh Juices", "Fresh Kiwi Juice", 70,
                "Fresh kiwi juice.",
                "https://images.unsplash.com/photo-1676159434917-1713d35650d5?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fEZyZXNoJTIwS2l3aSUyMEp1aWNlfGVufDB8fDB8fHww");

            Add("Fresh Juices", "Fresh Pomegranate Juice", 75,
                "Fresh pomegranate juice.",
                "https://images.unsplash.com/photo-1665834263149-b57fc4de3fa8?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8RnJlc2glMjBQb21lZ3JhbmF0ZSUyMEp1aWNlfGVufDB8fDB8fHww");

            Add("Fresh Juices", "Fresh Mixed Fruit Juice", 80,
                "A refreshing blend of fresh fruits.",
                "https://plus.unsplash.com/premium_photo-1663089587926-ff5a03d17b48?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8RnJlc2glMjBNaXhlZCUyMEZydWl0JTIwSnVpY2V8ZW58MHx8MHx8fDA%3D");

            Add("Ice Cream", "Vanilla Ice Cream", 50,
                "Classic creamy vanilla ice cream.",
                "https://images.unsplash.com/photo-1560008581-09826d1de69e?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8VmFuaWxsYSUyMEljZSUyMENyZWFtfGVufDB8fDB8fHww");

            Add("Ice Cream", "Chocolate Ice Cream", 50,
                "Rich chocolate ice cream.",
                "https://media.istockphoto.com/id/936205852/photo/chocolate-ice-cream-in-a-glass-cup.webp?a=1&b=1&s=612x612&w=0&k=20&c=dBcITkysUfePEUgFB3mKN75KHAlCOvMoZBi3WDtb6w4=");

            Add("Ice Cream", "Strawberry Ice Cream", 50,
                "Creamy strawberry ice cream.",
                "https://images.unsplash.com/photo-1633933358116-a27b902fad35?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U3RyYXdiZXJyeSUyMEljZSUyMENyZWFtfGVufDB8fDB8fHww");

            Add("Ice Cream", "Mango Ice Cream", 55,
                "Refreshing mango ice cream.",
                "https://media.istockphoto.com/id/1456234806/photo/mango-ice-cream-served-in-cup-isolated-on-grey-background-top-view-of-indian-and-bangladesh.webp?a=1&b=1&s=612x612&w=0&k=20&c=-AMw3wM-DpIdEPuS58ZqV4BAd-VKTmN6tFUtmo1degg=");

            Add("Ice Cream", "Caramel Ice Cream", 55,
                "Creamy caramel ice cream.",
                "https://media.istockphoto.com/id/1310619464/photo/bowl-of-caramelized-walnut-and-maple-syrup-ice-cream.webp?a=1&b=1&s=612x612&w=0&k=20&c=Cg_-FG421u5o7Zz2xyWmJh6Qh4sMOu-vgohC8uXt8_8=");

            Add("Ice Cream", "Cookies & Cream", 60,
                "Vanilla ice cream with cookie pieces.",
                "https://plus.unsplash.com/premium_photo-1695865412596-600e9faa4f11?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjV8fENvb2tpZXMlMjAlMjYlMjBDcmVhbSUyMEljZSUyMENyZWFtfGVufDB8fDB8fHww");

            Add("Ice Cream", "Pistachio Ice Cream", 65,
                "Creamy pistachio flavored ice cream.",
                "https://images.unsplash.com/photo-1603736029103-dafad0eb0906?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8UGlzdGFjaGlvJTIwSWNlJTIwQ3JlYW18ZW58MHx8MHx8fDA%3D");

            Add("Ice Cream", "Salted Caramel", 60,
                "Sweet and creamy salted caramel ice cream.",
                "https://images.unsplash.com/photo-1701144684031-ece666fe1f8d?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fFNhbHRlZCUyMENhcmFtZWwlMjBJY2UlMjBDcmVhbXxlbnwwfHwwfHx8MA%3D%3D");

            Add("Ice Cream", "Chocolate Hazelnut", 65,
                "Chocolate ice cream with hazelnut flavor.",
                "https://images.unsplash.com/photo-1563805042-7684c019e1cb");

            Add("Ice Cream", "Mixed Ice Cream Cup", 75,
                "A delicious mix of ice cream flavors.",
                "https://images.unsplash.com/photo-1564919126030-8dbf63751ec2?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8TWl4ZWQlMjBJY2UlMjBDcmVhbSUyMEN1cHxlbnwwfHwwfHx8MA%3D%3D");


            Add("Snacks", "French Fries", 55,
                "Crispy golden French fries.",
                "https://images.unsplash.com/photo-1573080496219-bb080dd4f877");

            Add("Snacks", "Sweet Potato Fries", 65,
                "Crispy sweet potato fries.",
                "https://media.istockphoto.com/id/1350023989/photo/sweet-potato-fries-with-sauces.webp?a=1&b=1&s=612x612&w=0&k=20&c=857CBjTmt9vsCnJHfweFvcSBbmcK62uR4q53KJFcPOc=");

            Add("Snacks", "Mozzarella Sticks", 75,
                "Crispy mozzarella cheese sticks.",
                "https://images.unsplash.com/photo-1548340748-6d2b7d7da280");

            Add("Snacks", "Chicken Nuggets", 80,
                "Crispy golden chicken nuggets.",
                "https://images.unsplash.com/photo-1562967916-eb82221dfb92");

            Add("Snacks", "Onion Rings", 60,
                "Crispy golden onion rings.",
                "https://images.unsplash.com/photo-1639024471283-03518883512d");

            Add("Snacks", "Nachos", 70,
                "Crispy nachos topped with cheese.",
                "https://images.unsplash.com/photo-1513456852971-30c0b8199d4d");

            Add("Snacks", "Popcorn", 40,
                "Freshly prepared crispy popcorn.",
                "https://images.unsplash.com/photo-1691480213129-106b2c7d1ee8?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8UG9wY29ybnxlbnwwfHwwfHx8MA%3D%3D");

            Add("Snacks", "Potato Wedges", 60,
                "Seasoned crispy potato wedges.",
                "https://images.unsplash.com/photo-1623238913973-21e45cced554?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8UG90YXRvJTIwV2VkZ2VzfGVufDB8fDB8fHww");

            Add("Snacks", "Cheese Bites", 70,
                "Crispy bites filled with melted cheese.",
                "https://images.unsplash.com/photo-1734774924912-dcbb467f8599?w=1200&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Q2hlZXNlJTIwQml0ZXN8ZW58MHx8MHx8fDA%3D");

            Add("Snacks", "Mixed Snack Plate", 95,
                "A delicious selection of cafe snacks.",
                "https://plus.unsplash.com/premium_photo-1783612929241-c367c94a0e1e?q=80&w=2344&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");


            await context.MenuItems.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }
    }
}

