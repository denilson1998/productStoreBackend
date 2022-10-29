using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productStoreBackend.Data;
using productStoreBackend.Models.responseModel;
using Microsoft.EntityFrameworkCore;
using productStoreBackend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace productStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase 
    {
        private readonly dataContext _dataContext;

        ivaController ivaController = new ivaController();

        public productController(dataContext dataContext)
        {
            this._dataContext = dataContext;
            
        }

        [HttpGet("getProducts")]
        public async Task<JsonResult> getProducts()
        {
            try
            {
                List<storeModel> stores = new List<storeModel>();


                List<productModel> products = new List<productModel>();

                List<productStoreModel> prodStore = new List<productStoreModel>();

                List<respProductStoreModel> respPrSt = new List<respProductStoreModel>();

                stores = await _dataContext.stores.ToListAsync();

                products = await _dataContext.products.ToListAsync();

                prodStore = await _dataContext.productStore.ToListAsync();

               
                    foreach (var product in products)
                    {
                   

                        foreach (var store in stores)
                        {
                            foreach (var productStore in prodStore)
                            {
                                respProductStoreModel obj = new respProductStoreModel();
                                if (store.id == productStore.idStore && product.cod == productStore.codProduct)
                                {
                                    obj.cod = product.cod;
                                    obj.description = product.description;
                                    obj.price = product.price;
                                    obj.stock = productStore.stock;
                                    obj.idStore = productStore.idStore;
                                    obj.nameStore = store.name;
                                    respPrSt.Add(obj);
                                }
                            }
                        }
                    }

                responseModel resp = new responseModel { state = 1, message = "List of Products", detail = respPrSt };

                return new JsonResult(resp);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("saveProduct")]
        public async Task<JsonResult> saveProduct(int stock, int idStore, productModel product)
        {
            try
            {
                List<productModel> dataSaved = new List<productModel>();

                _dataContext.Database.ExecuteSqlRaw("saveProduct {0},{1},{2},{3},{4}",product.cod, product.description, product.price, stock, idStore);
                _dataContext.SaveChanges();
                dataSaved.Add(product);

                responseModel resp = new responseModel { state = 1, message = "Product Save successfully!", detail =  dataSaved};

                return new JsonResult(resp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPut("updateProduct")]
        public async Task<JsonResult> updateProduct(updateProductModel updateProduct)
        {
            try
            {
                List<updateProductModel> dataUpdate = new List<updateProductModel>();

                _dataContext.Database.ExecuteSqlRaw("updateProduct {0},{1},{2},{3},{4}", updateProduct.cod, updateProduct.description, updateProduct.price, updateProduct.stock, updateProduct.idStore);
                _dataContext.SaveChanges();
                dataUpdate.Add(updateProduct);

                responseModel resp = new responseModel { state = 1, message = "Product Updated successfully!", detail = dataUpdate };

                return new JsonResult(resp);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("deleteProduct")]
        public async Task<JsonResult> deleteProduct(string cod, int idStore)
        {
            try
            {

                _dataContext.Database.ExecuteSqlRaw("deleteProduct {0},{1}", cod, idStore);
                _dataContext.SaveChanges();
                

                responseModel resp = new responseModel { state = 1, message = "Product Deleted successfully!", detail = null };

                return new JsonResult(resp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("addProductToCard")]
        public async Task<JsonResult> addProductToCard(addProductCardModel productCard)
        {
            try
            {
                _dataContext.Database.ExecuteSqlRaw("addProductToCard {0},{1},{2},{3}", productCard.cod, productCard.idStore, productCard.userId, productCard.amount);
                _dataContext.SaveChanges();
                responseModel resp = new responseModel { state = 1, message = "Product Add Successfully!", detail = null };

                return new JsonResult(resp);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("payment")]
        public async Task<JsonResult> payment(int cardId, int userId)
        {
            try
            {
                cardModel card = new cardModel();

                card = await _dataContext.storeCard.FindAsync(cardId);

                
                decimal totalIva = ivaController.ivaBolivia(card.total);

                card.totalIva = totalIva;
                _dataContext.SaveChanges();

                responseModel resp = new responseModel { state = 1, message = "Paid Product with Iva Successfully!", detail = card };

                return new JsonResult(resp);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
