// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class WinVersionDataResponse : TeaModel {
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

        [NameInMap("description")]
        [Validation(Required=true)]
        public string Description { get; set; }

    }

}
