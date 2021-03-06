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
using Moq;
using NUnit.Framework;
using Repositories;
using Repositories.Tests.DataSources;
using Services.Services;
using Services.Tests.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Tests
{
    /// <summary>
    /// EmbeddedProjectServiceTest
    /// </summary>
    /// <seealso cref="IEmbedRepository" />
    [TestFixture]
    public class EmbedServiceTest : ServiceTest<EmbeddedProject, EmbedService, IEmbedRepository>
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        protected new IEmbedService Service => (IEmbedService)base.Service;

        /// <summary>
        /// Determines whether [is non existing unique identifier asynchronous unique identifier exists] [the specified project].
        /// </summary>
        /// <param name="project">The project.</param>
        [Test]
        public async Task IsNonExistingGuidAsync_guid_exists([EmbeddedDataSource]EmbeddedProject project)
        {
            RepositoryMock.Setup(
                              repository => repository.IsNonExistingGuidAsync(project.Guid))
                          .Returns(
                              Task.FromResult(false)
                          );

            bool projectWithGuidDoesNotExist = await Service.IsNonExistingGuidAsync(project.Guid);

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.IsNonExistingGuidAsync(project.Guid), Times.Once);
            });
            
            Assert.IsFalse(projectWithGuidDoesNotExist);
        }

        /// <summary>
        /// Determines whether [is non existing unique identifier asynchronous unique identifier non existing] [the specified project].
        /// </summary>
        /// <param name="project">The project.</param>
        [Test]
        public async Task IsNonExistingGuidAsync_guid_non_existing([EmbeddedDataSource]EmbeddedProject project)
        {
            RepositoryMock.Setup(
                              repository => repository.IsNonExistingGuidAsync(project.Guid))
                          .Returns(
                              Task.FromResult(true)
                          );

            bool projectWithGuidDoesNotExist = await Service.IsNonExistingGuidAsync(project.Guid);

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.IsNonExistingGuidAsync(project.Guid), Times.Once);
            });

            Assert.IsTrue(projectWithGuidDoesNotExist);
        }

        /// <summary>
        /// Gets the embedded projects goodflow.
        /// </summary>
        /// <param name="embeddedProjects">The embedded projects.</param>
        [Test]
        public async Task GetEmbeddedProjects_goodflow([EmbeddedDataSource(100)]IEnumerable<EmbeddedProject> embeddedProjects)
        {
            RepositoryMock.Setup(
                              repository => repository.GetEmbeddedProjectsAsync())
                          .Returns(
                              Task.FromResult(embeddedProjects)
                          );

            IEnumerable<EmbeddedProject> actualEmbeddedProjects = await Service.GetEmbeddedProjectsAsync();

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.GetEmbeddedProjectsAsync(), Times.Once);
            });

            Assert.AreEqual(actualEmbeddedProjects, embeddedProjects);
        }

        /// <summary>
        /// Gets the embedded projects no projects.
        /// </summary>
        [Test]
        public async Task GetEmbeddedProjects_NoProjects()
        {
            RepositoryMock.Setup(
                              repository => repository.GetEmbeddedProjectsAsync())
                          .Returns(
                              Task.FromResult(Enumerable.Empty<EmbeddedProject>())
                          );

            IEnumerable<EmbeddedProject> actualEmbeddedProjects = await Service.GetEmbeddedProjectsAsync();

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.GetEmbeddedProjectsAsync(), Times.Once);
            });

            Assert.IsNotNull(actualEmbeddedProjects);
            Assert.AreEqual(actualEmbeddedProjects, Enumerable.Empty<EmbeddedProject>());
        }

        /// <summary>
        /// Gets the embedded project goodflow.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="embeddedProjects">The embedded projects.</param>
        [Test]
        public async Task GetEmbeddedProject_goodflow([EmbeddedDataSource]EmbeddedProject project)
        {
            RepositoryMock.Setup(
                              repository => repository.GetEmbeddedProjectAsync(project.Guid))
                          .Returns(
                              Task.FromResult(project)
                          );

            EmbeddedProject actualEmbeddedProject = await Service.FindAsync(project.Guid);

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.GetEmbeddedProjectAsync(project.Guid), Times.Once);
            });

            Assert.IsNotNull(actualEmbeddedProject);
            Assert.AreEqual(actualEmbeddedProject, project);
        }


        /// <summary>
        /// Gets the embedded projects no project.
        /// </summary>
        /// <param name="project">The project.</param>
        [Test]
        public async Task GetEmbeddedProjects_noProject([EmbeddedDataSource]EmbeddedProject project)
        {
            RepositoryMock.Setup(
                              repository => repository.GetEmbeddedProjectAsync(project.Guid))
                          .Returns(
                              Task.FromResult((EmbeddedProject)null)
                          );

            EmbeddedProject actualEmbeddedProject = await Service.FindAsync(project.Guid);

            Assert.DoesNotThrow(() => {
                RepositoryMock.Verify(repository => repository.GetEmbeddedProjectAsync(project.Guid), Times.Once);
            });

            Assert.IsNull(actualEmbeddedProject);
        }
    }
}
