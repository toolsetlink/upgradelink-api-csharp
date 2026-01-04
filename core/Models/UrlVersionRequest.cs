// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class UrlVersionRequest : TeaModel {
        [NameInMap("urlKey")]
        [Validation(Required=true)]
        public string UrlKey { get; set; }

        [NameInMap("versionCode")]
        [Validation(Required=true)]
        public int? VersionCode { get; set; }

    }

}
