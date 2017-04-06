using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestConsole {
	
	class Program {
	
		static void Main(string[] args) {

			bool[] message = new bool[] { true, true, false, true, false, false, true, true, true, false, true, true, false, false };
			byte[] message2 = new byte[] { 0x01, 0xff };
			BitArray bits = new BitArray(message2);
			bool[] code = new bool[] { true, false, true, true };
			DoudSystems.Utility.CRC CRC = new DoudSystems.Utility.CRC();
			CRC.Message = message;
			CRC.Polynomial = code;
			bool[] crc = CRC.CalcCRC();
			System.Diagnostics.Debug.WriteLine("**********");
			bool rc = CRC.CheckCRC(crc);
		}
	}
}
