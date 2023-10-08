using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramForm.Controllers;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.Interfaces;


namespace ProgramFormTests
{
    public class WorkFlowControllerTests
    {
        private IWorkFlowService _workService;
        private IMapper _mapper;
        private WorkFlowController _controller;

        public WorkFlowControllerTests()
        {
            _workService = A.Fake<IWorkFlowService>();
            _mapper = A.Fake<IMapper>();
            _controller = new WorkFlowController(_workService, _mapper);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var fakeWorkFlows = new List<WorkFlow>(); 
            var fakeWorkFlowDtos = new List<WorkFlowDto>(); 

            A.CallTo(() => _workService.GetAllWorkFlowAsync()).Returns(fakeWorkFlows);
            A.CallTo(() => _mapper.Map<IEnumerable<WorkFlowDto>>(fakeWorkFlows)).Returns(fakeWorkFlowDtos);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Same(fakeWorkFlowDtos, okResult.Value);
        }

        [Fact]
        public async Task UpdateWorkFlow_WithValidData_ReturnsOkResult()
        {
            // Arrange
            var fakeId = "fakeId";
            var fakeWorkFlowDto = new WorkFlowDto(); 
            var fakeExistingWorkFlow = new WorkFlow(); 
            var fakeUpdatedWorkFlow = new WorkFlow(); 

            A.CallTo(() => _workService.GetWorkFlowByIdAsync(fakeId)).Returns(fakeExistingWorkFlow);
            A.CallTo(() => _mapper.Map(fakeWorkFlowDto, fakeExistingWorkFlow)).Returns(fakeUpdatedWorkFlow);
            A.CallTo(() => _workService.UpdateWorkFlowAsync(fakeId, fakeUpdatedWorkFlow))
                .Returns(Task.FromResult<WorkFlow>(fakeUpdatedWorkFlow));
            A.CallTo(() => _mapper.Map<WorkFlowDto>(fakeUpdatedWorkFlow)).Returns(fakeWorkFlowDto);

            // Act
            var result = await _controller.UpdateWorkFlow(fakeId, fakeWorkFlowDto);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Same(fakeWorkFlowDto, okResult.Value);
        }
        [Fact]
        public async Task UpdateWorkFlow_WithInvalidData_ReturnsBadRequest()
        {
            // Arrange
            var fakeId = "fakeId";
            WorkFlowDto fakeWorkFlowDto = null;

            // Act
            var result = await _controller.UpdateWorkFlow(fakeId, fakeWorkFlowDto);

            // Assert
            Assert.IsType<ActionResult<WorkFlowDto>>(result); 
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("ProgramDetails object is null", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateWorkFlow_WithNonExistingWorkFlow_ReturnsNotFound()
        {
            // Arrange
            var fakeId = "fakeId";
            WorkFlowDto fakeWorkFlowDto = new WorkFlowDto(); 
            WorkFlow fakeExistingWorkFlow = null;

            A.CallTo(() => _workService.GetWorkFlowByIdAsync(fakeId)).Returns(fakeExistingWorkFlow);

            // Act
            var result = await _controller.UpdateWorkFlow(fakeId, fakeWorkFlowDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result); 
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

    }
}
