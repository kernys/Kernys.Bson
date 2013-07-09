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
	public class BsonReaderTests
	{
		private const char Euro = '\u20ac';
		
		[Test]
		public void ReadSingleObject()
		{
			byte[] data = MiscellaneousUtils.HexToBytes("0F-00-00-00-10-42-6C-61-68-00-01-00-00-00-00");
			BSONObject obj = SimpleBSON.Load (data);

			Assert.AreEqual (obj ["Blah"].int32Value, 1);
		}

		[Test]
		public void ReadArray()
		{
			byte[] data = MiscellaneousUtils.HexToBytes("31-00-00-00-04-42-53-4f-4e-00-26-00-00-00-02-30-00-08-00-00-00-61-77-65-73-6f-6d-65-00-01-31-00-33-33-33-33-33-33-14-40-10-32-00-c2-07-00-00-00-00");

			BSONObject obj = SimpleBSON.Load (data);

			Assert.IsTrue (obj ["BSON"] is BSONArray);
			Assert.AreEqual (obj ["BSON"][0].stringValue, "awesome");
			Assert.AreEqual (obj ["BSON"][1].doubleValue, 5.05);
			Assert.AreEqual (obj ["BSON"][2].int32Value, 1986);
		}
  }
}

