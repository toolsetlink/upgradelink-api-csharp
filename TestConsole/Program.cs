using System;
using ToolsetLink.UpgradeLinkApi;
using ToolsetLink.UpgradeLinkApi.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing WinUpgrade method...");
            
            try
            {
                // 配置客户端
                var config = new Config
                {
                    AccessKey = "mui2W50H1j-OC4xD6PgQag",
                    AccessSecret = "3603437250c2df51fc46426ac79d8995"
                };
                
                var client = new Client(config);
                
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
    }
}