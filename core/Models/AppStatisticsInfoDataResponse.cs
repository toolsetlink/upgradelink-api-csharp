// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class AppStatisticsInfoDataResponse : TeaModel {
        [NameInMap("yesterdayDownloadCount")]
        [Validation(Required=true)]
        public int? YesterdayDownloadCount { get; set; }

        [NameInMap("totalDownloadCount")]
        [Validation(Required=true)]
        public int? TotalDownloadCount { get; set; }

        [NameInMap("yesterdayAppGetStrategyCount")]
        [Validation(Required=true)]
        public int? YesterdayAppGetStrategyCount { get; set; }

        [NameInMap("totalAppGetStrategyCount")]
        [Validation(Required=true)]
        public int? TotalAppGetStrategyCount { get; set; }

        [NameInMap("yesterdayAppUpgradeCount")]
        [Validation(Required=true)]
        public int? YesterdayAppUpgradeCount { get; set; }

        [NameInMap("totalAppUpgradeCount")]
        [Validation(Required=true)]
        public int? TotalAppUpgradeCount { get; set; }

        [NameInMap("yesterdayAppStartCount")]
        [Validation(Required=true)]
        public int? YesterdayAppStartCount { get; set; }

        [NameInMap("totalAppStartCount")]
        [Validation(Required=true)]
        public int? TotalAppStartCount { get; set; }

        [NameInMap("downloadCount7Day")]
        [Validation(Required=true)]
        public List<DownloadCount7DayInfo> DownloadCount7Day { get; set; }

        [NameInMap("appGetStrategyCount7Day")]
        [Validation(Required=true)]
        public List<AppGetStrategyCount7DayInfo> AppGetStrategyCount7Day { get; set; }

        [NameInMap("appUpgradeCount7Day")]
        [Validation(Required=true)]
        public List<AppUpgradeCount7DayInfo> AppUpgradeCount7Day { get; set; }

        [NameInMap("appStartCount7Day")]
        [Validation(Required=true)]
        public List<AppStartCount7DayInfo> AppStartCount7Day { get; set; }

    }

}
