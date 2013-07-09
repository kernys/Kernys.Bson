using System;

namespace Kernys.Bson
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			var bk = new BSONObject ();
			bk ["hello"] = 0;

			var bo = new BSONObject ();
			bo.Add ("kk", 123);
			bo.Add ("love", "I LOVE YOU GREGRGR");
			bo.Add ("byte", new byte[41223]);

			var ba = new BSONArray ();
			for (int i = 0; i < 10; ++i) {
				ba.Add (i);
			}
			
			bo.Add ("Array", ba);
			bo.Add ("bk", bk);

			byte []buf = SimpleBSON.Dump(bo);
			Console.WriteLine (buf);
			Console.WriteLine (buf.Length);

			bo = SimpleBSON.Load (buf);
			Console.WriteLine (bo ["kk"].int32Value);
			Console.WriteLine (bo ["love"].stringValue);
			foreach(BSONValue v in bo["Array"] as BSONArray) {
				Console.WriteLine (v.int32Value);
			}
			Console.WriteLine (bo["byte"].binaryValue.Length);
			Console.WriteLine (bo["bk"]["hello"].int32Value);
			Console.Read ();
		}
	}
}
