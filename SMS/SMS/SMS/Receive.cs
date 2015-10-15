using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using GsmComm.PduConverter;
using GsmComm.GsmCommunication;

namespace SMS
{
	/// <summary>
	/// Summary description for Receive.
	/// </summary>
	public class Receive : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnReadMessage;
		private System.Windows.Forms.RadioButton rbMessagePhone;
		private System.Windows.Forms.RadioButton rbMessageSIM;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataTable dt=new DataTable();
		private delegate void SetTextCallback(string text);
        
		public Receive()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnReadMessage = new System.Windows.Forms.Button();
			this.rbMessagePhone = new System.Windows.Forms.RadioButton();
			this.rbMessageSIM = new System.Windows.Forms.RadioButton();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnReadMessage
			// 
			this.btnReadMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnReadMessage.Location = new System.Drawing.Point(192, 80);
			this.btnReadMessage.Name = "btnReadMessage";
			this.btnReadMessage.Size = new System.Drawing.Size(112, 24);
			this.btnReadMessage.TabIndex = 17;
			this.btnReadMessage.Text = "Read All Messages";
			this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
			// 
			// rbMessagePhone
			// 
			this.rbMessagePhone.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbMessagePhone.Location = new System.Drawing.Point(16, 56);
			this.rbMessagePhone.Name = "rbMessagePhone";
			this.rbMessagePhone.Size = new System.Drawing.Size(64, 24);
			this.rbMessagePhone.TabIndex = 25;
			this.rbMessagePhone.Text = "Phone";
			// 
			// rbMessageSIM
			// 
			this.rbMessageSIM.Checked = true;
			this.rbMessageSIM.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbMessageSIM.Location = new System.Drawing.Point(16, 24);
			this.rbMessageSIM.Name = "rbMessageSIM";
			this.rbMessageSIM.Size = new System.Drawing.Size(64, 24);
			this.rbMessageSIM.TabIndex = 24;
			this.rbMessageSIM.TabStop = true;
			this.rbMessageSIM.Text = "SIM";
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(8, 304);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(448, 144);
			this.txtOutput.TabIndex = 57;
			this.txtOutput.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbMessageSIM);
			this.groupBox1.Controls.Add(this.rbMessagePhone);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 96);
			this.groupBox1.TabIndex = 58;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Message Storage";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 120);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(448, 176);
			this.dataGrid1.TabIndex = 59;
			// 
			// Receive
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 454);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnReadMessage);
			this.Name = "Receive";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Read Messages";
			this.Load += new System.EventHandler(this.Receive_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnReadMessage_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			string storage = GetMessageStorage();

			try
			{
				// Read all SMS messages from the storage
								
				DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.All, storage);
				foreach(DecodedShortMessage message in messages)
				{
					Output(string.Format("Message status = {0}, Location = {1}/{2}",
						StatusToString(message.Status),	message.Storage, message.Index));
					ShowMessage(message.Data);
					Output("");				
				}
				Output(string.Format("{0,9} messages read.", messages.Length.ToString()));
				Output("");				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Cursor.Current = Cursors.Default;		
		}
		

		private void BindGrid(SmsPdu pdu)
		{

			DataRow dr=dt.NewRow();
			SmsDeliverPdu data = (SmsDeliverPdu)pdu;
			            
			dr[0]=data.OriginatingAddress.ToString();
			dr[1]=data.SCTimestamp.ToString();
			dr[2]=data.UserDataText;
			dt.Rows.Add(dr);
            
			dataGrid1.DataSource=dt;
		}

		private void ShowMessage(SmsPdu pdu)
		{
			if (pdu is SmsSubmitPdu)
			{
				// Stored (sent/unsent) message
				SmsSubmitPdu data = (SmsSubmitPdu)pdu;
				Output("SENT/UNSENT MESSAGE");
				Output("Recipient: " + data.DestinationAddress);
				Output("Message text: " + data.UserDataText);
				Output("-------------------------------------------------------------------");
				return;
			}
			if (pdu is SmsDeliverPdu)
			{
				// Received message
				SmsDeliverPdu data = (SmsDeliverPdu)pdu;
				Output("RECEIVED MESSAGE");
				Output("Sender: " + data.OriginatingAddress);
				Output("Sent: " + data.SCTimestamp.ToString());
				Output("Message text: " + data.UserDataText);
				Output("-------------------------------------------------------------------");

				BindGrid(pdu);

				return;
			}
			if (pdu is SmsStatusReportPdu)
			{
				// Status report
				SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
				Output("STATUS REPORT");
				Output("Recipient: " + data.RecipientAddress);
				Output("Status: " + data.Status.ToString());
				Output("Timestamp: " + data.DischargeTime.ToString());
				Output("Message ref: " + data.MessageReference.ToString());
				Output("-------------------------------------------------------------------");
				return;
			}
			Output("Unknown message type: " + pdu.GetType().ToString());
		}


		private string StatusToString(PhoneMessageStatus status)
		{
			// Map a message status to a string
			string ret;
			switch(status)
			{
				case PhoneMessageStatus.All:
					ret = "All";
					break;
				case PhoneMessageStatus.ReceivedRead:
					ret = "Read";
					break;
				case PhoneMessageStatus.ReceivedUnread:
					ret = "Unread";
					break;
				case PhoneMessageStatus.StoredSent:
					ret = "Sent";
					break;
				case PhoneMessageStatus.StoredUnsent:
					ret = "Unsent";
					break;
				default:
					ret = "Unknown (" + status.ToString() + ")";
					break;
			}
			return ret;
		}


		private string GetMessageStorage()
		{
			string storage = string.Empty;
			if (rbMessageSIM.Checked)
				storage = PhoneStorageType.Sim;
			if (rbMessagePhone.Checked)
				storage = PhoneStorageType.Phone;
			if (storage.Length == 0)
				throw new ApplicationException("Unknown message storage.");
			else
				return storage;
		}


		private void Output(string text)
		{
			if (this.txtOutput.InvokeRequired)
			{
				SetTextCallback stc = new SetTextCallback(Output);
				this.Invoke(stc, new object[] { text });
			}
			else
			{
				txtOutput.AppendText(text);
				txtOutput.AppendText("\r\n");
			}
		}


		private void Receive_Load(object sender, System.EventArgs e)
		{
			dt.Columns.Add("Sender",typeof(string));
			dt.Columns.Add("Time",typeof(string));
			dt.Columns.Add("Message",typeof(string));			
		}

		private void Output(string text, params object[] args)
		{
			string msg = string.Format(text, args);
			Output(msg);
		}

	}
}
