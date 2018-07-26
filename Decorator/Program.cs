using System;

namespace Decorator
{
  abstract class Beverage
  {
    public abstract int Cost();
  }

  class Decaf : Beverage
  {
    private int _cost = 2;
    override public int Cost()
    {
      return _cost;
    }
  }

  class Espresso : Beverage
  {
    private int _cost = 1;
    override public int Cost()
    {
      return _cost;
    }
  }

  abstract class AddonDecorator : Beverage
  {
    public Beverage Bev { get; set; }
    public AddonDecorator(Beverage bev)
    {
      Bev = bev;
    }
  }

  class Caramel : AddonDecorator
  {
    public Caramel(Beverage bev)
          : base(bev) { }
    private int _cost = 1;
    override public int Cost()
    {
      return this.Bev.Cost() + _cost;
    }
  }

  class Soy : AddonDecorator
  {
    public Soy(Beverage bev)
                : base(bev) { }

    private int _cost = 1;

    override public int Cost()
    {
      return this.Bev.Cost() + _cost;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var espresso = new Espresso();
      var espressoSoy = new Soy(espresso);
      System.Console.WriteLine("The cost of a esspresso with soy is {0} dollars", espressoSoy.Cost());
      var decaf = new Decaf();
      var decafCaramel = new Caramel(decaf);
      System.Console.WriteLine("The cost of a decaf with caramel is {0} dollars", decafCaramel.Cost());
    }
  }
}
