using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using PIMServer.Core.Interfaces.Repositories;
using PIMServer.Core.Services;
using PIMServer.Core.Interfaces.Services;
using PIMServer.Core.Models;

namespace PIMServer.Core.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IProductRepository> _repositoryMock;
        private readonly Mock<ILogger<ProductService>> _loggerMock;
        private readonly IProductService _sut;

        public ProductServiceTests()
        {
            _fixture = new Fixture();
            _repositoryMock = _fixture.Freeze<Mock<IProductRepository>>();
            _loggerMock = _fixture.Freeze<Mock<ILogger<ProductService>>>();
            _sut = new ProductService(_repositoryMock.Object, _loggerMock.Object);
        }
        [Fact]
        public async Task GetAllProducts_ShouldReturnData_WhenDataFound()
        {
            // Arrange
            var productsMock = _fixture.Create<IEnumerable<Product>>();
            _repositoryMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productsMock);

            // Act
            var result = await _sut.GetAllProducts().ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Product>>();
            _repositoryMock.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnNull_WhenDataNotFound()
        {
            // Arrange
            IEnumerable<Product> productsMock = null;
            _repositoryMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productsMock);

            // Act
            var result = await _sut.GetAllProducts().ConfigureAwait(false);

            // Assert
            result.Should().BeNull();
            _repositoryMock.Verify(x => x.GetAllProducts(), Times.Once());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnData_WhenDataFound()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var productMock = _fixture.Create<Product>();
            _repositoryMock.Setup(x => x.GetProductById(id)).ReturnsAsync(productMock);

            // Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Product>();
            _repositoryMock.Verify(x => x.GetProductById(id), Times.Once());
        }

        [Fact]
        public async Task GetProductById_ShouldReturnNull_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            Product product = null;
            _repositoryMock.Setup(x => x.GetProductById(id)).ReturnsAsync(product);

            // Act
            var result = await _sut.GetProductById(id).ConfigureAwait(false);

            // Assert
            result.Should().BeNull();
            _repositoryMock.Verify(x => x.GetProductById(id), Times.Once());
        }

        [Fact]
        public void GetProductById_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            Guid id = new Guid("0");
            Product product = null;
            _repositoryMock.Setup(x => x.GetProductById(id)).ReturnsAsync(product);

            // Act
            Func<Product> result = () => _sut.GetProductById(id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task CreateProduct_ShouldReturnData_WhenDataIsInsertedSuccessfully()
        {
            // Arrange
            var productMock = _fixture.Create<Product>();
            _repositoryMock.Setup(x => x.CreateProduct(productMock)).ReturnsAsync(productMock);

            // Act
            var result = await _sut.CreateProduct(productMock).ConfigureAwait(false);


            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Product>();
            _repositoryMock.Verify(x => x.CreateProduct(productMock), Times.Once());
        }

        [Fact]
        public void CreateProduct_ShouldThrowNullReferenceException_WhenInputIsNull()
        {
            // Arrange
            var productMock = _fixture.Create<Product>();
            Product request = null;
            _repositoryMock.Setup(x => x.CreateProduct(productMock)).ReturnsAsync(productMock);

            // Act
            Func<Product> result = () => _sut.CreateProduct(request).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnTrue_WhenDataIsDeletedSuccessfully()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            _repositoryMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(true);

            // Act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);


            // Assert
            result.Should().BeTrue();
            _repositoryMock.Verify(x => x.DeleteProduct(id), Times.Once());
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnFalse_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            _repositoryMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(false);

            // Act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);


            // Assert
            result.Should().BeFalse();
            _repositoryMock.Verify(x => x.DeleteProduct(id), Times.Once());
        }

        [Fact]
        public void DeleteProduct_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            var response = _fixture.Create<bool>();
            var id = new Guid("0");
            _repositoryMock.Setup(x => x.DeleteProduct(id)).ReturnsAsync(response);

            // Act
            Func<bool> result = () => _sut.DeleteProduct(id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnTrue_WhenDataUpdatedSuccessfully()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var productMock = _fixture.Create<Product>();
            _repositoryMock.Setup(x => x.UpdateProduct(productMock, id)).ReturnsAsync("Update success!");

            // Act
            var result = await _sut.UpdateProduct(productMock, id).ConfigureAwait(false);


            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            _repositoryMock.Verify(x => x.UpdateProduct(productMock, id), Times.Once());
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnFalse_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var productMock = _fixture.Create<Product>();
            _repositoryMock.Setup(x => x.UpdateProduct(productMock, id)).ReturnsAsync("Not found!");

            // Act
            var result = await _sut.UpdateProduct(productMock, id).ConfigureAwait(false);


            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            _repositoryMock.Verify(x => x.UpdateProduct(productMock, id), Times.Once());
        }

        [Fact]
        public async Task UpdateProduct_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            Guid id = new Guid("0");
            var productMock = _fixture.Create<Product>();
            _repositoryMock.Setup(x => x.UpdateProduct(productMock, id)).ReturnsAsync("Not found!");

            // Act
            Func<object> result = () => _sut.UpdateProduct(productMock, id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task UpdateProduct_ShouldThrowNullReferenceException_WhenRequestIsNull()
        {
            // Arrange
            Guid id = new Guid("0");
            var productMock = _fixture.Create<Product>();
            Product request = null;
            _repositoryMock.Setup(x => x.UpdateProduct(productMock, id)).ReturnsAsync("Not found!");

            // Act
            Func<object> result = () => _sut.UpdateProduct(request, id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
    }
}