namespace ADCinvoice
{
    partial class InvoiceForm
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
            this.components = new System.ComponentModel.Container();
            this.invoicePath = new System.Windows.Forms.TextBox();
            this.readBox = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.viewBlock = new System.Windows.Forms.GroupBox();
            this.waitLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invoiceDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ocrReference = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.payDate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.totalAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.rounded = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.taxAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.priceBeforeTax = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.currency = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.financialBox = new System.Windows.Forms.GroupBox();
            this.taxInPercent = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.insuranceNumber = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.objectReference = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.plusgiroNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.bankgiroNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.organizationReference = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.vatNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ibanNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.providerBox = new System.Windows.Forms.GroupBox();
            this.providerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.providerPhone = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.providerCountry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.providerCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.providerPostalIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.providerAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.providerWebb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.receiverBox = new System.Windows.Forms.GroupBox();
            this.receiverName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.receiverCountry = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.receiverCity = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.receiverPostalIndex = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.receiverAddress = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.GroupBox();
            this.messageIOBox = new System.Windows.Forms.TextBox();
            this.trashBlock = new System.Windows.Forms.GroupBox();
            this.trashBoxReal = new System.Windows.Forms.TextBox();
            this.invoiceBox = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.zoomBox = new System.Windows.Forms.PictureBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.getBtn = new System.Windows.Forms.Button();
            this.readBox.SuspendLayout();
            this.viewBlock.SuspendLayout();
            this.resultBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.financialBox.SuspendLayout();
            this.providerBox.SuspendLayout();
            this.receiverBox.SuspendLayout();
            this.messageBox.SuspendLayout();
            this.trashBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBox)).BeginInit();
            this.SuspendLayout();
            // 
            // invoicePath
            // 
            this.invoicePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoicePath.Enabled = false;
            this.invoicePath.Location = new System.Drawing.Point(128, 20);
            this.invoicePath.Name = "invoicePath";
            this.invoicePath.Size = new System.Drawing.Size(866, 20);
            this.invoicePath.TabIndex = 3;
            // 
            // readBox
            // 
            this.readBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readBox.Controls.Add(this.button1);
            this.readBox.Controls.Add(this.openBtn);
            this.readBox.Controls.Add(this.timeLabel);
            this.readBox.Controls.Add(this.viewBlock);
            this.readBox.Controls.Add(this.invoicePath);
            this.readBox.Controls.Add(this.resultBox);
            this.readBox.Controls.Add(this.loadBtn);
            this.readBox.Controls.Add(this.saveBtn);
            this.readBox.Controls.Add(this.getBtn);
            this.readBox.Location = new System.Drawing.Point(23, 0);
            this.readBox.MinimumSize = new System.Drawing.Size(356, 573);
            this.readBox.Name = "readBox";
            this.readBox.Size = new System.Drawing.Size(1008, 770);
            this.readBox.TabIndex = 6;
            this.readBox.TabStop = false;
            this.readBox.Text = "Read Invoice";
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(856, 50);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(133, 13);
            this.timeLabel.TabIndex = 8;
            this.timeLabel.Text = "Last run time : Not Defined";
            // 
            // viewBlock
            // 
            this.viewBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewBlock.Controls.Add(this.waitLabel);
            this.viewBlock.Controls.Add(this.progressBar1);
            this.viewBlock.Controls.Add(this.zoomBox);
            this.viewBlock.Location = new System.Drawing.Point(122, 66);
            this.viewBlock.Name = "viewBlock";
            this.viewBlock.Size = new System.Drawing.Size(872, 147);
            this.viewBlock.TabIndex = 7;
            this.viewBlock.TabStop = false;
            this.viewBlock.Text = "Welcome";
            // 
            // waitLabel
            // 
            this.waitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waitLabel.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLabel.Location = new System.Drawing.Point(7, 16);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(857, 93);
            this.waitLabel.TabIndex = 9;
            this.waitLabel.Text = "Load scanned invoice image to continue . .";
            this.waitLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(12, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(848, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.Controls.Add(this.flowLayoutPanel1);
            this.resultBox.Location = new System.Drawing.Point(6, 219);
            this.resultBox.MaximumSize = new System.Drawing.Size(988, 636);
            this.resultBox.Name = "resultBox";
            this.resultBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resultBox.Size = new System.Drawing.Size(988, 545);
            this.resultBox.TabIndex = 6;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Result";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.financialBox);
            this.flowLayoutPanel1.Controls.Add(this.providerBox);
            this.flowLayoutPanel1.Controls.Add(this.receiverBox);
            this.flowLayoutPanel1.Controls.Add(this.messageBox);
            this.flowLayoutPanel1.Controls.Add(this.trashBlock);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(341, 313);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(979, 520);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.invoiceDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ocrReference);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.payDate);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.totalAmount);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.rounded);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.taxAmount);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.priceBeforeTax);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.currency);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.MinimumSize = new System.Drawing.Size(318, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(318, 309);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bookkeeping details";
            // 
            // invoiceDate
            // 
            this.invoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceDate.Location = new System.Drawing.Point(107, 99);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.invoiceDate.Size = new System.Drawing.Size(194, 20);
            this.invoiceDate.TabIndex = 18;
            this.invoiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Invoice created";
            // 
            // ocrReference
            // 
            this.ocrReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ocrReference.Location = new System.Drawing.Point(107, 28);
            this.ocrReference.Name = "ocrReference";
            this.ocrReference.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ocrReference.Size = new System.Drawing.Size(194, 20);
            this.ocrReference.TabIndex = 16;
            this.ocrReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Reference";
            // 
            // payDate
            // 
            this.payDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.payDate.Location = new System.Drawing.Point(107, 64);
            this.payDate.Name = "payDate";
            this.payDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.payDate.Size = new System.Drawing.Size(194, 20);
            this.payDate.TabIndex = 14;
            this.payDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Pay day";
            // 
            // totalAmount
            // 
            this.totalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalAmount.Location = new System.Drawing.Point(107, 275);
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalAmount.Size = new System.Drawing.Size(194, 20);
            this.totalAmount.TabIndex = 12;
            this.totalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 278);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Total amount";
            // 
            // rounded
            // 
            this.rounded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rounded.Location = new System.Drawing.Point(107, 240);
            this.rounded.Name = "rounded";
            this.rounded.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rounded.Size = new System.Drawing.Size(194, 20);
            this.rounded.TabIndex = 10;
            this.rounded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Rounded";
            // 
            // taxAmount
            // 
            this.taxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.taxAmount.Location = new System.Drawing.Point(107, 205);
            this.taxAmount.Name = "taxAmount";
            this.taxAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.taxAmount.Size = new System.Drawing.Size(194, 20);
            this.taxAmount.TabIndex = 8;
            this.taxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "Tax";
            // 
            // priceBeforeTax
            // 
            this.priceBeforeTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceBeforeTax.Location = new System.Drawing.Point(107, 169);
            this.priceBeforeTax.Name = "priceBeforeTax";
            this.priceBeforeTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.priceBeforeTax.Size = new System.Drawing.Size(194, 20);
            this.priceBeforeTax.TabIndex = 6;
            this.priceBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "Price before tax";
            // 
            // currency
            // 
            this.currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currency.Location = new System.Drawing.Point(107, 134);
            this.currency.Name = "currency";
            this.currency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currency.Size = new System.Drawing.Size(194, 20);
            this.currency.TabIndex = 4;
            this.currency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 137);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Currency";
            // 
            // financialBox
            // 
            this.financialBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.financialBox.Controls.Add(this.taxInPercent);
            this.financialBox.Controls.Add(this.label27);
            this.financialBox.Controls.Add(this.insuranceNumber);
            this.financialBox.Controls.Add(this.label26);
            this.financialBox.Controls.Add(this.objectReference);
            this.financialBox.Controls.Add(this.label8);
            this.financialBox.Controls.Add(this.plusgiroNumber);
            this.financialBox.Controls.Add(this.label14);
            this.financialBox.Controls.Add(this.bankgiroNumber);
            this.financialBox.Controls.Add(this.label13);
            this.financialBox.Controls.Add(this.organizationReference);
            this.financialBox.Controls.Add(this.label12);
            this.financialBox.Controls.Add(this.vatNumber);
            this.financialBox.Controls.Add(this.label11);
            this.financialBox.Controls.Add(this.ibanNumber);
            this.financialBox.Controls.Add(this.label10);
            this.financialBox.Location = new System.Drawing.Point(321, 1);
            this.financialBox.Margin = new System.Windows.Forms.Padding(1);
            this.financialBox.MinimumSize = new System.Drawing.Size(318, 309);
            this.financialBox.Name = "financialBox";
            this.financialBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.financialBox.Size = new System.Drawing.Size(318, 309);
            this.financialBox.TabIndex = 9;
            this.financialBox.TabStop = false;
            this.financialBox.Text = "Financial information";
            // 
            // taxInPercent
            // 
            this.taxInPercent.Location = new System.Drawing.Point(106, 205);
            this.taxInPercent.Name = "taxInPercent";
            this.taxInPercent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.taxInPercent.Size = new System.Drawing.Size(194, 20);
            this.taxInPercent.TabIndex = 32;
            this.taxInPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 208);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label27.Size = new System.Drawing.Size(75, 13);
            this.label27.TabIndex = 33;
            this.label27.Text = "Tax in percent";
            // 
            // insuranceNumber
            // 
            this.insuranceNumber.Location = new System.Drawing.Point(106, 169);
            this.insuranceNumber.Name = "insuranceNumber";
            this.insuranceNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.insuranceNumber.Size = new System.Drawing.Size(194, 20);
            this.insuranceNumber.TabIndex = 30;
            this.insuranceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(20, 172);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 31;
            this.label26.Text = "Insurance nr";
            // 
            // objectReference
            // 
            this.objectReference.Location = new System.Drawing.Point(106, 134);
            this.objectReference.Name = "objectReference";
            this.objectReference.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.objectReference.Size = new System.Drawing.Size(194, 20);
            this.objectReference.TabIndex = 28;
            this.objectReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Object nr";
            // 
            // plusgiroNumber
            // 
            this.plusgiroNumber.Location = new System.Drawing.Point(106, 275);
            this.plusgiroNumber.Name = "plusgiroNumber";
            this.plusgiroNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.plusgiroNumber.Size = new System.Drawing.Size(194, 20);
            this.plusgiroNumber.TabIndex = 26;
            this.plusgiroNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "PlusGiro";
            // 
            // bankgiroNumber
            // 
            this.bankgiroNumber.Location = new System.Drawing.Point(106, 240);
            this.bankgiroNumber.Name = "bankgiroNumber";
            this.bankgiroNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bankgiroNumber.Size = new System.Drawing.Size(194, 20);
            this.bankgiroNumber.TabIndex = 24;
            this.bankgiroNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "BankGiro";
            // 
            // organizationReference
            // 
            this.organizationReference.Location = new System.Drawing.Point(106, 99);
            this.organizationReference.Name = "organizationReference";
            this.organizationReference.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.organizationReference.Size = new System.Drawing.Size(194, 20);
            this.organizationReference.TabIndex = 22;
            this.organizationReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Organization ref";
            // 
            // vatNumber
            // 
            this.vatNumber.Location = new System.Drawing.Point(106, 64);
            this.vatNumber.Name = "vatNumber";
            this.vatNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.vatNumber.Size = new System.Drawing.Size(194, 20);
            this.vatNumber.TabIndex = 20;
            this.vatNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "VAT";
            // 
            // ibanNumber
            // 
            this.ibanNumber.Location = new System.Drawing.Point(106, 28);
            this.ibanNumber.Name = "ibanNumber";
            this.ibanNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ibanNumber.Size = new System.Drawing.Size(194, 20);
            this.ibanNumber.TabIndex = 18;
            this.ibanNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "IBAN";
            // 
            // providerBox
            // 
            this.providerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.providerBox.Controls.Add(this.providerName);
            this.providerBox.Controls.Add(this.label9);
            this.providerBox.Controls.Add(this.providerPhone);
            this.providerBox.Controls.Add(this.label99);
            this.providerBox.Controls.Add(this.providerCountry);
            this.providerBox.Controls.Add(this.label7);
            this.providerBox.Controls.Add(this.providerCity);
            this.providerBox.Controls.Add(this.label6);
            this.providerBox.Controls.Add(this.providerPostalIndex);
            this.providerBox.Controls.Add(this.label5);
            this.providerBox.Controls.Add(this.providerAddress);
            this.providerBox.Controls.Add(this.label4);
            this.providerBox.Controls.Add(this.providerWebb);
            this.providerBox.Controls.Add(this.label2);
            this.providerBox.Location = new System.Drawing.Point(641, 1);
            this.providerBox.Margin = new System.Windows.Forms.Padding(1);
            this.providerBox.MinimumSize = new System.Drawing.Size(318, 278);
            this.providerBox.Name = "providerBox";
            this.providerBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.providerBox.Size = new System.Drawing.Size(318, 309);
            this.providerBox.TabIndex = 8;
            this.providerBox.TabStop = false;
            this.providerBox.Text = "Service Provider information";
            // 
            // providerName
            // 
            this.providerName.Location = new System.Drawing.Point(106, 28);
            this.providerName.Name = "providerName";
            this.providerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerName.Size = new System.Drawing.Size(194, 20);
            this.providerName.TabIndex = 8;
            this.providerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Company name";
            // 
            // providerPhone
            // 
            this.providerPhone.Location = new System.Drawing.Point(106, 64);
            this.providerPhone.Name = "providerPhone";
            this.providerPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerPhone.Size = new System.Drawing.Size(194, 20);
            this.providerPhone.TabIndex = 8;
            this.providerPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(20, 67);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(38, 13);
            this.label99.TabIndex = 15;
            this.label99.Text = "Phone";
            // 
            // providerCountry
            // 
            this.providerCountry.Location = new System.Drawing.Point(106, 240);
            this.providerCountry.Name = "providerCountry";
            this.providerCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerCountry.Size = new System.Drawing.Size(194, 20);
            this.providerCountry.TabIndex = 8;
            this.providerCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Country";
            // 
            // providerCity
            // 
            this.providerCity.Location = new System.Drawing.Point(106, 205);
            this.providerCity.Name = "providerCity";
            this.providerCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerCity.Size = new System.Drawing.Size(194, 20);
            this.providerCity.TabIndex = 8;
            this.providerCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "City";
            // 
            // providerPostalIndex
            // 
            this.providerPostalIndex.Location = new System.Drawing.Point(106, 169);
            this.providerPostalIndex.Name = "providerPostalIndex";
            this.providerPostalIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerPostalIndex.Size = new System.Drawing.Size(194, 20);
            this.providerPostalIndex.TabIndex = 8;
            this.providerPostalIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Postal index";
            // 
            // providerAddress
            // 
            this.providerAddress.Location = new System.Drawing.Point(106, 134);
            this.providerAddress.Name = "providerAddress";
            this.providerAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerAddress.Size = new System.Drawing.Size(194, 20);
            this.providerAddress.TabIndex = 8;
            this.providerAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address";
            // 
            // providerWebb
            // 
            this.providerWebb.Location = new System.Drawing.Point(106, 99);
            this.providerWebb.Name = "providerWebb";
            this.providerWebb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.providerWebb.Size = new System.Drawing.Size(194, 20);
            this.providerWebb.TabIndex = 8;
            this.providerWebb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Webb";
            // 
            // receiverBox
            // 
            this.receiverBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.receiverBox.Controls.Add(this.receiverName);
            this.receiverBox.Controls.Add(this.label3);
            this.receiverBox.Controls.Add(this.receiverCountry);
            this.receiverBox.Controls.Add(this.label22);
            this.receiverBox.Controls.Add(this.receiverCity);
            this.receiverBox.Controls.Add(this.label23);
            this.receiverBox.Controls.Add(this.receiverPostalIndex);
            this.receiverBox.Controls.Add(this.label24);
            this.receiverBox.Controls.Add(this.receiverAddress);
            this.receiverBox.Controls.Add(this.label25);
            this.receiverBox.Location = new System.Drawing.Point(1, 312);
            this.receiverBox.Margin = new System.Windows.Forms.Padding(1);
            this.receiverBox.MinimumSize = new System.Drawing.Size(318, 206);
            this.receiverBox.Name = "receiverBox";
            this.receiverBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.receiverBox.Size = new System.Drawing.Size(318, 207);
            this.receiverBox.TabIndex = 23;
            this.receiverBox.TabStop = false;
            this.receiverBox.Text = "Receiver information";
            // 
            // receiverName
            // 
            this.receiverName.Location = new System.Drawing.Point(106, 28);
            this.receiverName.Name = "receiverName";
            this.receiverName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receiverName.Size = new System.Drawing.Size(194, 20);
            this.receiverName.TabIndex = 20;
            this.receiverName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Company name";
            // 
            // receiverCountry
            // 
            this.receiverCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.receiverCountry.Location = new System.Drawing.Point(106, 169);
            this.receiverCountry.Name = "receiverCountry";
            this.receiverCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receiverCountry.Size = new System.Drawing.Size(194, 20);
            this.receiverCountry.TabIndex = 22;
            this.receiverCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 172);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "Country";
            // 
            // receiverCity
            // 
            this.receiverCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.receiverCity.Location = new System.Drawing.Point(106, 134);
            this.receiverCity.Name = "receiverCity";
            this.receiverCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receiverCity.Size = new System.Drawing.Size(194, 20);
            this.receiverCity.TabIndex = 23;
            this.receiverCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 137);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "City";
            // 
            // receiverPostalIndex
            // 
            this.receiverPostalIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.receiverPostalIndex.Location = new System.Drawing.Point(106, 98);
            this.receiverPostalIndex.Name = "receiverPostalIndex";
            this.receiverPostalIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receiverPostalIndex.Size = new System.Drawing.Size(194, 20);
            this.receiverPostalIndex.TabIndex = 24;
            this.receiverPostalIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 101);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 13);
            this.label24.TabIndex = 27;
            this.label24.Text = "Postal index";
            // 
            // receiverAddress
            // 
            this.receiverAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.receiverAddress.Location = new System.Drawing.Point(106, 63);
            this.receiverAddress.Name = "receiverAddress";
            this.receiverAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receiverAddress.Size = new System.Drawing.Size(194, 20);
            this.receiverAddress.TabIndex = 25;
            this.receiverAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 66);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 13);
            this.label25.TabIndex = 19;
            this.label25.Text = "Address";
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.messageBox.Controls.Add(this.messageIOBox);
            this.messageBox.Location = new System.Drawing.Point(321, 312);
            this.messageBox.Margin = new System.Windows.Forms.Padding(1);
            this.messageBox.MinimumSize = new System.Drawing.Size(318, 207);
            this.messageBox.Name = "messageBox";
            this.messageBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.messageBox.Size = new System.Drawing.Size(318, 207);
            this.messageBox.TabIndex = 21;
            this.messageBox.TabStop = false;
            this.messageBox.Text = "Message ( if neccesary )";
            // 
            // messageIOBox
            // 
            this.messageIOBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageIOBox.Location = new System.Drawing.Point(6, 19);
            this.messageIOBox.Multiline = true;
            this.messageIOBox.Name = "messageIOBox";
            this.messageIOBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.messageIOBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageIOBox.Size = new System.Drawing.Size(306, 182);
            this.messageIOBox.TabIndex = 20;
            // 
            // trashBlock
            // 
            this.trashBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trashBlock.Controls.Add(this.trashBoxReal);
            this.trashBlock.Location = new System.Drawing.Point(641, 312);
            this.trashBlock.Margin = new System.Windows.Forms.Padding(1);
            this.trashBlock.MinimumSize = new System.Drawing.Size(318, 207);
            this.trashBlock.Name = "trashBlock";
            this.trashBlock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trashBlock.Size = new System.Drawing.Size(318, 207);
            this.trashBlock.TabIndex = 22;
            this.trashBlock.TabStop = false;
            this.trashBlock.Text = "Trash ( nothing to save )";
            // 
            // trashBoxReal
            // 
            this.trashBoxReal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trashBoxReal.Location = new System.Drawing.Point(6, 19);
            this.trashBoxReal.Multiline = true;
            this.trashBoxReal.Name = "trashBoxReal";
            this.trashBoxReal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trashBoxReal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.trashBoxReal.Size = new System.Drawing.Size(306, 182);
            this.trashBoxReal.TabIndex = 8;
            // 
            // invoiceBox
            // 
            this.invoiceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.invoiceBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.invoiceBox.Location = new System.Drawing.Point(0, 0);
            this.invoiceBox.Name = "invoiceBox";
            this.invoiceBox.Size = new System.Drawing.Size(17, 769);
            this.invoiceBox.TabIndex = 2;
            this.invoiceBox.TabStop = false;
            this.invoiceBox.Click += new System.EventHandler(this.invoiceBox_Click_1);
            this.invoiceBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.invoiceBox_Move);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::ADCinvoice.Properties.Resources.refresh_selection_arrows_couple_inside_a_square_of_broken_line;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Draw Region";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openBtn
            // 
            this.openBtn.Image = global::ADCinvoice.Properties.Resources.folder_with_a_document_page;
            this.openBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openBtn.Location = new System.Drawing.Point(12, 139);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(104, 34);
            this.openBtn.TabIndex = 9;
            this.openBtn.Text = "Open Result";
            this.openBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // zoomBox
            // 
            this.zoomBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBox.Enabled = false;
            this.zoomBox.Location = new System.Drawing.Point(6, 14);
            this.zoomBox.Name = "zoomBox";
            this.zoomBox.Size = new System.Drawing.Size(860, 127);
            this.zoomBox.TabIndex = 6;
            this.zoomBox.TabStop = false;
            this.zoomBox.Visible = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Image = global::ADCinvoice.Properties.Resources.file;
            this.loadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadBtn.Location = new System.Drawing.Point(12, 19);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(104, 34);
            this.loadBtn.TabIndex = 4;
            this.loadBtn.Text = "Load Invoice";
            this.loadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Image = global::ADCinvoice.Properties.Resources.edit;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(12, 99);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(104, 34);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save Result";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // getBtn
            // 
            this.getBtn.Enabled = false;
            this.getBtn.Image = global::ADCinvoice.Properties.Resources.documents_exchange;
            this.getBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.getBtn.Location = new System.Drawing.Point(12, 59);
            this.getBtn.Name = "getBtn";
            this.getBtn.Size = new System.Drawing.Size(104, 34);
            this.getBtn.TabIndex = 0;
            this.getBtn.Text = "Extract Text";
            this.getBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.getBtn.UseVisualStyleBackColor = true;
            this.getBtn.Click += new System.EventHandler(this.GetTEXT_button_Click_1);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 770);
            this.Controls.Add(this.invoiceBox);
            this.Controls.Add(this.readBox);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ADCinvoice.Properties.Settings.Default, "Start", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::ADCinvoice.Properties.Settings.Default.Start;
            this.MinimumSize = new System.Drawing.Size(395, 613);
            this.Name = "InvoiceForm";
            this.Text = "ADC-invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.readBox.ResumeLayout(false);
            this.readBox.PerformLayout();
            this.viewBlock.ResumeLayout(false);
            this.resultBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.financialBox.ResumeLayout(false);
            this.financialBox.PerformLayout();
            this.providerBox.ResumeLayout(false);
            this.providerBox.PerformLayout();
            this.receiverBox.ResumeLayout(false);
            this.receiverBox.PerformLayout();
            this.messageBox.ResumeLayout(false);
            this.messageBox.PerformLayout();
            this.trashBlock.ResumeLayout(false);
            this.trashBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button getBtn;
        private System.Windows.Forms.TextBox invoicePath;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox readBox;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.PictureBox zoomBox;
        private System.Windows.Forms.GroupBox viewBlock;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label waitLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox invoiceDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ocrReference;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox payDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox totalAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox rounded;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox taxAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox priceBeforeTax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox currency;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox providerBox;
        private System.Windows.Forms.TextBox providerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox providerPhone;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox providerCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox providerCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox providerPostalIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox providerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox providerWebb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox financialBox;
        private System.Windows.Forms.TextBox plusgiroNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox bankgiroNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox organizationReference;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox vatNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ibanNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox messageBox;
        private System.Windows.Forms.TextBox messageIOBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox trashBlock;
        private System.Windows.Forms.TextBox trashBoxReal;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.GroupBox receiverBox;
        private System.Windows.Forms.TextBox receiverName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox receiverCountry;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox receiverCity;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox receiverPostalIndex;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox receiverAddress;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox insuranceNumber;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox objectReference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox taxInPercent;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button openBtn;
        private Emgu.CV.UI.ImageBox invoiceBox;
        private System.Windows.Forms.Button button1;
    }
}

