﻿using Exceptions;
using Microsoft.Extensions.Configuration;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.FinnhubService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.FinnhubService
{
    public class FinnhubCompanyProfile : IFinnhubCompanyProfileService
    {
        private readonly IFinnhubRepository _finnhubRepository;

        public FinnhubCompanyProfile(IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            try
            {
                //invoke repository
                Dictionary<string, object>? responseDictionary = await _finnhubRepository.GetCompanyProfile(stockSymbol);

                //return response dictionary back to the caller
                return responseDictionary;
            }
            catch (Exception ex)
            {
                FinnhubException finnhubException = new FinnhubException("Unable to connect to Finnhub server", ex);
                throw finnhubException;
            }
        }
    }
}
