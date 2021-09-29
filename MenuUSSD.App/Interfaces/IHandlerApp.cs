using System;
namespace MenuUssd.App.Interfaces
{
    public interface IHandlerApp
    {
        int[] Request(string arg);
        int[] Back(string arg);
    }
}
