// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections.Generic;
using System.IO;

using Tea;

namespace ToolsetLink.UpgradeLinkApi.Models
{
    public class Config : TeaModel {
        [NameInMap("accessKey")]
        [Validation(Required=true)]
        public string AccessKey { get; set; }

        [NameInMap("accessSecret")]
        [Validation(Required=true)]
        public string AccessSecret { get; set; }

        [NameInMap("protocol")]
        [Validation(Required=true)]
        public string Protocol { get; set; }

        [NameInMap("endpoint")]
        [Validation(Required=true)]
        public string Endpoint { get; set; }

    }

}
