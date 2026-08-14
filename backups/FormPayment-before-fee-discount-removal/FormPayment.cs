using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sushi
{
    public partial class FormPayment : Form
    {
        private string orderType;

        private List<CartItem> orderItems = new List<CartItem>();

        private int menuAmout = 0;
        private int deliveryTip = 0;
        private int pickupDiscount = 0;
        private int discoutntAmout = 0;
        private int paymentAmount = 0;
        private bool pickupLayoutReduced = false;

        public FormPayment()
        {
            InitializeComponent();

            cbPay.SelectedIndex = 0;
        }

        public FormPayment(string orderType, List<CartItem> orderItems) : this()
        {
            this.orderType=orderType;
            this.orderItems=orderItems;

            lbOrder.Text = orderType + "주문";

            ShowOrderItems();
            SetOrdertype();
            ShowPaymentAmount();
        }

        private void ShowOrderItems()
        {
            tbOrderMenu.Clear();

            foreach (CartItem item in orderItems)
            {
                string orderLine = item.MenuName +
                    " " +
                    item.Quantity +
                    "개 " +
                    item.TotalPrice.ToString("N0") +
                    "원";

                tbOrderMenu.AppendText(orderLine+Environment.NewLine);
            }
        }

        private void SetOrdertype()
        {
            bool isDelivery = orderType == "배달";

            lbadress.Visible = isDelivery;
            tbaddress.Visible = isDelivery;
            btnAdress.Visible = isDelivery;

            lbDetail.Visible = isDelivery;
            tbdetail.Visible = isDelivery;

            if (isDelivery)
            {
                lbdelivery.Text = "배달팁";

                deliveryTip = 3000;
                pickupDiscount = 0;

                tbaddress.Text = UserSession.DefaultAddress;
            }
            else
            {
                lbdelivery.Text = "포장할인";

                deliveryTip = 0;
                pickupDiscount = 2000;
                tbaddress.Text = "";
                tbdetail.Text = "";

                ReducePickupLayout();
            }
        }

        private void ShowPaymentAmount()
        {
            menuAmout = orderItems.Sum(item => item.TotalPrice);

            discoutntAmout = 0;

            paymentAmount = menuAmout + deliveryTip - pickupDiscount - discoutntAmout;

            if (paymentAmount < 0)
            {
                paymentAmount = 0;
            }

            lbAmount.Text = menuAmout.ToString("N0") + "원";

            if (orderType == "배달")
            {
                lbTip.Text = deliveryTip.ToString("N0") + "원";
            }
            else
            {
                lbTip.Text = "-" + pickupDiscount.ToString("N0") + "원";
            }

            lbCoupon.Text = discoutntAmout.ToString("N0") + "원";
            lbpay.Text = paymentAmount.ToString("N0") + "원";

            btnPay.Text = paymentAmount.ToString("N0") + "원 결제하기";
        }

        private void ReducePickupLayout()
        {
            if (pickupLayoutReduced)
            {
                return;
            }

            pickupLayoutReduced = true;

            int moveup = 75;

            Control[] controlsToMove =
            {
                 label3, tbRequest, label5, cbPay, lbPayInfo, label4, cbCoupon, label6, label9, lbdelivery, label11, label12, lbAmount, lbTip, lbCoupon,lbpay,btnPay
            };

            foreach (Control control in controlsToMove)
            {
                control.Top -= moveup;
            }

            ClientSize = new Size(ClientSize.Width, ClientSize.Height - moveup);
        }
        private void cbPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPayInfo.Items.Clear();

            if (cbPay.SelectedIndex == 0)
            {
                lbPayInfo.Items.Add("카카오페이");
                lbPayInfo.Items.Add("삼성페이");
                lbPayInfo.Items.Add("애플페이");
                lbPayInfo.Items.Add("토스페이");
                lbPayInfo.Items.Add("네이버페이");
            }
            else if (cbPay.SelectedIndex == 1)
            {
                lbPayInfo.Items.Add("국민은행");
                lbPayInfo.Items.Add("우리은행");
                lbPayInfo.Items.Add("신한은행");
                lbPayInfo.Items.Add("기업은행");
                lbPayInfo.Items.Add("농협은행");

                lbPayInfo.SelectedIndex = -1;
            }
        }

        private void btnAdress_Click(object sender, EventArgs e)
        {
            using (FormAddress addressForm = new FormAddress())
            {
                if (addressForm.ShowDialog(this) == DialogResult.OK)
                {
                    tbaddress.Text = addressForm.SelectedAddress;

                    tbaddress.SelectionStart = tbaddress.Text.Length;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(orderType == "배달" && string.IsNullOrWhiteSpace(tbaddress.Text))
            {
                MessageBox.Show("배달주소를 입력해주세요.");

                btnAdress.Focus();
                return;
            }

            if(lbPayInfo.SelectedItem == null)
            {
                MessageBox.Show("결제수단을 선택해주세요.");

                lbPayInfo.Focus();
                return;
            }

            string paymentMethod = lbPayInfo.SelectedItem.ToString()??"";

            OrderRecord newOrder = new OrderRecord();

            newOrder.OrderDate = DateTime.Now;
            newOrder.OrderType = orderType;
            newOrder.PaymentAmount = paymentAmount;
            newOrder.Request = tbRequest.Text.Trim();

            foreach(CartItem item in orderItems)
            {
                newOrder.Items.Add(new CartItem
                {
                    MenuId = item.MenuId,
                    MenuName = item.MenuName,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            OrderStore.Orders.Insert(0,newOrder);

            MessageBox.Show("결제가 완료됐습니다.\n"+"결제수단: " + paymentMethod + "\n" + "결제금액: " + paymentAmount.ToString("N0")+"원");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
