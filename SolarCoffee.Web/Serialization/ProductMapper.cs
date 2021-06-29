using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps a Product data model to ProductModel view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductModel SerializeProductModel(Data.Models.Product product) {
            return new ProductModel {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Name = product.Name,
                Descripton = product.Descripton,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived            
            };
        }

        /// <summary>
        /// Maps a ProductModel view model to Product data model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Data.Models.Product SerializeProductModel(ProductModel product) {
            return new Data.Models.Product {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Name = product.Name,
                Descripton = product.Descripton,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived            
            };
        }
    }
}