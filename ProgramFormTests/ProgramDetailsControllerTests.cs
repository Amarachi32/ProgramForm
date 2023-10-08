using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using ProgramForm.Controllers;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.Interfaces;


namespace ProgramFormTests
{
    public class ProgramDetailsControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResultWithProgramDetails()
        {
            // Arrange
            var fakeProgramDetailsService = A.Fake<IProgramDetailsService>();
            var fakeMapper = A.Fake<IMapper>();

            var programDetailsList = new List<ProgramDetails>
        {
            new ProgramDetails { Id = "1", Title = "Programming" },
        };

            A.CallTo(() => fakeProgramDetailsService.GetAllProgramDetailsAsync())
                .Returns(Task.FromResult<IEnumerable<ProgramDetails>>(programDetailsList));

            var controller = new ProgramDetailsController(fakeProgramDetailsService, null, null, null, fakeMapper);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var programDetailsDtoList = Assert.IsAssignableFrom<IEnumerable<ProgramDetailsDto>>(okResult.Value);


            Assert.Equal(2, programDetailsDtoList.Count());

            A.CallTo(() => fakeProgramDetailsService.GetAllProgramDetailsAsync()).MustHaveHappenedOnceExactly();
        }
    }
}
