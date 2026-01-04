// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class AppReportRequest : TeaModel {
        [NameInMap("eventType")]
        [Validation(Required=true)]
        public string EventType { get; set; }

        [NameInMap("appKey")]
        [Validation(Required=true)]
        public string AppKey { get; set; }

        [NameInMap("timestamp")]
        [Validation(Required=false)]
        public string Timestamp { get; set; }

        [NameInMap("eventData")]
        [Validation(Required=true)]
        public AppReportRequestEventData EventData { get; set; }
        public class AppReportRequestEventData : TeaModel {
            [NameInMap("launchTime")]
            [Validation(Required=false)]
            public string LaunchTime { get; set; }

            [NameInMap("versionCode")]
            [Validation(Required=true)]
            public int? VersionCode { get; set; }

            [NameInMap("devModelKey")]
            [Validation(Required=false)]
            public string DevModelKey { get; set; }

            [NameInMap("devKey")]
            [Validation(Required=false)]
            public string DevKey { get; set; }

            [NameInMap("target")]
            [Validation(Required=false)]
            public string Target { get; set; }

            [NameInMap("arch")]
            [Validation(Required=false)]
            public string Arch { get; set; }

            [NameInMap("downloadVersionCode")]
            [Validation(Required=false)]
            public int? DownloadVersionCode { get; set; }

            [NameInMap("upgradeVersionCode")]
            [Validation(Required=false)]
            public int? UpgradeVersionCode { get; set; }

            [NameInMap("code")]
            [Validation(Required=false)]
            public int? Code { get; set; }

        }

    }

}
