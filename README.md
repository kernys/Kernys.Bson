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
obj["bytes"] = new byte[128];

byte []buf = SimpleBSON.Dump(obj);
Console.WriteLine (buf);
```

Decoding is much easier!
```csharp
var obj = SimpleBSON.Load(buf);

Console.WriteLine(obj["hello"].int32Value); // => 123
Console.WriteLine(obj["where"]["Korea"].stringValue); // => "Asia"
Console.WriteLine(obj["where"]["USA"].stringValue); // => "America"
Console.WriteLine(obj["bytes"].binaryValue.Length); // => 128
```

That's all!


Compatibility
-------------------

No need reflections.
Works very well with Unity 3.x/4.x and any .NET framework versions.

License
-------------------

Kernys.Bson is available under the MIT license.
