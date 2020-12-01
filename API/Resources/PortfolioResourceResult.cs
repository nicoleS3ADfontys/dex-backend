using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Resources
{
    /// <summary>
    /// The view model of a portfolio item
    /// </summary>
    public class PortfolioResourceResult : PortfolioResource
    {
        /// <summary>
        /// This sets or gets the user of the portfolio Resource result id
        /// </summary>
        public int Id { get; set; }
    }
}
