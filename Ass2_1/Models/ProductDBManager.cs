using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Furniture
{
    public class ProductDBManager
    {
        private string connString;

        public ProductDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public IList<Product> RetrieveProducts(int idUser)
        {
            IList<Product> ProductList = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM product";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.idProduct = reader.GetInt32("idProduct");
                        product.title = reader.GetString("title");
                        product.description = reader.GetString("description");
                        product.color = reader.GetString("color");
                        product.size = reader.GetString("size");
                        product.price = reader.GetFloat("price");
                        product.stock = reader.GetInt32("stock");
                        ProductList.Add(product);
                    }
                }
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Get all products ";
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertActivity";
                cmd.Parameters.Add(new MySqlParameter("idUser", idUser));
                cmd.Parameters.Add(new MySqlParameter("dataNow", dataNow));
                cmd.Parameters.Add(new MySqlParameter("descr", descriptionMessage));
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return ProductList;
        }

        public void AddProduct(Product product, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddProduct";
    
                cmd.Parameters.Add(new MySqlParameter("idProduct", product.idProduct));
                cmd.Parameters.Add(new MySqlParameter("title", product.title));
                cmd.Parameters.Add(new MySqlParameter("description", product.description));
                cmd.Parameters.Add(new MySqlParameter("color", product.color));
                cmd.Parameters.Add(new MySqlParameter("size", product.size));
                cmd.Parameters.Add(new MySqlParameter("price", product.price));
                cmd.Parameters.Add(new MySqlParameter("stock", product.stock));

                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Add new product order " + product.idProduct;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertActivity";
                cmd.Parameters.Add(new MySqlParameter("idUser", idUser));
                cmd.Parameters.Add(new MySqlParameter("dataNow", dataNow));
                cmd.Parameters.Add(new MySqlParameter("descr", descriptionMessage));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdateProduct(Product product, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProduct";

                cmd.Parameters.Add(new MySqlParameter("idProduct", product.idProduct));
                cmd.Parameters.Add(new MySqlParameter("title", product.title));
                cmd.Parameters.Add(new MySqlParameter("description", product.description));
                cmd.Parameters.Add(new MySqlParameter("color", product.color));
                cmd.Parameters.Add(new MySqlParameter("size", product.size));
                cmd.Parameters.Add(new MySqlParameter("price", product.price));
                cmd.Parameters.Add(new MySqlParameter("stock", product.stock));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Update product " +product.idProduct;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertActivity";
                cmd.Parameters.Add(new MySqlParameter("idUser", idUser));
                cmd.Parameters.Add(new MySqlParameter("dataNow", dataNow));
                cmd.Parameters.Add(new MySqlParameter("descr", descriptionMessage));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteProduct(Product product, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteProduct";

                cmd.Parameters.Add(new MySqlParameter("idProduct", product.idProduct));

                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Delete product " +product.idProduct;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertActivity";
                cmd.Parameters.Add(new MySqlParameter("idUser", idUser));
                cmd.Parameters.Add(new MySqlParameter("dataNow", dataNow));
                cmd.Parameters.Add(new MySqlParameter("descr", descriptionMessage));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
