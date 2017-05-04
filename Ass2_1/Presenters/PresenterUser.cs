using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture
{
    public class PresenterUser
    {
        private FormUser FormU;
        private OrderDBManager odbm;
        private ProductDBManager pdbm;
        private Orders orders;
        private int idUser;
        public PresenterUser(int id)
        {
            this.idUser = id;
            odbm = new OrderDBManager();
            orders = new Orders();
            pdbm = new ProductDBManager();
            FormU = new FormUser(idUser);
            FormU.buttonGet.Click += viewAllOrders;
            FormU.editBtn.Click += UpdateOrder;
            FormU.deleteBtn.Click += DeleteOrder;
            FormU.buttonAddOrder.Click += AddOrder;
            FormU.buttonViewProducts.Click += ViewProducts;
            FormU.buttonEditProduct.Click += EditProduct;
            FormU.buttonAddProduct.Click += AddProduct;
            FormU.buttonDeleteProduct.Click += DeleteProduct;
            FormU.buttonAddProductToOrder.Click += AddProductToOrder;
            FormU.Show();
        }
        private void viewAllOrders(object sender, EventArgs e)
        {
           
            IList<Order> orderList = odbm.RetrieveOrders(idUser);
            FormU.setDataGridOrders(orderList);
        }

       
        private void UpdateOrder(object sender, EventArgs e)
        {
                Order order = FormU.RetrieveOrderInformation();
                odbm.UpdateOrder(order, idUser);
        }

        private void DeleteOrder(object sender, EventArgs e)
        {
            try
            {
                Order order = FormU.RetrieveOrderInformation();
                odbm.DeleteOrder(order, idUser);

            }
            catch (Exception ex)
            {
                FormU.ShowMessage(ex.Message);
                throw;
            }
        }


        private void ViewProducts(object sender, EventArgs e)
        {
            try
            {
                IList<Product> productList = pdbm.RetrieveProducts(idUser);
                FormU.setDataGridProducts(productList);

            }
            catch (Exception ex)
            {
                FormU.ShowMessage(ex.Message);
            }
        }

        private void EditProduct(object sender, EventArgs e)
        {
            try
            {
                Product product = FormU.RetriveProductInformation();
                pdbm = new ProductDBManager();
                pdbm.UpdateProduct(product, idUser);

            }
            catch (Exception ex)
            {
                FormU.ShowMessage(ex.Message);
                throw;
            }
        }

        private void AddProduct(object sender, EventArgs e)
        {
            try
            {
                Product product = FormU.RetriveProductInformation();
                pdbm = new ProductDBManager();
                pdbm.AddProduct(product, idUser);

            }
            catch (Exception ex)
            {
                FormU.ShowMessage(ex.Message);
                throw;
            }
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            try
            {
                Product product = FormU.RetriveProductInformation();
                pdbm = new ProductDBManager();
                pdbm.DeleteProduct(product, idUser);

            }
            catch (Exception ex)
            {
                FormU.ShowMessage(ex.Message);
                throw;
            }
        }

        private void setDataGridViewOrderDetails(object sender, DataGridViewCellEventArgs e)
        {
            Order order = FormU.RetrieveOrderInformation();
            IList<OrderDetail> orderDetails = odbm.getOrderDetails(order, idUser);
        }

        private void AddProductToOrder(object sender, EventArgs e)
        {
            Order order = FormU.RetrieveOrderInformation();
            Product product = FormU.RetriveProductInformation();
            int q = FormU.RetriveQuantity();
            string message = orders.addProduct(order, product, q, idUser);
            FormU.ShowMessage(message);
        }

        private void AddOrder(object sender, EventArgs e)
        {
            Order order = FormU.RetrieveOrderInformation();
            odbm.AddOrder(order, idUser);
        }
    }
}
