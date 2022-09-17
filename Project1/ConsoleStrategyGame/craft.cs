using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

class Match
{
    delegate bool GameOver();
    GameOver gameOver;
    private uint matchDuration = 0;
    private string answerPlayer;
    private Timer timer;
    public Location[] locations;
    public Player player;
    public void run()
    {
        setTimer();
        createLocations();
        createPlayers();
        DefineTerminationСonditions();

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
                case "build farm":
                    player.buildFarm();
                    break;
                case "build sawmill":
                    player.buildSawmill();
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
    private void notifyWhenTheGameStarts()
    {
        Console.WriteLine("Начало игры");
    }
    private void notifyWhenTheGameIsOver()
    {
        Console.WriteLine("Конец игры");
    }
    private void OnTimedEvent(Object Source, System.Timers.ElapsedEventArgs e)
    {
        matchDuration++;
        if (CheckGameEnd())
        {
            timer.Stop();
            notifyWhenTheGameIsOver();
            
        }
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
    private void DefineTerminationСonditions()
    {
        gameOver = () => player.food.value > 200;
    }
    private bool CheckGameEnd()
    {
        return gameOver();
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
    public void buildFarm()
    {
        if ((locations.Where(location => location.GetType() == "Field" && location.free)).Count() > 0)
            this.build(new Farm(), (locations.Where(location => location.GetType() == "Field" && location.free)).FirstOrDefault());
        else
            Console.WriteLine("Нельзя построить больше ферм!");
    }
    public void buildSawmill()
    {
        if ((locations.Where(location => location.GetType() == "Forest" && location.free)).Count() > 0)
            this.build(new Sawmill(), (locations.Where(location => location.GetType() == "Forest" && location.free)).FirstOrDefault());
        else
            Console.WriteLine("Нельзя построить больше лесопилок!");
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
        p.wood.increase = +wood;
    }
}

abstract class Resource
{
    public int value;
    public int increase;
    public Resource(int v = 0)
    {
        value = v;
        increase = 0;
    }
}
class Food : Resource
{
    public Food() : base()
    {
    }
}
class Wood : Resource
{
    public Wood() : base(120)
    { 
    }
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