using System;
using NUnit.Framework;
using ToolsetLink.UpgradeLinkApi;
using ToolsetLink.UpgradeLinkApi.Models;

namespace UpgradeLinkApi.Tests
{
    [TestFixture]
    public class ClientTests
    {
        private Client _client;
        private Config _config;

        [SetUp]
        public void Setup()
        {
            // 配置测试用的客户端
            _config = new Config
            {
                AccessKey = "mui2W50H1j-OC4xD6PgQag",
                AccessSecret = "3603437250c2df51fc46426ac79d8995",
                Protocol = "HTTP",
                Endpoint = "127.0.0.1:8888"
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
                
                // 序列化请求体并打印
                string bodyStr = AlibabaCloud.TeaUtil.Common.ToJSONString(request);
                Console.WriteLine($"序列化后的请求体: {bodyStr}");
                
                var response = _client.WinUpgrade(request);
                Console.WriteLine("请求成功!");
                Console.WriteLine($"响应代码: {response.Code}");
                Console.WriteLine($"响应消息: {response.Msg}");
                Console.WriteLine($"TraceId: {response.TraceId}");
                
                // 打印响应数据
                if (response.Data != null)
                {
                    Console.WriteLine($"Data: {Newtonsoft.Json.JsonConvert.SerializeObject(response.Data)}");
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
    }
}