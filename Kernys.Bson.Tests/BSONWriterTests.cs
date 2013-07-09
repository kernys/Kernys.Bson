using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Kernys.Bson;


namespace Kernys.Bson.Tests
{
	[TestFixture]
	public class BsonWriterTests
	{
		[Test]
		public void WriteSingleObject()
		{
			BSONObject obj = new BSONObject ();

			obj ["Blah"] = 1;

			string bson = MiscellaneousUtils.BytesToHex(SimpleBSON.Dump(obj));
			Assert.AreEqual("0F-00-00-00-10-42-6C-61-68-00-01-00-00-00-00", bson);
		}

		[Test]
		public void WriteArray()
		{
			byte[] data = MiscellaneousUtils.HexToBytes("31-00-00-00-04-42-53-4f-4e-00-26-00-00-00-02-30-00-08-00-00-00-61-77-65-73-6f-6d-65-00-01-31-00-33-33-33-33-33-33-14-40-10-32-00-c2-07-00-00-00-00");

			BSONObject obj = new BSONObject();

			obj ["BSON"] = new BSONArray ();
			obj ["BSON"].Add ("awesome");
			obj ["BSON"].Add (5.05);
			obj ["BSON"].Add (1986);

			byte[] target = SimpleBSON.Dump (obj);
			Assert.IsTrue (MiscellaneousUtils.ByteArrayCompare (target, data) == 0);

		}

	}
}

