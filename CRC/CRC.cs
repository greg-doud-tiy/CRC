using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoudSystems.Utility {

	public class CRC {

		public bool[] Message { get; set; }
		public bool[] Polynomial { get; set; }

		public bool[] CalcCRC() {
			var codeLen = Polynomial.Length;
			var msgLen = Message.Length + codeLen - 1;
			bool[] workMsg = new bool[msgLen];
			for (int idx = 0; idx < Message.Length; idx++)
				workMsg[idx] = Message[idx];
			for (int idx = 0; idx < Message.Length; idx++) {
				if (workMsg[idx] == false)
					continue;
				print(workMsg);
				printCode(idx + 1, Polynomial);
				for (int idx2 = 0; idx2 < Polynomial.Length; idx2++) {
					workMsg[idx + idx2] = workMsg[idx + idx2] ^ Polynomial[idx2];
				}
			}
			print(workMsg);
			bool[] crc = new bool[Polynomial.Length - 1];
			for (int idx = 0; idx < Polynomial.Length - 1; idx++)
				crc[idx] = workMsg[Message.Length + idx];
			return crc;
		}

		public bool CheckCRC(bool[] crc) {
			var calcCRC = CalcCRC();
			for (int idx = 0; idx < calcCRC.Length; idx++)
				if (calcCRC[idx] != crc[idx])
					return false;
			return true;
		}

		private void print(bool[] bits) {
			foreach (bool bit in bits)
				System.Diagnostics.Debug.Write((bit ? "1" : "0"));
			System.Diagnostics.Debug.WriteLine(" ");
		}
		private void printCode(int spaces, bool[] bits) {
			for (int idx = 0; idx < spaces - 1; idx++)
				System.Diagnostics.Debug.Write(" ");
			print(bits);
		}

		public CRC() { }
	}
}
