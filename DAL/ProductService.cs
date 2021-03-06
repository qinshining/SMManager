using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 商品数据访问类
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// 获取商品所有分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetAllCategory()
        {
            string sql = "SELECT CategoryId,CategoryName FROM ProductCategory";
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<ProductCategory> list = new List<ProductCategory>();
            while (reader.Read())
            {
                list.Add(new ProductCategory()
                {
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString()
                });
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 获取商品单位
        /// </summary>
        /// <returns></returns>
        public string[] GetAllUnit()
        {
            string sql = "SELECT Unit FROM ProductUnit";
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<string> unitList = new List<string>();
            while (reader.Read())
            {
                unitList.Add(reader["Unit"].ToString());
            }
            reader.Close();
            return unitList.ToArray();
        }
        /// <summary>
        /// 调用存储过程添加商品信息
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public int AddProduct(Product objProduct)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId", objProduct.ProductId),
                new SqlParameter("@ProductName", objProduct.ProductName),
                new SqlParameter("@UnitPrice", objProduct.UnitPrice),
                new SqlParameter("@Unit", objProduct.Unit),
                new SqlParameter("@CategoryId", objProduct.CategoryId),
                new SqlParameter("@MinCount", objProduct.MinCount),
                new SqlParameter("@MaxCount", objProduct.MaxCount),
            };
            return SqlHelper.UpdateByProc("usp_AddProducts", param);
        }
        /// <summary>
        /// 根据商品编号查询商品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(string productId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId", productId)
            };
            SqlDataReader reader = SqlHelper.GetReaderByProc("usp_QueryProductById", param);
            Product objProduct = null;
            if (reader.Read())
            {
                objProduct = new Product()
                {
                    ProductId = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    Discount = Convert.ToInt32(reader["Discount"]),
                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                    CategoryName = reader["CategoryName"].ToString(),
                    TotalCount = Convert.ToInt32(reader["TotalCount"])
                };
            }
            reader.Close();
            return objProduct;
        }
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addedCount"></param>
        /// <returns></returns>
        public int AddProductCount(string productId, int addedCount)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@AddedCount", addedCount)
            };
            return SqlHelper.UpdateByProc("usp_AddProductInventory", param);
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
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT ProductId,ProductName,Unit,UnitPrice,Discount,CategoryId,CategoryName,TotalCount,MaxCount,MinCount,InventoryStatus FROM view_ProductsInfo WHERE 1 = 1");
            if (productId != null && productId.Length > 0)
            {
                sqlBuilder.AppendFormat(" AND ProductId LIKE '{0}%'", productId);
            }
            if (productName != null && productName.Length > 0)
            {
                sqlBuilder.AppendFormat(" AND ProductName LIKE '{0}%'", productName);
            }
            if (categoryId != null && categoryId.Length > 0)
            {
                sqlBuilder.AppendFormat(" AND CategoryId = '{0}'", categoryId);
            }
            return SqlHelper.GetDataSet(sqlBuilder.ToString());
        }
    }
}
