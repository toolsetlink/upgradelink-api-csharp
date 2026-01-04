// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class FileUpgradeResponse : TeaModel {
        [NameInMap("code")]
        [Validation(Required=true)]
        public int? Code { get; set; }

        [NameInMap("msg")]
        [Validation(Required=true)]
        public string Msg { get; set; }

        [NameInMap("traceId")]
        [Validation(Required=true)]
        public string TraceId { get; set; }

        [NameInMap("data")]
        [Validation(Required=true)]
        public FileUpgradeDataResponse Data { get; set; }

    }

}
