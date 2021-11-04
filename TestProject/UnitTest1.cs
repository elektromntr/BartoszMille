using BartoszMilleApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Model;
using Service;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class ProductControllerTests
    {
        private Mock<ProductService> _productService = new Mock<ProductService>();
        private Product _product;

        [TestInitialize]
        public void Initialize()
        {
            _product = new Product("TestName", "TestDescription");
        }

        [TestMethod]
        public async Task ProductController_Create_ReturnsProduct()
        {
            //Arrange
            _productService.Setup(s => s.Create(It.IsAny<Product>())).Returns(_product);
            var unitUnderTest = new ProductController(null, _productService.Object);

            //Act
            var result = await unitUnderTest.Create(_product) as Product;

            //Assert
            Assert.AreEqual(_product.Name, result.Name);
        }
    }
}
