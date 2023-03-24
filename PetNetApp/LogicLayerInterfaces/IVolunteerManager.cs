/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/24
/// 
/// 
/// Interface for VolunteerManager
/// </summary>
/// 
/// <remarks>
/// Updater Name
/// Updated: yyyy/mm/dd
/// </remarks>
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
	public interface IVolunteerManager
	{
		/// <summary>
		/// Oleksiy Fedchuk
		/// Created: 2023/02/24
		/// 
		/// Retrieves Volunteers by fundrasing event Id
		/// </summary>
		///
		/// <param name="sender"></param>
		/// <param name="e"></param>
		List<VolunteerVM> RetrieveVolunteersbyFundraisingEventId(int fundraisingEventId);
	}
}
