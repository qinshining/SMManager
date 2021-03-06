using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Models;

namespace BLL
{
    public class ProductManager
    {
        private ProductService objProductService = new ProductService();
        /// <summary>
        /// 获取商品所有分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetAllCategory()
        {
            return objProductService.GetAllCategory();
        }
        /// <summary>
        /// 获取商品单位
        /// </summary>
        /// <returns></returns>
        public string[] GetAllUnit()
        {
            return objProductService.GetAllUnit();
        }
        /// <summary>
        /// 调用存储过程添加商品信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public int AddProduct(Product objProduct)
        {
            return objProductService.AddProduct(objProduct);
        }
        /// <summary>
        /// 根据商品编号查询商品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(string productId)
        {
            return objProductService.GetProductById(productId);
        }
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addedCount"></param>
        /// <returns>success：代表成功，其他为异常信息</returns>
        public string AddProductCount(string productId, int addedCount, int totalCount)
        {
            if (totalCount + addedCount < 0)
            {
                return $"当前商品数量：{totalCount}，添加后数量不能小于0";
            }
            else
            {
                try
                {
                    objProductService.AddProductCount(productId, addedCount);
                    return "success";
                }
                catch (Exception ex)
                {
                    return "入库过程中发生异常：" + ex.Message;
                }
            }
        }
        /// <summary>
        /// 查询商品信息，返回DataSet
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public DataSet QueryProducts(string productId, string productName, string categoryId)
        {
            if (categoryId == "-1")
            {
                categoryId = string.Empty;
            }
            return objProductService.QueryProducts(productId, productName, categoryId);
        }
    }
}
