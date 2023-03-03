using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IDonationManager
    {
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023/03/02
        /// Description: Retrieves donations by ShelterId
        /// </summary>
        /// <param name="ShelterId"></param>
        /// <returns></returns>
        List<DonationVM> RetrieveDonationsByShelterId(int ShelterId);
    }
}
