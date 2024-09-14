using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Item
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Item (string name, int points)
    {
        Name = name;
        Points = points;
    }
}

public class Gauge
{
    public int CurrentValue { get; private set; }
    public int MaxValue { get; private set; }

    public Gauge(int maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = 0;
    }

    public void AddPoints(int points)
    {
        CurrentValue += points;
        if (CurrentValue > MaxValue)
        {
            CurrentValue = MaxValue;
        }
    }

    public bool IsFull()
    {
        return CurrentValue >= MaxValue;
    }
}

public class Game
{
    public Gauge SpecialGauge { get; private set; }
    public bool IsFever { get; private set; }
    public Game(int gaugeMaxValue )
    {
        SpecialGauge = new Gauge(gaugeMaxValue);
        IsFever = false;
        
    }

    public async void GetItem(Item item)
    {
        SpecialGauge.AddPoints(item.Points);
        Console.WriteLine($"Got {item.Name}! Gauge is now {SpecialGauge.CurrentValue}/{SpecialGauge.MaxValue}");
        if (SpecialGauge.IsFull() && !IsFever)
        {
           await StartFever();
        }
    }

    private async Task StartFever()
    {
        IsFever = true;
        Console.WriteLine("Fever started! Enjoy the next 15 seconds!");
        
        await Task.Delay(15000); // 15秒間待機
        IsFever = false;
        SpecialGauge = new Gauge(SpecialGauge.MaxValue); // ゲージをリセット
        
        Console.WriteLine("Fever ended. Gauge reset.");
    }
}



class Program
{
    static void Main(string[] args)
    {
        Game game = new Game (100);
        // ゲージの最大値を100に設定し、BGMのパスを指定); // ゲージの最大値を100に設定

        Item item1 = new Item("虹豆", 20);
        

        game.GetItem(item1); // 虹豆をゲット
        
    }
}

public class NewBehaviourScript : MonoBehaviour
{
    
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
