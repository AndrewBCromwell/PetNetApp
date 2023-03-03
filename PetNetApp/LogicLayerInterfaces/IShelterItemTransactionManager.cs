/// <summary>
/// Your Name
/// Created: 2023/03/01
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IShelterItemTransactionManager
    {
		/// <summary>
		/// Your Name
		/// Created: 2023/03/01
		/// 
		/// Retrieves a list of ShelterItemTransactionVM for the specified shelter
		/// </summary>
		/// <param name="shelterId">The id of the shelter to get records for. Should be the shelter the loged in user works at</param>
		/// <exception cref="ApplicationException">Selection failed</exception>
		/// <returns>ShelterItemTransactionVMs for the specified shelter</returns>
		List<ShelterItemTransactionVM> RetrieveInventoryTransactionByShelterId(int shelterId);
    }
}
