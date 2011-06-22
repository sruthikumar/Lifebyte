﻿using System;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Moq;
using NUnit.Framework;
using System.Security.Principal;

namespace Lifebyte.Web.Tests.Controllers
{
    [TestFixture]
    public class ProfileControllerTest
    {
        [Test]
        public void Class_Is_Authorized()
        {
            Assert.IsTrue(typeof (ProfileController)
                              .GetCustomAttributes(false)
                              .Any(c => c.GetType() == typeof (AuthorizeAttribute)));
        }

        [Test]
        public void Constructor_IsValid()
        {
            var profileController = new ProfileController(new Mock<IDataService<Volunteer>>().Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            Assert.IsInstanceOf<Controller>(profileController);
        }

        [Test]
        public void Index_ReturnsView()
        {
            var volunteerDataService = new Mock<IDataService<Volunteer>>();
            volunteerDataService.Setup(v => v.SelectOne(vol => vol.Id == It.IsAny<Guid>()))
                .Returns(new Volunteer());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          new Mock<IFormsAuthenticationService>().Object);

            //ActionResult result = profileController.Index();

            //Assert.IsInstanceOf<ViewResult>(result);
            Assert.Inconclusive();
        }


        [Test]
        public void Edit_ReturnsView()
        {
            var volunteerDataService = new Mock<IDataService<Volunteer>>();
            volunteerDataService.Setup(v => v.SelectOne(vol => vol.Id == It.IsAny<Guid>()))
                .Returns(new Volunteer());

            var formsAuthenticationService = new Mock<IFormsAuthenticationService>();
            formsAuthenticationService.Setup(f => f.GetVolunteerID(It.IsAny<IPrincipal>()))
                .Returns(Guid.NewGuid());

            var profileController = new ProfileController(volunteerDataService.Object,
                                                          formsAuthenticationService.Object);

            //ActionResult result = profileController.Edit();

            //Assert.IsInstanceOf<ViewResult>(result);
            Assert.Inconclusive();
        }
    }
}