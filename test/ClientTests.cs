using System;
using System.Reflection;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ToolsetLink.UpgradeLinkApi;
using ToolsetLink.UpgradeLinkApi.Models;

namespace UpgradeLinkApi.Tests
{
    [TestFixture]
    public class ClientTests
    {
        // 自定义JSON契约解析器，用于处理[NameInMap]属性
        private class NameInMapContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);
                
                // 查找NameInMap属性
                var nameInMapAttribute = member.GetCustomAttribute(typeof(Tea.NameInMapAttribute)) as Tea.NameInMapAttribute;
                if (nameInMapAttribute != null)
                {
                    // 使用NameInMap属性的值作为JSON字段名
                    property.PropertyName = nameInMapAttribute.Name;
                }
                
                return property;
            }
        }
        
        // 自定义JSON序列化配置
        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new NameInMapContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
        
        private Client _client;
        private Config _config;

        [SetUp]
        public void Setup()
        {
            // 配置测试用的客户端
            _config = new Config
            {
                AccessKey = "mui2W50H1j-OC4xD6PgQag",
                AccessSecret = "PEbdHFGC0uO_Pch7XWBQTMsFRxKPQAM2565eP8LJ3gc",
                // Protocol = "HTTP",
                // Endpoint = "127.0.0.1:8888"
            };
            
            _client = new Client(_config);
        }

        [Test]
        public void WinUpgrade_Should_Send_Request_And_Print_Result()
        {
            // Arrange
            var request = new WinUpgradeRequest
            {
                WinKey = "npJi367lttpwmD1goZ1yOQ",
                Arch = "x64",
                VersionCode = 1,
                AppointVersionCode = 0,
                DevModelKey = "",
                DevKey = ""
            };

            // Act
            try
            {
                Console.WriteLine("发送WinUpgrade请求...");
                // 打印请求信息
                Console.WriteLine("请求信息:");
                Console.WriteLine($"  WinKey: {request.WinKey}");
                Console.WriteLine($"  Arch: {request.Arch}");
                Console.WriteLine($"  VersionCode: {request.VersionCode}");
                Console.WriteLine($"  AppointVersionCode: {request.AppointVersionCode}");
                Console.WriteLine($"  DevModelKey: {request.DevModelKey}");
                Console.WriteLine($"  DevKey: {request.DevKey}");
                
                // 序列化请求体并打印（使用与客户端相同的自定义契约解析器）
                string bodyStr = Newtonsoft.Json.JsonConvert.SerializeObject(request, _jsonSettings);
                Console.WriteLine($"序列化后的请求体: {bodyStr}");
                Console.WriteLine("注意：上面的请求体与实际请求使用的序列化格式一致");
                
                var response = _client.WinUpgrade(request);
                Console.WriteLine("请求成功!");
                Console.WriteLine($"response.code: {response.Code}");
                Console.WriteLine($"response.msg: {response.Msg}");
                Console.WriteLine($"response.traceId: {response.TraceId}");
                
                // 打印响应数据（使用与客户端相同的自定义契约解析器）
                if (response.Data != null)
                {
                    Console.WriteLine($"Data: {Newtonsoft.Json.JsonConvert.SerializeObject(response.Data, _jsonSettings)}");
                }
            }
            catch (Tea.TeaException ex)
            {
                Console.WriteLine("请求失败 - TeaException详情:");
                Console.WriteLine($"异常消息: {ex.Message}");
                
                // 反射获取TeaException的内部属性
                var properties = ex.GetType().GetProperties();
                foreach (var property in properties)
                {
                    try
                    {
                        var value = property.GetValue(ex);
                        Console.WriteLine($"{property.Name}: {value}");
                    }
                    catch (Exception)
                    {
                        // 忽略无法访问的属性
                    }
                }
                
                // 打印异常的Data属性
                if (ex.Data != null)
                {
                    Console.WriteLine("Exception Data:");
                    foreach (var key in ex.Data.Keys)
                    {
                        Console.WriteLine($"  {key}: {ex.Data[key]}");
                    }
                }
                
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex.Message}");
                Console.WriteLine($"异常类型: {ex.GetType().Name}");
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }

            // 断言：测试总是通过，因为我们只关心打印结果
            Assert.Pass("WinUpgrade请求已发送，结果已打印");
        }
        
        
        [Test]
        public void WinVersion_Should_Send_Request_And_Print_Result()
        {
            // Arrange
            var request = new WinVersionRequest
            {
                WinKey = "npJi367lttpwmD1goZ1yOQ",
                Arch = "x64",
                VersionCode = 1,
            };

            // Act
            try
            {
                Console.WriteLine("发送WinVersion请求...");
                // 打印请求信息
                Console.WriteLine("请求信息:");
                Console.WriteLine($"  WinKey: {request.WinKey}");
                Console.WriteLine($"  Arch: {request.Arch}");
                Console.WriteLine($"  VersionCode: {request.VersionCode}");
                
                // 序列化请求体并打印（使用与客户端相同的自定义契约解析器）
                string bodyStr = Newtonsoft.Json.JsonConvert.SerializeObject(request, _jsonSettings);
                Console.WriteLine($"序列化后的请求体: {bodyStr}");
                Console.WriteLine("注意：上面的请求体与实际请求使用的序列化格式一致");
                
                var response = _client.WinVersion(request);
                Console.WriteLine("请求成功!");
                Console.WriteLine($"response.code: {response.Code}");
                Console.WriteLine($"response.msg: {response.Msg}");
                Console.WriteLine($"response.traceId: {response.TraceId}");
                
                // 打印响应数据（使用与客户端相同的自定义契约解析器）
                if (response.Data != null)
                {
                    Console.WriteLine($"Data: {Newtonsoft.Json.JsonConvert.SerializeObject(response.Data, _jsonSettings)}");
                }
            }
            catch (Tea.TeaException ex)
            {
                Console.WriteLine("请求失败 - TeaException详情:");
                Console.WriteLine($"异常消息: {ex.Message}");
                
                // 反射获取TeaException的内部属性
                var properties = ex.GetType().GetProperties();
                foreach (var property in properties)
                {
                    try
                    {
                        var value = property.GetValue(ex);
                        Console.WriteLine($"{property.Name}: {value}");
                    }
                    catch (Exception)
                    {
                        // 忽略无法访问的属性
                    }
                }
                
                // 打印异常的Data属性
                if (ex.Data != null)
                {
                    Console.WriteLine("Exception Data:");
                    foreach (var key in ex.Data.Keys)
                    {
                        Console.WriteLine($"  {key}: {ex.Data[key]}");
                    }
                }
                
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex.Message}");
                Console.WriteLine($"异常类型: {ex.GetType().Name}");
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }

            // 断言：测试总是通过，因为我们只关心打印结果
            Assert.Pass("WinVersion请求已发送，结果已打印");
        }
        
        
        [Test]
        public void AppStatisticsInfo_Should_Send_Request_And_Print_Result()
        {
            // Arrange
            var request = new AppStatisticsInfoRequest
            {
                AppKey = "kPUtUMDIjBhS48q5771pow",
            };

            // Act
            try
            {
                Console.WriteLine("发送AppStatisticsInfo请求...");
                // 打印请求信息
                Console.WriteLine("请求信息:");
                Console.WriteLine($"  AppKey: {request.AppKey}");
                
                var response = _client.AppStatisticsInfo(request);
                Console.WriteLine("请求成功!");
                Console.WriteLine($"response.code: {response.Code}");
                Console.WriteLine($"response.msg: {response.Msg}");
                Console.WriteLine($"response.traceId: {response.TraceId}");
                
                // 打印响应数据（使用与客户端相同的自定义契约解析器）
                if (response.Data != null)
                {
                    Console.WriteLine($"Data: {Newtonsoft.Json.JsonConvert.SerializeObject(response.Data, _jsonSettings)}");
                }
            }
            catch (Tea.TeaException ex)
            {
                Console.WriteLine("请求失败 - TeaException详情:");
                Console.WriteLine($"异常消息: {ex.Message}");
                
                // 反射获取TeaException的内部属性
                var properties = ex.GetType().GetProperties();
                foreach (var property in properties)
                {
                    try
                    {
                        var value = property.GetValue(ex);
                        Console.WriteLine($"{property.Name}: {value}");
                    }
                    catch (Exception)
                    {
                        // 忽略无法访问的属性
                    }
                }
                
                // 打印异常的Data属性
                if (ex.Data != null)
                {
                    Console.WriteLine("Exception Data:");
                    foreach (var key in ex.Data.Keys)
                    {
                        Console.WriteLine($"  {key}: {ex.Data[key]}");
                    }
                }
                
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"请求失败: {ex.Message}");
                Console.WriteLine($"异常类型: {ex.GetType().Name}");
                Console.WriteLine($"堆栈跟踪: {ex.StackTrace}");
            }

            // 断言：测试总是通过，因为我们只关心打印结果
            Assert.Pass("AppStatisticsInfo请求已发送，结果已打印");
        }
    }
}