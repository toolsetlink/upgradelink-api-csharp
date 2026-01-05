using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using ToolsetLink.UpgradeLinkApi.Models;

namespace TestSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing JSON Serialization...");
            Console.WriteLine("==================================");
            
            // 创建测试请求对象
            var request = new WinUpgradeRequest
            {
                WinKey = "npJi367lttpwmD1goZ1yOQ",
                Arch = "x64",
                VersionCode = 1,
                AppointVersionCode = 0,
                DevModelKey = "",
                DevKey = ""
            };
            
            Console.WriteLine("Original Request Object:");
            Console.WriteLine($"WinKey: {request.WinKey}");
            Console.WriteLine($"Arch: {request.Arch}");
            Console.WriteLine($"VersionCode: {request.VersionCode}");
            Console.WriteLine($"AppointVersionCode: {request.AppointVersionCode}");
            Console.WriteLine($"DevModelKey: {request.DevModelKey}");
            Console.WriteLine($"DevKey: {request.DevKey}");
            
            // 测试默认序列化
            Console.WriteLine("\nDefault Serialization:");
            string defaultJson = JsonConvert.SerializeObject(request);
            Console.WriteLine(defaultJson);
            
            // 测试使用NameInMapContractResolver的序列化
            Console.WriteLine("\nCustom Serialization with NameInMapContractResolver:");
            var contractResolver = new NameInMapContractResolver();
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            };
            string customJson = JsonConvert.SerializeObject(request, jsonSettings);
            Console.WriteLine(customJson);
            
            // 比较结果
            Console.WriteLine("\nComparison:");
            Console.WriteLine($"Default JSON: {defaultJson}");
            Console.WriteLine($"Custom JSON:  {customJson}");
            Console.WriteLine($"Match: {defaultJson == customJson}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // 自定义JSON契约解析器，用于处理[NameInMap]属性
        private class NameInMapContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                
                Console.WriteLine($"\nProcessing member: {member.Name}");
                Console.WriteLine($"Member type: {member.GetType().FullName}");
                
                // 列出所有自定义属性
                var attributes = member.GetCustomAttributes(true);
                Console.WriteLine($"Number of attributes: {attributes.Length}");
                foreach (var attr in attributes)
                {
                    Console.WriteLine($"Attribute: {attr.GetType().FullName}");
                    Console.WriteLine($"Attribute value: {attr}");
                }
                
                // 查找NameInMap属性
                var nameInMapAttribute = member.GetCustomAttribute(typeof(Tea.NameInMapAttribute)) as Tea.NameInMapAttribute;
                Console.WriteLine($"NameInMapAttribute found: {nameInMapAttribute != null}");
                if (nameInMapAttribute != null)
                {
                    // 使用NameInMap属性的值作为JSON字段名
                    Console.WriteLine($"Changing property name from {property.PropertyName} to {nameInMapAttribute.Name}");
                    property.PropertyName = nameInMapAttribute.Name;
                }
                
                return property;
            }
        }
    }
}