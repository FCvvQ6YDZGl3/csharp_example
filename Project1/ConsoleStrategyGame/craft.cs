using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

class Match
{
    private string answerPlayer;
    private Timer timer;
    public Location[] locations;
    public Player player;
    public void run()
    {
        setTimer();
        createLocations();
        createPlayers();

        notifyWhenTheGameStarts();
        viewFreeLocation();

        waitForTheCommand();
    }
    public void waitForTheCommand()
    {
        while (answerPlayer != "exit")
        {
            answerPlayer = Console.ReadLine();
            switch (answerPlayer)
            {
                case "build farm" :
                    if ((locations.Where(location => location.GetType() == "Field" && location.free)).Count() > 0)
                        player.build(new Farm(), (locations.Where(location => location.GetType() == "Field" && location.free)).FirstOrDefault());
                    else
                        Console.WriteLine("Нельзя построить больше ферм!");
                    break;
                case "view free location":
                    viewFreeLocation();
                    break;
                case "show res":
                    showResource();
                    break;
            }
        }
    }
    public void showResource()
    {
        Console.WriteLine("Food {0}   Wood {1}", player.food.value, player.wood.value);
    }
    public void notifyWhenTheGameStarts()
    {
        Console.WriteLine("Начало игры");
    }
    private void OnTimedEvent(Object Source, System.Timers.ElapsedEventArgs e)
    {
        player.getRes();
    }
    private void setTimer()
    {
        timer = new System.Timers.Timer();
        timer.Interval = 1000;
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private void createLocations()
    {
        locations = new Location[] { new Field(), new Field(), new Field(), new Forest(), new Forest(), new Forest() };
    }
    private void createPlayers()
    {
        player = new Player(locations);
    }
    public void viewFreeLocation()
    {
        int forest = 0;
        int field = 0;
        foreach (Location l in locations)
        {
            if (l.building == null)
            {
                switch (l.GetType())
                {
                    case "Forest": forest++; break;
                    case "Field": field++; break;
                }
            }
        }
        Console.WriteLine("Всего локаций свободно {0}, Лес {1}, Поля {2}", Location.countFree, forest, field);
    }
}
class Location
{
    public static int countFree;
    public bool free;
    public Building building;
    new public string GetType()
    {
        return base.GetType().Name;
    }
    public Location()
    {
        countFree++;
        free = true;
    }
}
class Field : Location
{
}
class Forest : Location
{
}
class Player
{
    public Location[] locations;
    public Building[] buildings;
    private int buildingCount;
    public Food food;
    public Wood wood;
    public Player(Location[] l)
    {
        locations = l;
        buildings = new Building[locations.Length];
        food = new Food();
        wood = new Wood();
        buildingCount = 0;
    }
    public void build(Structure structure, Location location)
    {
        location.building = new Building(this, structure);
        buildings[buildingCount] = location.building;
        buildingCount++;
        location.free = false;
    }
    public void getRes()
    {
        food.value +=food.increase;
        wood.value +=wood.increase;
    }
}
abstract class Structure
{
    public abstract void increaseResourceExtraction(Player p);
}
class Farm : Structure
{
    public const int food = 20;
    public override void increaseResourceExtraction(Player p)
    {
        p.food.increase += food;
    }

}
class Sawmill : Structure
{
    public const int wood = 10;
    public override void increaseResourceExtraction(Player p)
    {
        p.food.increase = +wood;
    }
}

abstract class Resource
{
    public int value;
    public int increase;
    public Resource()
    {
        value = 0;
        increase = 0;
    }
}
class Food : Resource
{
}
class Wood : Resource
{
}

class Building
{
    private Player player;
    private Structure structure;

    public Building(Player p, Structure s)
    {
        player = p;
        structure = s;
        s.increaseResourceExtraction(p);
        Location.countFree--;
    }
}