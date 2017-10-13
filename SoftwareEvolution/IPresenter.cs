using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEvolution
{
    public interface IPresenter
    {
        String GetHeader(string name);

        String GetItemString(Item each, double discount, double bonus, double thisAmount);

        String GetFooter(double totalAmount, double totalBonus);
   
    }
}
