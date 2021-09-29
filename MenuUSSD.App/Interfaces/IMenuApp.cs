using MenuUssd.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuUSSD.App.Interfaces
{
    public interface IMenuApp
    {
        string Main(UssdModel model);
    }
}
