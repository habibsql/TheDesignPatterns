using System.Diagnostics;

namespace TheDesignPatterns.Factory.AbstractFactory
{
    public interface IChair
    {
        void SitOn();
    }

    public class ComputerChair : IChair
    {
        public void SitOn()
        {
            Debug.WriteLine("Dyning Chair");
        }
    }

    public class SofaChair : IChair
    {
        public void SitOn()
        {
            Debug.WriteLine("Sofa Chair");
        }
    }

    public interface ITable
    {
        bool HasDrawar();
    }

    public class ComputerTable : ITable
    {
        public bool HasDrawar()
        {
            return true;
        }
    }

    public class DyningTable : ITable
    {
        public bool HasDrawar()
        {
            return false;
        }
    }

    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }

    public class HomeFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            IChair sofaChair = new SofaChair();

            return sofaChair;
        }

        public ITable CreateTable()
        {
            ITable dyningTable = new DyningTable();

            return dyningTable;
        }
    }

    public class OfficeFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            IChair computerChair = new ComputerChair();

            return computerChair;
        }

        public ITable CreateTable()
        {
            ITable computerTable = new ComputerTable();

            return computerTable;
        }
    }

}
