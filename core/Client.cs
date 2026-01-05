// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Tea;
using Tea.Utils;

using ToolsetLink.UpgradeLinkApi.Models;

namespace ToolsetLink.UpgradeLinkApi
{
    public class Client 
    {
        protected string _accessKey;
        protected string _accessSecret;
        protected string _protocol;
        protected string _endpoint;
        
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
        
        // 自定义序列化方法
        private string ToJSONString(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSettings);
        }

        public Client(Config config)
        {
            this._accessKey = config.AccessKey;
            this._accessSecret = config.AccessSecret;
            if (AlibabaCloud.TeaUtil.Common.EqualString(config.Protocol, "HTTPS"))
            {
                this._protocol = "HTTPS";
            }
            else
            {
                this._protocol = "HTTP";
            }
            if (AlibabaCloud.TeaUtil.Common.Empty(config.Endpoint))
            {
                this._endpoint = "api.upgrade.toolsetlink.com";
            }
            else
            {
                this._endpoint = config.Endpoint;
            }
        }

        public UrlUpgradeResponse UrlUpgrade(UrlUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                {"retry", null},
                {"backoff", null}
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/url/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/url/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<UrlUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<UrlUpgradeResponse> UrlUpgradeAsync(UrlUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/url/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/url/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<UrlUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public UrlVersionResponse UrlVersion(UrlVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/url/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/url/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<UrlVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<UrlVersionResponse> UrlVersionAsync(UrlVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/url/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/url/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<UrlVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public FileUpgradeResponse FileUpgrade(FileUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/file/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/file/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<FileUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<FileUpgradeResponse> FileUpgradeAsync(FileUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/file/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/file/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<FileUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public FileVersionResponse FileVersion(FileVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/file/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/file/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<FileVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<FileVersionResponse> FileVersionAsync(FileVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/file/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/file/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<FileVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public ApkUpgradeResponse ApkUpgrade(ApkUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/apk/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/apk/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ApkUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<ApkUpgradeResponse> ApkUpgradeAsync(ApkUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/apk/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/apk/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ApkUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public ApkVersionResponse ApkVersion(ApkVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/apk/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/apk/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ApkVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<ApkVersionResponse> ApkVersionAsync(ApkVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/apk/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/apk/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ApkVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public ConfigurationUpgradeResponse ConfigurationUpgrade(ConfigurationUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/configuration/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/configuration/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ConfigurationUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<ConfigurationUpgradeResponse> ConfigurationUpgradeAsync(ConfigurationUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/configuration/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/configuration/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ConfigurationUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public ConfigurationVersionResponse ConfigurationVersion(ConfigurationVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/configuration/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/configuration/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ConfigurationVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<ConfigurationVersionResponse> ConfigurationVersionAsync(ConfigurationVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/configuration/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/configuration/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ConfigurationVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public TauriVersionResponse TauriVersion(TauriVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/tauri/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/tauri/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<TauriVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<TauriVersionResponse> TauriVersionAsync(TauriVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/tauri/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/tauri/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<TauriVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public ElectronVersionResponse ElectronVersion(ElectronVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/electron/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/electron/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ElectronVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<ElectronVersionResponse> ElectronVersionAsync(ElectronVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/electron/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/electron/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<ElectronVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public LnxUpgradeResponse LnxUpgrade(LnxUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/lnx/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/lnx/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<LnxUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<LnxUpgradeResponse> LnxUpgradeAsync(LnxUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/lnx/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/lnx/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<LnxUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public LnxVersionResponse LnxVersion(LnxVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/lnx/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/lnx/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<LnxVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<LnxVersionResponse> LnxVersionAsync(LnxVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/lnx/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/lnx/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<LnxVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public WinUpgradeResponse WinUpgrade(WinUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                {"retry", null},
                {"backoff", null}
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/win/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/win/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<WinUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<WinUpgradeResponse> WinUpgradeAsync(WinUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                {"retry", null},
                {"backoff", null}
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/win/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/win/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<WinUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public WinVersionResponse WinVersion(WinVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                {"retry", null},
                {"backoff", null}
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/win/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/win/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<WinVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<WinVersionResponse> WinVersionAsync(WinVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                {"retry", null},
                {"backoff", null}
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/win/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/win/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<WinVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public MacUpgradeResponse MacUpgrade(MacUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/mac/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/mac/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<MacUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<MacUpgradeResponse> MacUpgradeAsync(MacUpgradeRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/mac/upgrade";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/mac/upgrade";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<MacUpgradeResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public MacVersionResponse MacVersion(MacVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/mac/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/mac/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<MacVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<MacVersionResponse> MacVersionAsync(MacVersionRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/mac/version";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/mac/version";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<MacVersionResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AppReportResponse AppReport(AppReportRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/app/report";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/app/report";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<AppReportResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AppReportResponse> AppReportAsync(AppReportRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = ToJSONString(request);
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/app/report";
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "POST";
                    request_.Pathname = "/v1/app/report";
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<AppReportResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public AppStatisticsInfoResponse AppStatisticsInfo(AppStatisticsInfoRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = "";
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/app/statistics/info?appKey=" + request.AppKey;
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "GET";
                    request_.Pathname = "/v1/app/statistics/info";
                    request_.Query = new Dictionary<string, string>
                    {
                        {"appKey", request.AppKey},
                    };
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = TeaCore.DoAction(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<AppStatisticsInfoResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public async Task<AppStatisticsInfoResponse> AppStatisticsInfoAsync(AppStatisticsInfoRequest request)
        {
            request.Validate();
            Dictionary<string, object> runtime_ = new Dictionary<string, object>
            {
                {"timeout", 10000},
                // 10s 的过期时间
            };

            TeaRequest _lastRequest = null;
            Exception _lastException = null;
            long _now = System.DateTime.Now.Millisecond;
            int _retryTimes = 0;
            while (TeaCore.AllowRetry((IDictionary) runtime_["retry"], _retryTimes, _now))
            {
                if (_retryTimes > 0)
                {
                    int backoffTime = TeaCore.GetBackoffTime((IDictionary)runtime_["backoff"], _retryTimes);
                    if (backoffTime > 0)
                    {
                        TeaCore.Sleep(backoffTime);
                    }
                }
                _retryTimes = _retryTimes + 1;
                try
                {
                    TeaRequest request_ = new TeaRequest();
                    // 序列化请求体
                    string bodyStr = "";
                    // 生成请求参数
                    string timestamp = ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
                    string nonce = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateNonce();
                    string uri = "/v1/app/statistics/info?appKey=" + request.AppKey;
                    string accessKey = _accessKey;
                    string accessSecret = _accessSecret;
                    // 生成签名
                    string signature = ToolsetLink.DarabonbaBaseCSharp.Client.GenerateSignature(bodyStr, nonce, accessSecret, timestamp, uri);
                    request_.Protocol = _protocol;
                    request_.Method = "GET";
                    request_.Pathname = "/v1/app/statistics/info";
                    request_.Query = new Dictionary<string, string>
                    {
                        {"appKey", request.AppKey},
                    };
                    request_.Headers = new Dictionary<string, string>
                    {
                        {"host", _endpoint},
                        {"content-type", "application/json"},
                        {"x-Timestamp", timestamp},
                        {"x-Nonce", nonce},
                        {"x-AccessKey", accessKey},
                        {"x-Signature", signature},
                    };
                    request_.Body = TeaCore.BytesReadable(bodyStr);
                    _lastRequest = request_;
                    TeaResponse response_ = await TeaCore.DoActionAsync(request_, runtime_);

                    Dictionary<string, object> result = AlibabaCloud.TeaUtil.Common.AssertAsMap(AlibabaCloud.TeaUtil.Common.ReadAsJSON(response_.Body));
                    if (!AlibabaCloud.TeaUtil.Common.EqualNumber(response_.StatusCode, 200))
                    {
                        throw new TeaException(new Dictionary<string, string>
                        {
                            {"statusCode", "" + response_.StatusCode},
                            {"code", "" + result.Get("code")},
                            {"message", "" + result.Get("msg")},
                            {"docs", "" + result.Get("docs")},
                            {"traceId", "" + result.Get("traceId")},
                        });
                    }
                    return TeaModel.ToObject<AppStatisticsInfoResponse>(TeaConverter.merge<object>
                    (
                        result
                    ));
                }
                catch (Exception e)
                {
                    if (TeaCore.IsRetryable(e))
                    {
                        _lastException = e;
                        continue;
                    }
                    throw e;
                }
            }

            throw new TeaUnretryableException(_lastRequest, _lastException);
        }

        public static string TimeRFC3339()
        {
            return ToolsetLink.DarabonbaBaseCSharp.Client.TimeRFC3339();
        }

    }
}
