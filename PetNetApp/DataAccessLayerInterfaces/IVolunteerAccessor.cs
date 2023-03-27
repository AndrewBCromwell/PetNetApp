/// <summary>
/// Oleksiy Fedchuk
/// Created: 2023/02/24
/// 
/// 
/// Interface for VolunteerAccessor
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

namespace DataAccessLayerInterfaces
{
	public interface IVolunteerAccessor
	{
		/// <summary>
		/// Oleksiy Fedchuk
		/// Created: 2023/02/24
		/// 
		/// Selects Volunteers by fundrasing event Id
		/// </summary>
		///
		/// <remarks>
		/// Updater Name
		/// Updated: yyyy/mm/dd 
		/// example: Fixed a problem when user inputs bad data
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		List<VolunteerVM> SelectVolunteersbyFundraisingEventId(int fundraisingEventId);
	}
}
