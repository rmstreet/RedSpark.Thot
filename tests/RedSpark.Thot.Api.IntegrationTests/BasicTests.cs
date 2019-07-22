using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RedSpark.Thot.Api.Domain.Models.Example;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace RedSpark.Thot.Api.IntegrationTests
{

    public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;
        private const string _urlBase = "/api/products";
        
        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData(_urlBase)]
        [Trait("Basic Tests", "Products")]
        public void ShouldReturnAllProductsWithSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();


            // Act
            var response = client.GetAsync(url).GetAwaiter().GetResult();


            // Assert
            // Assert.True(response.IsSuccessStatusCode, "Falha no statusCode");
            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var products = response.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();

            products
                .Should()
                .NotBeNull();

            products
                .Should()
                .HaveCount(2);

            products
                .Should()
                .Equal(new List<Product>()
                {
                    new Product() {Id = 1, Name = "Tênis Addidas"},
                    new Product() {Id = 2, Name = "Tênis Nike"},
                });

        }

        [Theory]
        [InlineData(_urlBase, 1, "Tênis Addidas")]
        [Trait("Basic Tests", "Products")]
        public  void ShouldReturnAProductByIdWithSuccess(string url, int id, string expectedProductName)
        {
            // Arrange
            var client = _factory.CreateClient();


            // Act
            var response = client.GetAsync($"{url}/{id}").GetAwaiter().GetResult();


            // Assert
            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var productFound = response.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();

            productFound
                .Should()
                .NotBeNull();

            productFound
                .Name
                .Should()
                .Be(expectedProductName);

        }

        [Theory]
        [InlineData(_urlBase, "Tênis Pumma")]
        [InlineData(_urlBase, "Tênis Hoka")]
        [Trait("Basic Tests", "Products")]
        public void ShouldRegisterProductWithSuccess(string url, string newValue)
        {
            // Arrange
            var client = _factory.CreateClient();
            var objRequest = JsonConvert.SerializeObject(new { Name = newValue });
            

            // Act
            var response = client.PostAsync(url, new StringContent(objRequest, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();


            // Assert
            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var productCreated = response.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();

            productCreated
                .Should()
                .NotBeNull();

            productCreated
                .Id
                .Should()
                .NotBe(0);

            productCreated
                .Name
                .Should()
                .Be(newValue);

        }

        [Theory]
        [InlineData(_urlBase, "")]
        [InlineData(_urlBase, null)]
        [Trait("Basic Tests", "Products")]
        public void NotShouldRegisterProductWithNameEmptyOrNullWithSuccess(string url, string newValue)
        {
            // Arrange
            var client = _factory.CreateClient();
            var objRequest = JsonConvert.SerializeObject(new { Name = newValue });


            // Act
            var response = client.PostAsync(url, new StringContent(objRequest, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();


            // Assert
            response
                .IsSuccessStatusCode
                .Should()
                .BeFalse();

            var productNotCreated = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            productNotCreated
                .Should()
                .NotBeNull();

            productNotCreated
                .Should()
                .Be("PRODUCTNAME_IS_REQUIRED");
        }


        [Theory]
        [InlineData(_urlBase, 1, "Tênis Pumma")]
        [Trait("Basic Tests", "Products")]
        public void ShouldUpdateProductWithSuccess(string url, int id, string newValue)
        {
            // Arrange
            var client = _factory.CreateClient();
            var objRequest = JsonConvert.SerializeObject(new { Name = newValue });
            
            // Obtendo o Produto antes de Atualizar
            var response = client.GetAsync($"{url}/{id}").GetAwaiter().GetResult();

            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue($"Não encontrou produto com o id {id}");

            var productOld = response.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();
                       

            // Act
            response = client.PutAsync($"{url}/{id}", new StringContent(objRequest, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();


            // Assert
            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var productUpdated = response.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();

            productUpdated
                .Should()
                .NotBeNull();

            productUpdated
                .Name
                .Should()
                .NotBe(productOld.Name);
                

        }

        [Theory]
        [InlineData(_urlBase, 1, "Tênis Addidas")]
        [Trait("Basic Tests", "Products")]
        public void ShouldDeleteAProductByIdWithSuccess(string url, int id, string expectedProductName)
        {
            // Arrange
            var client = _factory.CreateClient();


            // Act
            var response = client.DeleteAsync($"{url}/{id}").GetAwaiter().GetResult();


            // Assert
            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var productFound = response.Content.ReadAsAsync<Product>().GetAwaiter().GetResult();

            productFound
                .Should()
                .NotBeNull();

            productFound
                .Name
                .Should()
                .Be(expectedProductName);

            response = client.GetAsync(url).GetAwaiter().GetResult();

            response
                .IsSuccessStatusCode
                .Should()
                .BeTrue();

            var products = response.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();

            products
                .Should()
                .NotContain(new Product() { Id = id, Name = expectedProductName });


        }

    }
}
