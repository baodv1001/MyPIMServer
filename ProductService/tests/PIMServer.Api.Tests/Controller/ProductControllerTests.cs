using AutoFixture;
using Xunit;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using System.Collections.Generic;
using PIMServer.Core.Interfaces.Services;
using PIMServer.Api.Controllers;
using PIMServer.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeService.Api.Tests.V1.Controllers
{
    public class ProductControllerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IProductService> _serviceMock;
        private readonly ProductController _sut;

        public ProductControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IProductService>>();
            // create the implementation in-memory
            _sut = new ProductController(_serviceMock.Object); 
        }
        [Fact]
        public async Task GetProducts_ShouldReturnOkRespone_WhenDataFound()
        {
            // Arrange
            var productsMock = _fixture.Create<IEnumerable<Product>>();
            _serviceMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productsMock);

            //Act
            var result = await _sut.GetProducts().ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<IEnumerable<Product>>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(productsMock.GetType());
            _serviceMock.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Fact]
        public async Task GetProducts_ShouldReturnNotFound_WhenDataNotFound()
        {
            // Arrange
            List<Product> response = null;
            _serviceMock.Setup(x => x.GetAllProducts()).ReturnsAsync(response);

            //Act
            var result = await _sut.GetProducts().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<NoContentResult>();
            _serviceMock.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnOkRespone_WhenValidInput()
        {
            // Arrange
            var productMock = _fixture.Create<Product>();
            var id = _fixture.Create<Guid>();
            _serviceMock.Setup(x => x.GetProductById(id)).ReturnsAsync(productMock);

            //Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Product>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(productMock.GetType());
            _serviceMock.Verify(x => x.GetProductById(id), Times.Once());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnNotFound_WhenNoDataFound()
        {
            // Arrange
            Product response = null;
            var id = _fixture.Create<Guid>();
            _serviceMock.Setup(x => x.GetProductById(id)).ReturnsAsync(response);

            //Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            //Assert
            /*Assert.NotNull(result);*/
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<NoContentResult>();
            _serviceMock.Verify(x => x.GetProductById(id), Times.Once());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnBadRequest_WhenInputIsEqualZero()
        {
            // Arrange
            var response  = _fixture.Create<Product>();
            Guid id = new Guid();
            _serviceMock.Setup(x => x.GetProductById(id)).ReturnsAsync(response);

            //Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.GetAllProducts(), Times.Never());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnBadRequest_WhenInputIsLessThanZero()
        {
            // Arrange
            var response = _fixture.Create<Product>();
            Guid id = new Guid("null");
            _serviceMock.Setup(x => x.GetProductById(id)).ReturnsAsync(response);

            //Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.GetAllProducts(), Times.Never());
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnOkRespone_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<Product>();
            var response = _fixture.Create<Product>();
            _serviceMock.Setup(x => x.CreateProduct(request)).ReturnsAsync(response);

            //Act
            var result = await _sut.CreateProduct(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<Product>>();
            result.Result.Should().BeAssignableTo<CreatedAtRouteResult>();
            _serviceMock.Verify(x => x.CreateProduct(response), Times.Never());
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnBadRequest_WhenInValidRequest()
        {
            // Arrange
            var request = _fixture.Create<Product>();
            _sut.ModelState.AddModelError("Name", "The Name field is required.");
            var response = _fixture.Create<Product>();
            _serviceMock.Setup(x => x.CreateProduct(request)).ReturnsAsync(response);

            //Act
            var result = await _sut.CreateProduct(request).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.CreateProduct(response), Times.Never());
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnNoContents_WhenDeleteARecord()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            _serviceMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(true);

            //Act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnNotFound_WhenRecordNotFound()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            _serviceMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(false);

            //Act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnBadRequest_WhenInputIsZero()
        {
            // Arrange
            Guid id = new Guid("0");
            _serviceMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(false);

            //Act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.DeleteProduct(id), Times.Never());
        }

        [Fact]
        public async Task UpateProduct_ShouldReturnBadRespone_WhenInputIsZero()
        {
            // Arrange
            Guid id = new Guid("0");
            var request = _fixture.Create<Product>();
            _serviceMock.Setup(x => x.UpdateProduct(request, id)).ReturnsAsync("Not found!");

            //Act
            var result = await _sut.UpdateProduct(request, id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.UpdateProduct(request, id), Times.Never());
        }

        [Fact]
        public async Task UpateProduct_ShouldReturnBadRespone_WhenInvalidRequest()
        {
            // Arrange
            Guid id = _fixture.Create<Guid>();
            var request = _fixture.Create<Product>();
            _sut.ModelState.AddModelError("Name", "The Name field is required.");
            var response = _fixture.Create<Product>();
            _serviceMock.Setup(x => x.UpdateProduct(request, id)).ReturnsAsync("Bad request!");

            //Act
            var result = await _sut.UpdateProduct(request, id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.UpdateProduct(request, id), Times.Never());
        }

        [Fact]
        public async Task UpateProduct_ShouldReturnOkRespone_WhenRecordIsUpdated()
        {
            // Arrange
            Guid id = _fixture.Create<Guid>();
            var request = _fixture.Create<Product>();
            string respone = "Update success!";
            _serviceMock.Setup(x => x.UpdateProduct(request, id)).ReturnsAsync(respone);

            //Act
            var result = await _sut.UpdateProduct(request, id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(respone.GetType());
            _serviceMock.Verify(x => x.UpdateProduct(request, id), Times.Once());
        }

        [Fact]
        public async Task UpateProduct_ShouldReturnNotFound_WhenRecordNotFound()
        {
            // Arrange
            Guid id = _fixture.Create<Guid>();
            var request = _fixture.Create<Product>();
            string respone = "Not Found!";
            _serviceMock.Setup(x => x.UpdateProduct(request, id)).ReturnsAsync(respone);

            //Act
            var result = await _sut.UpdateProduct(request, id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(respone.GetType());
            _serviceMock.Verify(x => x.UpdateProduct(request, id), Times.Once());
        }

    }
}