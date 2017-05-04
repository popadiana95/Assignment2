
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Furniture
{
    public partial class FormUser : Form
    {
        public int idUser;
        public FormUser(int idUser)
        {
            this.idUser = idUser;
            InitializeComponent();
        }

       public void setDataGridOrders(IList<Order> orderList)
        {
            dataGridViewOrders.DataSource = orderList;
        }
        public void setDataGridProducts(IList<Product> productList)
        {
            dataGridViewProducts.DataSource = productList;
        }
        public void setDataGridOrderDetails(IList<OrderDetail> orderDetailsList)
        {
            dataGridViewOrderDetails.DataSource = orderDetailsList;
        }

        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                Order order = dataGridViewOrders.SelectedRows[0].DataBoundItem as Order;
                if (order != null)
                {
                    textBoxId.Text = order.idOrder.ToString();
                    textBoxCustomer.Text = order.customer;
                    textBoxAddress.Text = order.address;
                    textBoxDate.Text = order.deliveryDate.ToString();
                    textBoxStatus.Text = order.status;
                    textBoxTotal.Text = order.total.ToString();

                }
            }
        }
        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
               Product product = dataGridViewProducts.SelectedRows[0].DataBoundItem as Product;
                if (product != null)
                {

                    textBoxProductID.Text = product.idProduct.ToString();
                    textBoxTitle.Text = product.title;
                    textBoxDescription.Text = product.description;
                    textBoxColor.Text = product.color;
                    textBoxSize.Text = product.size;
                    textBoxPrice.Text = product.price.ToString();
                    textBoxStock.Text = product.stock.ToString();
                   
                }
            }
        }

        public int RetriveQuantity()
        {
            int q = Convert.ToInt32(textBoxQuantity.Text);
            return q;
        }
        public Order RetrieveOrderInformation()
        {
            Order order = new Order();
            order.idOrder = Convert.ToInt32(textBoxId.Text);
            order.customer = textBoxCustomer.Text;
            order.address = textBoxAddress.Text;
            order.deliveryDate = textBoxDate.Value;
            order.status = textBoxStatus.Text;
            order.total = (float)Convert.ToDouble(textBoxTotal.Text);
            return order;
        }
        public Product RetriveProductInformation()
        {
            Product product = new Product();
            product.idProduct = Convert.ToInt32(textBoxProductID.Text);
            product.title = textBoxTitle.Text;
            product.description = textBoxDescription.Text;
            product.color = textBoxColor.Text;
            product.size = textBoxSize.Text;
            product.price = (float)Convert.ToDouble(textBoxPrice.Text);
            product.stock = Convert.ToInt32(textBoxStock.Text);
            return product;
        }
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
       
        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Order order = RetrieveOrderInformation();
            OrderDBManager odbm = new OrderDBManager();
            dataGridViewOrderDetails.DataSource = odbm.getOrderDetails(order, idUser);
        }
       
    }
    }

