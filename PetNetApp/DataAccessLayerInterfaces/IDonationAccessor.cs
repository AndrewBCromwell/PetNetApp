using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces
{
    /// <summary>
    /// Author: Gwen Arman
    /// Date: 2023/03/02
    /// Description: Selects all of the donations by ShelterId
    /// </summary>
    /// <param name="ShelterId"></param>
    /// <returns></returns>
    public interface IDonationAccessor
    {
        List<DonationVM> SelectDonationsByShelterId(int ShelterId);
    }
}
