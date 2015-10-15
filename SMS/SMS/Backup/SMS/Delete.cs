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
	/// Summary description for Delete.
	/// </summary>
	public class Delete : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.Button btn_delete_all;
		private System.Windows.Forms.TextBox txt_message_index;
		private DataTable dt=new DataTable();
		private delegate void SetTextCallback(string text);

		public Delete()
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_delete_all = new System.Windows.Forms.Button();
			this.txt_message_index = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(472, 264);
			this.dataGrid1.TabIndex = 60;
			this.dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseDown);
			// 
			// btn_delete
			// 
			this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_delete.Location = new System.Drawing.Point(56, 8);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.TabIndex = 62;
			this.btn_delete.Text = "Delete";
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_delete_all
			// 
			this.btn_delete_all.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_delete_all.Location = new System.Drawing.Point(136, 8);
			this.btn_delete_all.Name = "btn_delete_all";
			this.btn_delete_all.TabIndex = 63;
			this.btn_delete_all.Text = "Delete All";
			this.btn_delete_all.Click += new System.EventHandler(this.btn_delete_all_Click);
			// 
			// txt_message_index
			// 
			this.txt_message_index.Location = new System.Drawing.Point(8, 8);
			this.txt_message_index.Name = "txt_message_index";
			this.txt_message_index.Size = new System.Drawing.Size(40, 20);
			this.txt_message_index.TabIndex = 64;
			this.txt_message_index.Text = "";
			// 
			// Delete
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 310);
			this.Controls.Add(this.txt_message_index);
			this.Controls.Add(this.btn_delete_all);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.dataGrid1);
			this.Name = "Delete";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delete";
			this.Load += new System.EventHandler(this.Delete_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Delete_Load(object sender, System.EventArgs e)
		{
			
			dataGrid1.PreferredColumnWidth=100;
			dt.Columns.Add("Index",typeof(int));
			dt.Columns.Add("Sender",typeof(string));
			dt.Columns.Add("Time",typeof(string));
			dt.Columns.Add("Message",typeof(string));	

			ReadMessage();
		}

		private void ReadMessage()
		{
			Cursor.Current = Cursors.WaitCursor;
			string storage = GetMessageStorage();

			try
			{
				// Read all SMS messages from the storage
								
				DecodedShortMessage[] messages = CommSetting.comm.ReadMessages(PhoneMessageStatus.All, storage);
				foreach(DecodedShortMessage message in messages)
				{
					ShowMessage(message.Data,message.Index);
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Cursor.Current = Cursors.Default;	
		}
		
		private void BindGrid(SmsPdu pdu,int index)
		{

			DataRow dr=dt.NewRow();
			SmsDeliverPdu data = (SmsDeliverPdu)pdu;
			    
			dr[0]=index.ToString();
			dr[1]=data.OriginatingAddress.ToString();
			dr[2]=data.SCTimestamp.ToString();
			dr[3]=data.UserDataText;

			
			dt.Rows.Add(dr);
            
			dataGrid1.DataSource=dt;
		}

		private void ShowMessage(SmsPdu pdu,int index)
		{
			if (pdu is SmsSubmitPdu)
			{
				// Stored (sent/unsent) message
				SmsSubmitPdu data = (SmsSubmitPdu)pdu;
				return;
			}
			if (pdu is SmsDeliverPdu)
			{
				// Received message
				SmsDeliverPdu data = (SmsDeliverPdu)pdu;
				
				BindGrid(pdu,index);

				return;
			}
			if (pdu is SmsStatusReportPdu)
			{
				// Status report
				SmsStatusReportPdu data = (SmsStatusReportPdu)pdu;
				return;
			}
			
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
			string storage = PhoneStorageType.Sim;
			return storage;
		}

		private void btn_delete_all_Click(object sender, System.EventArgs e)
		{
			if (!Confirmed()) return;
			Cursor.Current = Cursors.WaitCursor;

			string storage = GetMessageStorage();
			try
			{
				// Delete all messages from phone memory
				CommSetting.comm.DeleteMessages(DeleteScope.All, storage);
				dt.Clear();
				dataGrid1.DataSource=dt;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Cursor.Current = Cursors.Default;
		}

		private bool Confirmed()
		{
			return (MessageBox.Show(this, "Really?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
				== DialogResult.Yes);
		}

		private void dataGrid1_MouseDown
			(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
			// Use the DataGrid control's HitTest method with the x and y properties.
			myHitTest = dataGrid1.HitTest(e.X,e.Y);
			txt_message_index.Text=dataGrid1[myHitTest.Row ,0].ToString();		
		}

		
		private void btn_delete_Click(object sender, System.EventArgs e)
		{
			if( txt_message_index.Text.Equals("")==true)
			{
				MessageBox.Show("Please Click on Grid","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
			}

			int index;
			try
			{
				index = int.Parse(txt_message_index.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			if (!Confirmed()) return;
			Cursor.Current = Cursors.WaitCursor;

			string storage = GetMessageStorage();
			try
			{
				// Delete the message with the specified index from storage
				CommSetting.comm.DeleteMessage(index, storage);
				MessageBox.Show("Message With Index " + index + " Deleted","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Cursor.Current = Cursors.Default;

			dt.Clear();
			dataGrid1.DataSource=null;
			ReadMessage();
		}
	
	}
}
