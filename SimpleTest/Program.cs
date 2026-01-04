using System;
using ToolsetLink.UpgradeLinkApi.Models;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing WinUpgradeRequest validation...");
            
            try
            {
                // 创建有效的WinUpgradeRequest
                var request = new WinUpgradeRequest
                {
                    WinKey = "isVZBUvkFhv6oHxk_X-D0Q",
                    Arch = "x64",
                    VersionCode = 1,
                    AppointVersionCode = 0,
                    DevModelKey = "",
                    DevKey = ""
                };
                
                Console.WriteLine("Validating WinUpgradeRequest...");
                request.Validate();
                Console.WriteLine("✓ WinUpgradeRequest validation passed!");
                
                // 测试缺少WinKey的情况
                try
                {
                    var invalidRequest = new WinUpgradeRequest
                    {
                        WinKey = null,
                        Arch = "x64",
                        VersionCode = 1,
                        AppointVersionCode = 0,
                        DevModelKey = "",
                        DevKey = ""
                    };
                    invalidRequest.Validate();
                    Console.WriteLine("✗ Expected validation to fail for missing WinKey");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✓ Validation correctly failed for missing WinKey: {ex.Message}");
                }
                
                // 测试缺少Arch的情况
                try
                {
                    var invalidRequest = new WinUpgradeRequest
                    {
                        WinKey = "isVZBUvkFhv6oHxk_X-D0Q",
                        Arch = null,
                        VersionCode = 1,
                        AppointVersionCode = 0,
                        DevModelKey = "",
                        DevKey = ""
                    };
                    invalidRequest.Validate();
                    Console.WriteLine("✗ Expected validation to fail for missing Arch");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✓ Validation correctly failed for missing Arch: {ex.Message}");
                }
                
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