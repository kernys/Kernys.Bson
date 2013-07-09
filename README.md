Kernys.Bson
===========

Simple BSON Encoder &amp; Decoder for C#


Using Kernys.Bson
-------------------

Encoding is very easy!

```csharp
var obj = new BSONObject ();
obj["hello"] = 123;

obj["where"] = new BSONObject();
obj["where"]["Korea"] = "Asia";
obj["where"]["USA"] = "America";
obj["bytes"] = new byte[41223];

byte []buf = SimpleBSON.Dump(obj);
Console.WriteLine (buf);
```

Decoding is much easier!
```csharp
BSONObject obj = SimpleBSON.Load(buf);

Console.WriteLine(obj["hello"]); // => 123
Console.WriteLine(obj["where"]["Korea"]); // => "Asia"
Console.WriteLine(obj["where"]["USA"]); // => "America"
Console.WriteLine(obj["bytes"].binaryValue); // => 128-length bytes
```

That's all!
