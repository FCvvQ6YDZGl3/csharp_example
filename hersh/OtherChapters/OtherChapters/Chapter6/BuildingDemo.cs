using System;
using Project1.Chapter6;
class BuildingDemo
{
    public void run()
    {
        Building house = new Building();
        Building office = new Building();

        house.Occupants = 4;
        house.Area = 2500;
        house.Floors = 2;
        house.type = "дом";

        office.Occupants = 25;
        office.Area = 4200;
        office.Floors = 3;
        office.type = "учреждение";

        description(house);
        Console.WriteLine();
        description(office);

        Console.ReadKey();
    }

    private static void description(Building building)
    {
        String building_type = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(building.type);
        Console.WriteLine(building_type + " имеет:\n " +
            building.Floors + " этажа\n " +
            building.Occupants + " работников\n " +
            building.Area +
            " кв. футов общей площади, из них\n " +
            building.AreaPerPerson() + " приходится на одного человека");
    }
}