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

using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using System.Linq;

namespace Repositories
{

    public interface IUserProjectLikeRepository : IRepository<ProjectLike>
    {

        bool CheckIfUserAlreadyLiked(int userId, int projectId);

    }

    public class UserProjectLikeRepository : Repository<ProjectLike>,
                                             IUserProjectLikeRepository
    {
        public UserProjectLikeRepository(DbContext dbContext) :
            base(dbContext) { }

        public override void Add(ProjectLike projectLike)
        {
            DbContext.Add(projectLike);
        }

        public override void Remove(ProjectLike projectLike)
        {
            ProjectLike projectToRemove = GetDbSet
                    <ProjectLike>()
                .SingleOrDefault(project => project.UserId ==
                                            projectLike.ProjectLiker.Id &&
                                            project.LikedProject.Id ==
                                            projectLike.LikedProject.Id);

            GetDbSet<ProjectLike>()
                .Remove(projectToRemove);
        }

        bool IUserProjectLikeRepository
            .CheckIfUserAlreadyLiked(int userId, int projectId)
        {
            ProjectLike projectLike = GetDbSet<ProjectLike>()
                .SingleOrDefault(project =>
                                     (project.ProjectLiker.Id == userId) && project.LikedProject.Id == projectId);

            if(projectLike != null)
            {
                return true;
            }
            return false;
        }
    }

}
