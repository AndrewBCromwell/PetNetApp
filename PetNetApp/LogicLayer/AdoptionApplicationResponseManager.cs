// Created by Asa Armstrong
// Created on 2023/03/23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;
using DataObjects;
using DataAccessLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    public class AdoptionApplicationResponseManager : IAdoptionApplicationResponseManager
    {
        private IAdoptionApplicationResponseAccessor _adoptionApplicationResponseAccessor = null;

        public AdoptionApplicationResponseManager()
        {
            _adoptionApplicationResponseAccessor = new AdoptionApplicationResponseAccessor();
        }

        public AdoptionApplicationResponseManager(IAdoptionApplicationResponseAccessor adoptionApplicationResponseAccessor)
        {
            _adoptionApplicationResponseAccessor = adoptionApplicationResponseAccessor;
        }

        public bool AddAdoptionApplicationResponse(AdoptionApplicationResponse adoptionApplicationResponse)
        {
            bool wasAdded = false;

            try
            {
                wasAdded = (0 < _adoptionApplicationResponseAccessor.InsertAdoptionApplicationResponse(adoptionApplicationResponse));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wasAdded;
        }

        public bool EditAdoptionApplicationResponse(AdoptionApplicationResponse newAdoptionApplicationResponse, AdoptionApplicationResponse oldAdoptionApplicationResponse)
        {
            bool wasEdited = false;

            try
            {
                wasEdited = (0 < _adoptionApplicationResponseAccessor.UpdateAdoptionApplicationResponse(newAdoptionApplicationResponse, oldAdoptionApplicationResponse));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wasEdited;
        }

        public AdoptionApplicationResponseVM RetrieveAdoptionApplicationResponse(int adoptionApplicationId)
        {
            AdoptionApplicationResponseVM responseVM = new AdoptionApplicationResponseVM();

            try
            {
                responseVM = _adoptionApplicationResponseAccessor.SelectAdoptionApplicationResponseByAdoptionApplicationId(adoptionApplicationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseVM;
        }
    }
}
