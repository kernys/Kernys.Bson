using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NUnit.Framework;
using Kernys.Bson;

namespace Kernys.Bson.Tests
{
	[TestFixture]
	public class MinimalTests
	{
		
		[Test]
		public void WriteAndRead()
		{
			var obj = new BSONObject ();
			obj["hello"] = 123;

			obj["where"] = new BSONObject();
			obj["where"]["Korea"] = "Asia";
			obj["where"]["USA"] = "America";
			obj["bytes"] = new byte[41223];

			byte []buf = SimpleBSON.Dump(obj);
			Console.WriteLine (buf);

			obj = SimpleBSON.Load(buf);

			Console.WriteLine(obj["hello"].int32Value); // => 123
			Console.WriteLine(obj["where"]["Korea"].stringValue); // => "Asia"
			Console.WriteLine(obj["where"]["USA"].stringValue); // => "America"
			Console.WriteLine(obj["bytes"].binaryValue.Length); // => 128-length bytesbytes
		}
	}
}

