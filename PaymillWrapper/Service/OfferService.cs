﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class OfferService : AbstractService<Offer>
    {
        public OfferService(HttpClient client, string apiUrl)
            : base(client, apiUrl)
        {
        }

        /// <summary>
        /// This function allows request a offer list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list offer-object</returns>
        public async Task<IReadOnlyCollection<Offer>> GetAsync(Filter filter = null)
        {
            return await GetAsync(Resource.Offers, filter);
        }

        /// <summary>
        /// This function creates a offer object
        /// </summary>
        /// <param name="offer">Object-offer</param>
        /// <returns>New object-offer just add</returns>
        public async Task<Offer> AddAsync(Offer offer)
        {
            return await AddAsync(
                Resource.Offers,
                offer,
                null,
                new UrlEncoder().EncodeOfferAdd(offer));
        }

        /// <summary>
        /// To GetAsync the details of an existing offer you’ll need to supply the offer ID
        /// </summary>
        /// <param name="offerId">Offer identifier</param>
        /// <returns>Offer-object</returns>
        public async Task<Offer> GetAsync(string offerId)
        {
            return await GetAsync(Resource.Offers, offerId);
        }

        /// <summary>
        /// This function deletes a offer
        /// </summary>
        /// <param name="offerId">Offer identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public async Task<bool> RemoveAsync(string offerId)
        {
            return await RemoveAsync(Resource.Offers, offerId);
        }

        /// <summary>
        /// This function updates the data of a offer
        /// </summary>
        /// <param name="offer">Object-offer</param>
        /// <returns>Object-offer just updated</returns>
        public async Task<Offer> UpdateAsync(Offer offer)
        {
            return await UpdateAsync(
                Resource.Offers,
                offer,
                offer.Id,
                new UrlEncoder().EncodeOfferUpdate(offer));
        }
    }
}