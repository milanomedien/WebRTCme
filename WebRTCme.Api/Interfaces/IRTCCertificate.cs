﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebRTCme
{
    public interface IRTCCertificate
    {
        Task<ulong> Expires { get; }
        //// RTCDtlsFingerprint[] GetFingerprints();
    }
}
