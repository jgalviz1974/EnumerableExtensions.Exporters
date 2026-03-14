# EnumerableExtensions.Exporters
EnumerableExtensions.Exportes  is a lightweight and flexible .NET library that provides extension methods for IEnumerable&lt;T> to export collections into multiple formats with minimal effort:
- JSON → human-readable serialization.  
- Compressed JSON (GZip) → reduced file size for storage and transfer.  
- MessagePack → high-performance binary serialization with maximum compression.  

🚀 Features
- Simple extension methods for direct usage:
  `csharp
  myList.ExportToJson("data.json");
  myList.ExportToCompressedJson("data.json.gz");
  myList.ExportToMessagePack("data.mp");
  `
- Compatible with .NET 6+ and .NET Standard 2.1.  
- Designed with Clean Architecture principles.  
- No unnecessary dependencies, focused on performance and clarity.  

📌 Use Cases
- Exporting datasets for analytics or integration.  
- Compressing files for efficient storage or network transfer.  
- Fast serialization for microservices and distributed systems.  

🤝 Contributing
Contributions are welcome! You can help by:  
- Adding new export formats (CSV, XML, Parquet, etc.).  
- Improving performance and memory efficiency.  
- Enhancing documentation and providing usage examples.  
