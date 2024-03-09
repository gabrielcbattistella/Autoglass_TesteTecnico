using System.Collections.Generic;
using Xunit;
using Moq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services.Services;
using Domain.BaseResponse;
using System;

namespace Tests.Services
{
    public class ServiceProductTests
    {
        [Fact]
        public void Add_Product_AddedToRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepositoryProduct>();
            var service = new ServiceProduct(repositoryMock.Object);
            var product = new Product();

            // Act
            service.Add(product);

            // Assert
            repositoryMock.Verify(repo => repo.Add(product), Times.Once);
        }

        [Fact]
        public void Delete_Product_DeletedFromRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepositoryProduct>();
            var service = new ServiceProduct(repositoryMock.Object);
            var product = new Product();

            // Act
            service.Delete(product);

            // Assert
            repositoryMock.Verify(repo => repo.Delete(product), Times.Once);
        }

        [Fact]
        public void GetAll_ReturnsAllProductsFromRepository()
        {
            // Arrange
            var expectedProducts = new List<Product>
        {
            new Product { CodigoProduto = 1 },
            new Product { CodigoProduto = 2 },
            new Product { CodigoProduto = 3 }
        };
            var repositoryMock = new Mock<IRepositoryProduct>();
            repositoryMock.Setup(repo => repo.GetAll()).Returns(expectedProducts);
            var service = new ServiceProduct(repositoryMock.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.Equal(expectedProducts, result);
        }

        [Fact]
        public void GetById_ReturnsProductFromRepository()
        {
            // Arrange
            var expectedProduct = new Product { CodigoProduto = 1 };
            var repositoryMock = new Mock<IRepositoryProduct>();
            repositoryMock.Setup(repo => repo.GetById(1)).Returns(expectedProduct);
            var service = new ServiceProduct(repositoryMock.Object);

            // Act
            var result = service.GetById(1);

            // Assert
            Assert.Equal(expectedProduct, result);
        }

        [Fact]
        public void Update_Product_UpdatedInRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepositoryProduct>();
            var service = new ServiceProduct(repositoryMock.Object);
            var product = new Product();

            // Act
            service.Update(product);

            // Assert
            repositoryMock.Verify(repo => repo.Update(product), Times.Once);
        }

        [Fact]
        public void Filter_ReturnsPagedResultFromRepository()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { CodigoProduto = 1 },
                new Product { CodigoProduto = 2 },
                new Product { CodigoProduto = 3 }
            };
            var expectedTotalCount = 10;
            var entity = new Product();
            var page = 1;
            var pageSize = 5;
            var repositoryMock = new Mock<IRepositoryProduct>();
            repositoryMock.Setup(repo => repo.FilterProducts(entity, page, pageSize))
                          .Returns(new PagedResult<Product>
                          {
                              Results = expectedProducts,
                              CurrentPage = page,
                              PageCount = (int)Math.Ceiling((double)expectedTotalCount / pageSize),
                              PageSize = pageSize,
                              RowCount = expectedTotalCount
                          });
            var service = new ServiceProduct(repositoryMock.Object);

            // Act
            var result = service.Filter(entity, page, pageSize);

            // Assert
            Assert.Equal(expectedProducts, result.Results);
            Assert.Equal(page, result.CurrentPage);
            Assert.Equal((int)Math.Ceiling((double)expectedTotalCount / pageSize), result.PageCount);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(expectedTotalCount, result.RowCount);
        }
    }
}
