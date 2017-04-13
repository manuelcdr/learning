using System;

namespace DesignPatternsStuding
{
    public interface IInvestidor
    {
        double Calcula(double valor);
    }

    public class Conservador : IInvestidor
    {
        public double Calcula(double valor)
        {
            return valor * 0.0008;
        }
    }

    public class Moderado : IInvestidor
    {
        public double Calcula(double valor)
        {
            int chance = new Random().Next(1, 2);
            if (chance == 1)
            {
                return valor * 0.025;
            }
            else
            {
                return valor * 0.0007;
            }
        }
    }

    public class Arrojado : IInvestidor
    {
        public double Calcula(double valor)
        {
            int chance = new Random().Next(100);
            if (chance <= 20)
            {
                return valor * 0.05;
            }
            else if (chance > 20 && chance <= 50)
            {
                return valor * 0.03;
            }
            else
            {
                return valor * 0.0006;
            }
        }
    }
}