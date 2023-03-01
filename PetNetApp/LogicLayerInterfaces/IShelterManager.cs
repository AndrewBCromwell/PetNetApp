﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Brian Collum
    /// Created: 2023/02/23
    /// IShelterManager interface governing access to the ShelterManager class in LogicLayer
    /// </summary>
    public interface IShelterManager
    {
        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// This returns the list of all Shelters to populate the shelter UI with
        /// </summary>
        /// <returns>A list of Shelter objects</returns>
        List<Shelter> GetShelterList();

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Adds a new shelter to the database
        /// </summary>
        /// <param name="shelterName">The name of the shelter</param>
        /// <param name="address">the address of the shelter</param>
        /// <param name="addressTwo">the extended address information of the shelter</param>
        /// <param name="zipCode">the zipcode of the shelter</param>
        /// <param name="phone">the phone number of the shelter</param>
        /// <param name="email">the email address of the shelter</param>
        /// <param name="areasOfNeed">the areas of need of the shelter</param>
        /// <param name="shelterActive">Whether the shelter is active or not</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool AddShelter(
            string shelterName
            , string address
            , string addressTwo
            , string zipCode
            , string phone
            , string email
            , string areasOfNeed
            , bool shelterActive);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the name of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newShelterName">The new name of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditShelterName(Shelter shelter, string newShelterName);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the address of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newAddress">The new address of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditAddress(Shelter shelter, string newAddress);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the addressTwo of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newAddressTwo">The new addressTwo of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditAddressTwo(Shelter shelter, string newAddressTwo);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the zipcode of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newZipcode">The new zipcode of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditZipCode(Shelter shelter, string newZipcode);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the phone number of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newPhone">The new phone number of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditPhone(Shelter shelter, string newPhone);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the email address of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newEmail">The new email address of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditEmail(Shelter shelter, string newEmail);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the areas of need of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newAreasOfNeed">The new areas of need of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditAreasOfNeed(Shelter shelter, string newAreasOfNeed);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Updates the active status of a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <param name="newActiveStatus">The new active status of the shelter</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool EditActiveStatus(Shelter shelter, bool newActiveStatus);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Retrieves a shelterVM object by looking up its shelter ID
        /// </summary>
        /// <param name="shelterID">The shelter ID of the shelter to retrieve</param>
        /// <returns>Returns a ShelterVM object</returns>
        ShelterVM RetrieveShelterVMByShelterID(int shelterID);

        /// <summary>
        /// Brian Collum
        /// Created: 2023/02/23
        /// Deactivates a shelter
        /// </summary>
        /// <param name="shelter">The shelter object to update</param>
        /// <returns>Boolean containing whether the operation succeeded or failed</returns>
        bool DeactivateShelter(Shelter shelter);

        // bool HoursOfOperationByShelterID(int shelterID);
    }
}
