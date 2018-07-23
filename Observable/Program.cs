using System;
using System.Collections.Generic;

namespace Observable
{
  interface IObservable
  {
    void Add(IObserver o);
    void Notify();
  }

  interface IObserver
  {
    void Update();
  }

  class WeatherStation : IObservable
  {
    private List<IObserver> _displays = new List<IObserver>();
    private double _temp;

    public void Add(IObserver o)
    {
      this._displays.Add(o);
    }
    public void Notify()
    {
      foreach (var display in _displays)
      {
        display.Update();
      }
    }
    public double getTemp()
    {
      return this._temp;
    }

    public void setTemp(double temp)
    {
      this._temp = temp;
      Notify();
    }
  }

  class ConsoleDisplay : IObserver
  {
    private WeatherStation _station;

    public ConsoleDisplay(WeatherStation station)
    {
      this._station = station;
    }

    public void Update()
    {
      System.Console.WriteLine(this._station.getTemp());
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      var weatherStation = new WeatherStation();
      weatherStation.Add(new ConsoleDisplay(weatherStation));
      weatherStation.setTemp(68);
      weatherStation.setTemp(84);
    }
  }
}
