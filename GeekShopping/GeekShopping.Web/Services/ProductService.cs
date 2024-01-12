using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient? _client;
        public const string BasePath = "api/v1/product";
        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            if (_client != null)
            {
                var response = await _client.GetAsync(BasePath);
                return await response.ReadContentAs<List<ProductModel>>();
            }
            else
            {
                throw new Exception("something wrong");
            }
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            if (_client != null)
            {
                var response = await _client.GetAsync($"{BasePath}/{id}");
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("something wrong");
            }
        }

        public Task<ProductModel> CreateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductById(long id)
        {
            throw new NotImplementedException();
        }

    }
}
