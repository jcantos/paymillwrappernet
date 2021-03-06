﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaymillWrapper.Models;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public class OfferService : AbstractService<Offer>
    {
        public OfferService(HttpClientRest client):base(client)
        {
        }

        /// <summary>
        /// This function allows request a offer list
        /// </summary>
        /// <returns>Returns a list offers-object</returns>
        public List<Offer> GetOffers()
        {
            return getList<Offer>(Resource.Offers);
        }

        /// <summary>
        /// This function allows request a offer list
        /// </summary>
        /// <param name="filter">Result filtered in the required way</param>
        /// <returns>Returns a list offer-object</returns>
        public List<Offer> GetOffers(Filter filter)
        {
            return getList<Offer>(Resource.Offers, filter);
        }

        /// <summary>
        /// This function creates a offer object
        /// </summary>
        /// <param name="client">Object-offer</param>
        /// <returns>New object-offer just add</returns>
        public Offer AddOffer(Offer offer)
        {
            return add<Offer>(
                Resource.Offers,
                offer,
                null,
                new URLEncoder().EncodeOfferAdd(offer));
        }

        /// <summary>
        /// To get the details of an existing offer you’ll need to supply the offer ID
        /// </summary>
        /// <param name="clientID">Offer identifier</param>
        /// <returns>Offer-object</returns>
        public Offer GetOffer(string offerID)
        {
            return get<Offer>(Resource.Offers, offerID);
        }

        /// <summary>
        /// This function deletes a offer
        /// </summary>
        /// <param name="clientID">Offer identifier</param>
        /// <returns>Return true if remove was ok, false if not possible</returns>
        public bool RemoveOffer(string offerID)
        {
            return remove<Offer>(Resource.Offers, offerID);
        }

        /// <summary>
        /// This function updates the data of a offer
        /// </summary>
        /// <param name="client">Object-offer</param>
        /// <returns>Object-offer just updated</returns>
        public Offer UpdateOffer(Offer offer)
        {
            return update<Offer>(
                Resource.Offers,
                offer,
                offer.Id,
                new URLEncoder().EncodeOfferUpdate(offer));
        }
    }
}