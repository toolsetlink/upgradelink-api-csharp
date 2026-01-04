// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class WinUpgradeDataResponse : TeaModel {
        [NameInMap("winKey")]
        [Validation(Required=true)]
        public string WinKey { get; set; }

        [NameInMap("packageName")]
        [Validation(Required=true)]
        public string PackageName { get; set; }

        [NameInMap("versionName")]
        [Validation(Required=true)]
        public string VersionName { get; set; }

        [NameInMap("versionCode")]
        [Validation(Required=true)]
        public int? VersionCode { get; set; }

        [NameInMap("urlPath")]
        [Validation(Required=true)]
        public string UrlPath { get; set; }

        [NameInMap("urlFileSize")]
        [Validation(Required=true)]
        public int? UrlFileSize { get; set; }

        [NameInMap("urlFileMd5")]
        [Validation(Required=true)]
        public string UrlFileMd5 { get; set; }

        [NameInMap("upgradeType")]
        [Validation(Required=true)]
        public int? UpgradeType { get; set; }

        [NameInMap("promptUpgradeContent")]
        [Validation(Required=true)]
        public string PromptUpgradeContent { get; set; }

    }

}
