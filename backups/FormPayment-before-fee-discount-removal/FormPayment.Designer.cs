namespace sushi
{
    partial class FormPayment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbOrderMenu = new TextBox();
            lbOrder = new Label();
            lbadress = new Label();
            tbaddress = new TextBox();
            btnAdress = new Button();
            label3 = new Label();
            tbRequest = new TextBox();
            cbPay = new ComboBox();
            lbPayInfo = new ListBox();
            cbCoupon = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lbdelivery = new Label();
            label11 = new Label();
            label12 = new Label();
            lbAmount = new Label();
            lbTip = new Label();
            lbCoupon = new Label();
            lbpay = new Label();
            btnPay = new Button();
            lbDetail = new Label();
            tbdetail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(124, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "주문하기";
            // 
            // tbOrderMenu
            // 
            tbOrderMenu.Location = new Point(1, 90);
            tbOrderMenu.Multiline = true;
            tbOrderMenu.Name = "tbOrderMenu";
            tbOrderMenu.ReadOnly = true;
            tbOrderMenu.ScrollBars = ScrollBars.Vertical;
            tbOrderMenu.Size = new Size(351, 126);
            tbOrderMenu.TabIndex = 1;
            // 
            // lbOrder
            // 
            lbOrder.AutoSize = true;
            lbOrder.Location = new Point(3, 39);
            lbOrder.Name = "lbOrder";
            lbOrder.Size = new Size(55, 15);
            lbOrder.TabIndex = 2;
            lbOrder.Text = "주문방법";
            // 
            // lbadress
            // 
            lbadress.AutoSize = true;
            lbadress.Location = new Point(4, 237);
            lbadress.Name = "lbadress";
            lbadress.Size = new Size(55, 15);
            lbadress.TabIndex = 3;
            lbadress.Text = "배달주소";
            // 
            // tbaddress
            // 
            tbaddress.Location = new Point(63, 233);
            tbaddress.Name = "tbaddress";
            tbaddress.Size = new Size(207, 23);
            tbaddress.TabIndex = 4;
            // 
            // btnAdress
            // 
            btnAdress.Location = new Point(278, 232);
            btnAdress.Name = "btnAdress";
            btnAdress.Size = new Size(73, 25);
            btnAdress.TabIndex = 5;
            btnAdress.Text = "주소검색";
            btnAdress.UseVisualStyleBackColor = true;
            btnAdress.Click += btnAdress_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 310);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "요청사항";
            // 
            // tbRequest
            // 
            tbRequest.Location = new Point(64, 307);
            tbRequest.Multiline = true;
            tbRequest.Name = "tbRequest";
            tbRequest.Size = new Size(255, 84);
            tbRequest.TabIndex = 6;
            // 
            // cbPay
            // 
            cbPay.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPay.FormattingEnabled = true;
            cbPay.Items.AddRange(new object[] { "간편결제", "신용/체크카드" });
            cbPay.Location = new Point(76, 411);
            cbPay.Name = "cbPay";
            cbPay.Size = new Size(103, 23);
            cbPay.TabIndex = 7;
            cbPay.SelectedIndexChanged += cbPay_SelectedIndexChanged;
            // 
            // lbPayInfo
            // 
            lbPayInfo.FormattingEnabled = true;
            lbPayInfo.ItemHeight = 15;
            lbPayInfo.Location = new Point(194, 410);
            lbPayInfo.Name = "lbPayInfo";
            lbPayInfo.Size = new Size(120, 79);
            lbPayInfo.TabIndex = 8;
            // 
            // cbCoupon
            // 
            cbCoupon.FormattingEnabled = true;
            cbCoupon.Location = new Point(81, 507);
            cbCoupon.Name = "cbCoupon";
            cbCoupon.Size = new Size(233, 23);
            cbCoupon.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 510);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 10;
            label4.Text = "할인쿠폰";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 414);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 11;
            label5.Text = "결제수단";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-5, 535);
            label6.Name = "label6";
            label6.Size = new Size(367, 15);
            label6.TabIndex = 10;
            label6.Text = "------------------------------------------------------------------------";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 70);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 2;
            label7.Text = "담은 메뉴";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(-5, 54);
            label8.Name = "label8";
            label8.Size = new Size(362, 15);
            label8.TabIndex = 12;
            label8.Text = "-----------------------------------------------------------------------";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(33, 566);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 13;
            label9.Text = "메뉴금액";
            // 
            // lbdelivery
            // 
            lbdelivery.AutoSize = true;
            lbdelivery.Location = new Point(33, 601);
            lbdelivery.Name = "lbdelivery";
            lbdelivery.Size = new Size(43, 15);
            lbdelivery.TabIndex = 13;
            lbdelivery.Text = "배달팁";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(33, 636);
            label11.Name = "label11";
            label11.Size = new Size(55, 15);
            label11.TabIndex = 13;
            label11.Text = "할인금액";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(33, 672);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 13;
            label12.Text = "결제금액";
            // 
            // lbAmount
            // 
            lbAmount.AutoSize = true;
            lbAmount.Location = new Point(237, 566);
            lbAmount.Name = "lbAmount";
            lbAmount.Size = new Size(39, 15);
            lbAmount.TabIndex = 13;
            lbAmount.Text = "label9";
            // 
            // lbTip
            // 
            lbTip.AutoSize = true;
            lbTip.Location = new Point(237, 601);
            lbTip.Name = "lbTip";
            lbTip.Size = new Size(39, 15);
            lbTip.TabIndex = 13;
            lbTip.Text = "label9";
            // 
            // lbCoupon
            // 
            lbCoupon.AutoSize = true;
            lbCoupon.Location = new Point(237, 636);
            lbCoupon.Name = "lbCoupon";
            lbCoupon.Size = new Size(39, 15);
            lbCoupon.TabIndex = 13;
            lbCoupon.Text = "label9";
            // 
            // lbpay
            // 
            lbpay.AutoSize = true;
            lbpay.Location = new Point(237, 672);
            lbpay.Name = "lbpay";
            lbpay.Size = new Size(39, 15);
            lbpay.TabIndex = 13;
            lbpay.Text = "label9";
            // 
            // btnPay
            // 
            btnPay.Location = new Point(81, 709);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(189, 52);
            btnPay.TabIndex = 14;
            btnPay.Text = "button2";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // lbDetail
            // 
            lbDetail.AutoSize = true;
            lbDetail.Location = new Point(4, 269);
            lbDetail.Name = "lbDetail";
            lbDetail.Size = new Size(55, 15);
            lbDetail.TabIndex = 15;
            lbDetail.Text = "상세주소";
            // 
            // tbdetail
            // 
            tbdetail.Location = new Point(63, 266);
            tbdetail.Name = "tbdetail";
            tbdetail.Size = new Size(207, 23);
            tbdetail.TabIndex = 16;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 761);
            Controls.Add(tbdetail);
            Controls.Add(lbDetail);
            Controls.Add(btnPay);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(lbpay);
            Controls.Add(lbCoupon);
            Controls.Add(lbTip);
            Controls.Add(lbdelivery);
            Controls.Add(lbAmount);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(cbCoupon);
            Controls.Add(lbPayInfo);
            Controls.Add(cbPay);
            Controls.Add(tbRequest);
            Controls.Add(btnAdress);
            Controls.Add(tbaddress);
            Controls.Add(label3);
            Controls.Add(lbadress);
            Controls.Add(label7);
            Controls.Add(lbOrder);
            Controls.Add(tbOrderMenu);
            Controls.Add(label1);
            Name = "FormPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbOrderMenu;
        private Label lbOrder;
        private Label lbadress;
        private TextBox tbaddress;
        private Button btnAdress;
        private Label label3;
        private TextBox tbRequest;
        private ComboBox cbPay;
        private ListBox lbPayInfo;
        private ComboBox cbCoupon;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lbdelivery;
        private Label label11;
        private Label label12;
        private Label lbAmount;
        private Label lbTip;
        private Label lbCoupon;
        private Label lbpay;
        private Button btnPay;
        private Label lbDetail;
        private TextBox tbdetail;
    }
}
