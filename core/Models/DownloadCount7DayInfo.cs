// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class DownloadCount7DayInfo : TeaModel {
        [NameInMap("timeData")]
        [Validation(Required=true)]
        public string TimeData { get; set; }

        [NameInMap("data")]
        [Validation(Required=true)]
        public int? Data { get; set; }

    }

}
