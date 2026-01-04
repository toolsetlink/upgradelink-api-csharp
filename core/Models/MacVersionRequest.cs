// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class MacVersionRequest : TeaModel {
        [NameInMap("macKey")]
        [Validation(Required=true)]
        public string MacKey { get; set; }

        [NameInMap("versionCode")]
        [Validation(Required=true)]
        public int? VersionCode { get; set; }

        [NameInMap("arch")]
        [Validation(Required=true)]
        public string Arch { get; set; }

    }

}
