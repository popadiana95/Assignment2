using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Furniture
{
    public class OrderDBManager
    {
       
        private string connString;

        public OrderDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }
        public IList<Order> RetrieveOrders(int idUser)
        {
            IList<Order> OrderList = new List<Order>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM orders";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.idOrder = reader.GetInt32("idOrder");
                        order.customer = reader.GetString("customer");
                        order.address = reader.GetString("address");
                        order.deliveryDate = reader.GetDateTime("deliverydate");
                        order.status = reader.GetString("status");
                        order.total = reader.GetInt32("total");
                        OrderList.Add(order);
                    }
                }
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Get all orders ";
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

            return OrderList;
        }
        public void AddOrder(Order order, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddOrder";
                cmd.Parameters.Add(new MySqlParameter("customerName", order.customer));
                cmd.Parameters.Add(new MySqlParameter("customerAddress", order.address));
                cmd.Parameters.Add(new MySqlParameter("deliverDate", order.deliveryDate));
                cmd.Parameters.Add(new MySqlParameter("orderStatus", order.status));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Add order " + order.idOrder;
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
        public void UpdateOrder(Order order, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateOrder";

                cmd.Parameters.Add(new MySqlParameter("idOrder", order.idOrder));
                cmd.Parameters.Add(new MySqlParameter("customerName", order.customer));
                cmd.Parameters.Add(new MySqlParameter("customerAddress", order.address));
                cmd.Parameters.Add(new MySqlParameter("deliverDate", order.deliveryDate));
                cmd.Parameters.Add(new MySqlParameter("orderStatus", order.status));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Update order " + order.idOrder;
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
        public void DeleteOrder(Order order, int idUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteOrder";
                cmd.Parameters.Add(new MySqlParameter("idOrder", order.idOrder));        
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                DateTime dataNow = DateTime.Now;
                string descriptionMessage = "Delete order " + order.idOrder;
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

        public IList<OrderDetail> getOrderDetails(Order order, int idUser)
        {
            IList<OrderDetail> orderDerailList = new List<OrderDetail>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM orderdetails where orderdetails.idOrder = " + order.idOrder;

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.idOrder = reader.GetInt32("idOrder");
                        orderDetail.idProduct = reader.GetInt32("idProduct");
                        orderDetail.priceUnit = (float)reader.GetDouble("priceunit");
                        orderDetail.quantity = reader.GetInt32("quantity");
                        orderDetail.price = (float)reader.GetDouble("price");
                        Console.Write("" + orderDetail.idOrder + orderDetail.idProduct + "/n");
                        orderDerailList.Add(orderDetail);
                    }
                }
                conn.Close();

                       conn.Open();
                        DateTime dataNow = DateTime.Now;
                        string descriptionMessage = "Get order " + order.idOrder + " details";
                        cmd = new MySqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "InsertActivity";
                        cmd.Parameters.Add(new MySqlParameter("idUser", idUser));
                        cmd.Parameters.Add(new MySqlParameter("dataNow", dataNow));
                        cmd.Parameters.Add(new MySqlParameter("descr", descriptionMessage));
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    

                return orderDerailList;
            }
        }
        public void AddProductToOrder(Order order, Product product, int quantity, int idUser)
        {
            
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddProductToOrder";

                    cmd.Parameters.Add(new MySqlParameter("idOrder", order.idOrder));
                    cmd.Parameters.Add(new MySqlParameter("idProduct", product.idProduct));
                    cmd.Parameters.Add(new MySqlParameter("quantity", quantity));
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    DateTime dataNow = DateTime.Now;
                    string descriptionMessage = "Add product " + product.idProduct + " to order " + order.idOrder;
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
