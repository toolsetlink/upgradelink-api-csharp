// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class LnxUpgradeRequest : TeaModel {
        [NameInMap("lnxKey")]
        [Validation(Required=true)]
        public string LnxKey { get; set; }

        [NameInMap("arch")]
        [Validation(Required=true)]
        public string Arch { get; set; }

        [NameInMap("versionCode")]
        [Validation(Required=true)]
        public int? VersionCode { get; set; }

        [NameInMap("appointVersionCode")]
        [Validation(Required=true)]
        public int? AppointVersionCode { get; set; }

        [NameInMap("devModelKey")]
        [Validation(Required=true)]
        public string DevModelKey { get; set; }

        [NameInMap("devKey")]
        [Validation(Required=true)]
        public string DevKey { get; set; }

    }

}
