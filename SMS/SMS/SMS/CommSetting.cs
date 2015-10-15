using System;
using GsmComm.GsmCommunication;

namespace SMS
{
	/// <summary>
	/// Summary description for CommSetting.
	/// </summary>
	
	public class CommSetting
	{
		public static int Comm_Port=0;
		public static Int64 Comm_BaudRate=0;
		public static Int64 Comm_TimeOut=0;
		public static GsmCommMain comm;

		public CommSetting()
		{
			//
			// TODO: Add constructor logic here
			//
		}		
	}
}
