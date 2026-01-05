using System;
using ToolsetLink.DarabonbaBaseCSharp;

// 直接测试DarabonbaBaseCSharp.Client的GenerateSignature方法
Console.WriteLine("Testing DarabonbaBaseCSharp.Client.GenerateSignature method");
Console.WriteLine("============================================");

try
{
    // 准备测试参数
    // string bodyStr = "{\"winKey\":\"npJi367lttpwmD1goZ1yOQ\",\"arch\":\"x64\",\"versionCode\":1,\"appointVersionCode\":0,\"devModelKey\":\"\",\"devKey\":\"\"}";
    // string nonce = "60ba668ab9f327ee";
    // string accessSecret = "PEbdHFGC0uO_Pch7XWBQTMsFRxKPQAM2565eP8LJ3gc";
    // string timestamp = "2026-01-05T05:11:04Z";
    // string uri = "/v1/win/upgrade";
    
    string body = "{\"winKey\":\"npJi367lttpwmD1goZ1yOQ\",\"arch\":\"x64\",\"versionCode\":1,\"appointVersionCode\":0,\"devModelKey\":\"\",\"devKey\":\"\"}";
    string nonce = "60ba668ab9f327ee";
    string secretKey = "PEbdHFGC0uO_Pch7XWBQTMsFRxKPQAM2565eP8LJ3gc";
    string timestamp = "2026-01-05T05:11:04Z";
    string uri = "/v1/win/upgrade";
    
    Console.WriteLine($"Body: '{body}'");
    Console.WriteLine($"Nonce: '{nonce}'");
    Console.WriteLine($"AccessSecret: '{secretKey}'");
    Console.WriteLine($"Timestamp: '{timestamp}'");
    Console.WriteLine($"URI: '{uri}'");
    Console.WriteLine();
    
    // 直接调用GenerateSignature方法
    string signature = Client.GenerateSignature(body, nonce, secretKey, timestamp, uri);
    
    Console.WriteLine($"Generated signature: '{signature}'");
    Console.WriteLine("Test passed!");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();