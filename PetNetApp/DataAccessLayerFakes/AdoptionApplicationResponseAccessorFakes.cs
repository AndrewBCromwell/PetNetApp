// Created By Asa Armstrong
// Created On 2023/04/04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class AdoptionApplicationResponseAccessorFakes : IAdoptionApplicationResponseAccessor
    {
        private List<AdoptionApplicationResponse> _responses;

        public AdoptionApplicationResponseAccessorFakes()
        {
            _responses = new List<AdoptionApplicationResponse>()
            {
                new AdoptionApplicationResponse()
                {
                    AdoptionApplicationResponseId = 999_999,
                    AdoptionApplicationId = 999_999,
                    UsersId = 999_999,
                    Approved = false,
                    AdoptionApplicationResponseDate = DateTime.Now,
                    AdoptionApplicationResponseNotes = "notes"
                }
            };
        }

        public int InsertAdoptionApplicationResponse(AdoptionApplicationResponse adoptionApplicationResponse)
        {
            int result = 0;
            int oldCount = _responses.Count;

            try
            {
                _responses.Add(adoptionApplicationResponse);
                result = _responses.Count - oldCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public AdoptionApplicationResponseVM SelectAdoptionApplicationResponseByAdoptionApplicationId(int adoptionApplicationId)
        {
            AdoptionApplicationResponseVM response = new AdoptionApplicationResponseVM();

            try
            {
                var tempResponse = _responses.FirstOrDefault(d => d.AdoptionApplicationId == adoptionApplicationId);
                response.AdoptionApplicationResponseDate = tempResponse.AdoptionApplicationResponseDate;
                response.AdoptionApplicationResponseId = tempResponse.AdoptionApplicationResponseId;
                response.AdoptionApplicationResponseNotes = tempResponse.AdoptionApplicationResponseNotes;
                response.Approved = tempResponse.Approved;
                response.UsersId = tempResponse.UsersId;
                response.AdoptionApplicationId = tempResponse.AdoptionApplicationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public int UpdateAdoptionApplicationResponse(AdoptionApplicationResponse newAdoptionApplicationResponse, AdoptionApplicationResponse oldAdoptionApplicationResponse)
        {
            int result = 0;

            var response = _responses.FirstOrDefault(d => d.AdoptionApplicationResponseId == oldAdoptionApplicationResponse.AdoptionApplicationResponseId);
            if (!response.Equals(null))
            {
                response = newAdoptionApplicationResponse;
            }

            if (_responses.FirstOrDefault(d => d.AdoptionApplicationResponseId == oldAdoptionApplicationResponse.AdoptionApplicationResponseId).Equals(newAdoptionApplicationResponse))
            {
                result = 1;
            }

            return result;
        }
    }
}
