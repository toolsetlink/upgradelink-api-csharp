// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class TauriVersionDataResponse : TeaModel {
        [NameInMap("tauriKey")]
        [Validation(Required=true)]
        public string TauriKey { get; set; }

        [NameInMap("versionName")]
        [Validation(Required=true)]
        public string VersionName { get; set; }

        [NameInMap("versionCode")]
        [Validation(Required=true)]
        public int? VersionCode { get; set; }

        [NameInMap("target")]
        [Validation(Required=true)]
        public string Target { get; set; }

        [NameInMap("arch")]
        [Validation(Required=true)]
        public string Arch { get; set; }

        [NameInMap("description")]
        [Validation(Required=true)]
        public string Description { get; set; }

    }

}
