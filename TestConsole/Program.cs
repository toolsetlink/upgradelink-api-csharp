using System;
using System.Text;
using ToolsetLink.UpgradeLinkApi;
using ToolsetLink.UpgradeLinkApi.Models;
using ToolsetLink.DarabonbaBaseCSharp;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Signature Generation...");
            Console.WriteLine("====================================");
            
            // 测试签名生成过程
            TestSignatureGeneration();
            
            Console.WriteLine("\nTesting WinUpgrade method...");
            Console.WriteLine("====================================");
            
            try
            {
                // 配置客户端
                var config = new Config
                {
                    AccessKey = "mui2W50H1j-OC4xD6PgQag",
                    AccessSecret = "3603437250c2df51fc46426ac79d8995",
                    Protocol = "HTTP",
                    Endpoint = "127.0.0.1:8888"
                };
                
                var client = new ToolsetLink.UpgradeLinkApi.Client(config);
                
                // 创建测试请求
                var request = new WinUpgradeRequest
                {
                    WinKey = "isVZBUvkFhv6oHxk_X-D0Q",
                    Arch = "x64",
                    VersionCode = 1,
                    AppointVersionCode = 0,
                    DevModelKey = "",
                    DevKey = ""
                };
                
                Console.WriteLine("Sending WinUpgrade request...");
                
                // 调用WinUpgrade方法（注意：这会发送实际的HTTP请求，可能会失败）
                var response = client.WinUpgrade(request);
                
                Console.WriteLine("WinUpgrade request succeeded!");
                Console.WriteLine($"Response code: {response.Code}");
                Console.WriteLine($"Response message: {response.Msg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        static void TestSignatureGeneration()
        {
            // 测试签名生成
            string bodyStr = "{\"winKey\":\"npJi367lttpwmD1goZ1yOQ\",\"arch\":\"x64\",\"versionCode\":1,\"appointVersionCode\":0,\"devModelKey\":\"\",\"devKey\":\"\"}";
            string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
            string accessSecret = "3603437250c2df51fc46426ac79d8995";
            string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
            string uri = "/v1/win/upgrade";
            
            Console.WriteLine("Test Parameters:");
            Console.WriteLine($"Body: '{bodyStr}'");
            Console.WriteLine($"Nonce: '{nonce}'");
            Console.WriteLine($"AccessSecret: '{accessSecret}'");
            Console.WriteLine($"Timestamp: '{timestamp}'");
            Console.WriteLine($"URI: '{uri}'");
            
            string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
            Console.WriteLine($"Generated Signature: '{signature}'");
            
            // 测试HTTP请求头
            Console.WriteLine("\nHTTP Request Headers:");
            Console.WriteLine($"x-Timestamp: '{timestamp}'");
            Console.WriteLine($"x-Nonce: '{nonce}'");
            Console.WriteLine($"x-Signature: '{signature}'");
        }
    }
}