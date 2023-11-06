
using System.Data;
using Humanizer;

class Solution
{
    //In DataFormats -> Dish
    
    public static IQueryable<Dish> Q1(ExamContext db, string name, decimal minPrice, decimal maxPrice)
    {
        //List down all FoodItems containing the given name within the minimum and maximum prices given

        return db.FoodItems
        .Where(fi => fi.Name.Contains(name) 
                        && (decimal) fi.Price >= (decimal) minPrice 
                        && (decimal) fi.Price <= (decimal) maxPrice)
        .Select(fi => new Dish(fi.Name, fi.Price, fi.Unit));   
    }
 
    //In DataFormats -> DishAndCategory

    public static IQueryable<DishAndCategory> Q2(ExamContext db, int customerId)
    {
        //List down all FoodItems including the Category ordered by a Customer (CustomerID given as parameter)
        // var ret = (from fi in db.FoodItems
        //             join od in db.Orders on customerId equals od.CustomerID
        //             join cat in db.Categories on fi.CategoryID equals cat.ID
        //             where od.CustomerID == customerId
        //             select new{
        //                 Name = fi.Name,
        //                 Price = fi.Price,
        //                 Category = cat.Name,
        //                 Unit = fi.Unit
        //             }).Select(res => new DishAndCategory(res.Name, res.Price, res.Unit, res.Category));

        var ret = (
            from cs in db.Customers
            join od in db.Orders on cs.ID equals od.CustomerID
            join fi in db.FoodItems on od.FoodItemID equals fi.ID
            join cat in db.Categories on fi.CategoryID equals cat.ID
            where cs.ID == customerId
                    select new{
                        Name = fi.Name,
                        Price = fi.Price,
                        Category = cat.Name,
                        Unit = fi.Unit
                    }).Select(res => new DishAndCategory(res.Name, res.Price, res.Unit, res.Category));
        
    
        return ret;
    
        return default(IQueryable<DishAndCategory>);  //change this line (it is now only used to avoid compiler error)  
    }

    //In DataFormats -> CustomerBill (BillItem)
    public static IQueryable<CustomerBill> Q3(ExamContext db, int number)
    {
        //List down the bills: FoodItems, Order Quantity, Unit Price, Total,
        //for the first "number" of Customers (ordered based on Total). 
        //Return an Iqueryable<CustomerBill> which will let fetch exactly the "number" of bills
        // return (from od in db.Orders
        //         join fi in db.FoodItems on od.FoodItemID equals fi.ID
        //         select new {
        //             Name = fi.Name,
        //             Price = fi.Price,
        //             Unit = fi.Unit,
        //             Quantity = od.Quantity
        //         })
        //         .Select(res => new BillItem(res.Name, res.Price, res.Unit, res.Quantity))

        return default(IQueryable<CustomerBill>); //change this line (it is now only used to avoid compiler error)  
    }

    public static IQueryable<Dish> Q4(ExamContext db, int tableNumber)
    {
        // List down dishes >>>NOT<<< sold at a given table
        // Ordering according to the dish price.
        return (
            from fi in db.FoodItems
            join od in db.Orders on fi.ID equals od.FoodItemID
            join cs in db.Customers on od.CustomerID equals cs.ID
            where cs.TableNumber != tableNumber
            group fi by fi.ID
        ).Select(fi => new Dish(fi.First().Name, fi.First().Price, fi.First().Unit));

        return default(IQueryable<Dish>);  //change this line (it is now only used to avoid compiler error)  
    }
  
    //In DataFormats -> record DishWithCategories

    public static IQueryable<DishWithCategories> Q5(ExamContext db)
    {
        /*
        Produce a categorised list contanining Dishes (FoodItems projected into Dishes) belonging to each sub category, 
        HINT: A sub category is the one whose [Main] CategoryID is not null.
        HINT: find first those (sub) categories and the corresponding MainCategory (CategoryID attribute).
        Including (Sub) Category and MainCategory (DishWithCategories objects). Self Join
        HINT: Don't forget to add a category even if there is no food item for the given category. Outer Join
        */

        return default(IQueryable<DishWithCategories>);  //change this line (it is now only used to avoid compiler error)        
   
    }
    
    public static int Q6(ExamContext db, string firstCategory, string secondCategory) {
        
        //This method returns the number of records changed in the DB after these operations have been applied:
        //Create TWO customers and add them.
        //The Name of the customer, ID, TableNumber, and Datetime are 
        //almost (ID has to be unique) fully optional.
        //Each of the two customers will place TWO orders (per customer) for fooditems belonging to the two categories.
        //So customer one -> order1{customer1, firstCategory product1}; order2{customer1, secondCategory product2}
        //   customer two -> order3{customer2, firstCategory product3}; order4{customer2, secondCategory product4}
        //One or both given categories might NOT exist, in this case make sure an order is not placed, 
        //the two customers should be added anyways. 

        return default(int); //change this line (it is now only used to avoid compiler error)  
    }
}