/*
* Digital Excellence Copyright (C) 2020 Brend Smits
* 
* This program is free software: you can redistribute it and/or modify 
* it under the terms of the GNU Lesser General Public License as published 
* by the Free Software Foundation version 3 of the License.
* 
* This program is distributed in the hope that it will be useful, 
* but WITHOUT ANY WARRANTY; without even the implied warranty 
* of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
* See the GNU Lesser General Public License for more details.
* 
* You can find a copy of the GNU Lesser General Public License 
* along with this program, in the LICENSE.md file in the root project directory.
* If not, see https://www.gnu.org/licenses/lgpl-3.0.txt
*/

using Models;
using Repositories;
using Repositories.Base;
using Services.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{

    public interface IInstitutionService : IService<Institution>
    {

        /// <summary>
        /// This method gets all the institutions asynchronous.
        /// </summary>
        /// <returns>This method returns a list of institutions.</returns>
        Task<IEnumerable<Institution>> GetInstitutionsAsync();

        /// <summary>
        /// This method gets the institution with the specified identity id asynchronous.
        /// </summary>
        /// <param name="institutionIdentityId">The identity id which is used for searching the institution.</param>
        /// <returns>This method returns the found institution with the specified identity id.</returns>
        Task<Institution> GetInstitutionByInstitutionIdentityId(string institutionIdentityId);

    }

    public class InstitutionService : Service<Institution>, IInstitutionService
    {

        public InstitutionService(IInstitutionRepository repository) : base(repository) { }

        protected new IInstitutionRepository Repository => (IInstitutionRepository) base.Repository;

        public async Task<IEnumerable<Institution>> GetInstitutionsAsync()
        {
            return await Repository.GetInstitutionsAsync();
        }

        public async Task<Institution> GetInstitutionByInstitutionIdentityId(string institutionIdentityId)
        {
            return await Repository.GetInstitutionByInstitutionIdentityId(institutionIdentityId);
        }

    }

}
