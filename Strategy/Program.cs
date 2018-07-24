using System;

namespace Strategy
{
  interface IDisplay
  {
    void Display();
  }

  interface IQuack
  {
    void Quack();
  }

  class RubberDisplay : IDisplay
  {
    public void Display()
    {
      System.Console.WriteLine("rubber duck display");
    }
  }

  class WildDisplay : IDisplay
  {
    public void Display()
    {
      System.Console.WriteLine("wild duck display");
    }
  }

  class SilentQuack : IQuack
  {
    public void Quack()
    {
      System.Console.WriteLine("silent quack");
    }
  }

  class LoudQuack : IQuack
  {
    public void Quack()
    {
      System.Console.WriteLine("loud quack");
    }
  }
  
  class Duck
  {
    private IDisplay _display;
    private IQuack _quack;
    public Duck(IDisplay display, IQuack quack)
    {
      _display = display;
      _quack = quack;
    }

    public void ShowDuckType()
    {
      _display.Display();
      _quack.Quack();
    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      var rubberDuck = new Duck(new RubberDisplay(), new SilentQuack());
      var wildDuck = new Duck(new WildDisplay(), new LoudQuack());
      rubberDuck.ShowDuckType();
      wildDuck.ShowDuckType();
    }
  }
}
