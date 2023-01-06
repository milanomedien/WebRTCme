﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRTCme.Bindings.Maui.MacCatalyst.Custom;

namespace WebRTCme.Bindings.Maui.MacCatalyst.Api
{
    internal class RTCPeerConnectionIceEvent : NativeBase<SIPSorcery.Net.RTCIceCandidate>, IRTCPeerConnectionIceEvent
    {
        private readonly SIPSorcery.Net.RTCIceCandidate _nativeIceCandidate;

        public RTCPeerConnectionIceEvent(SIPSorcery.Net.RTCIceCandidate nativeIceCandidate)
        {
            _nativeIceCandidate = nativeIceCandidate;
        }

        public IRTCIceCandidate Candidate =>
            new RTCIceCandidate(_nativeIceCandidate);

        public void Dispose()
        {
        }
    }
}
