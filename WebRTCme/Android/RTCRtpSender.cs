﻿using Webrtc = Org.Webrtc;
using System;
using WebRTCme;
using System.Threading.Tasks;

namespace WebRtc.Android
{
    internal class RTCRtpSender : ApiBase, IRTCRtpSender
    {
        internal static IRTCRtpSender Create(Webrtc.RtpSender nativeRtpSender) =>
            new RTCRtpSender(nativeRtpSender);

        private RTCRtpSender(Webrtc.RtpSender nativeRtpSender) : base(nativeRtpSender)
        {
        }

        public IRTCDTMFSender Dtmf => throw new NotImplementedException();

        public IMediaStreamTrack Track => throw new NotImplementedException();

        public IRTCDtlsTransport Transport => throw new NotImplementedException();


        public RTCRtpSendParameters GetParameters()
        {
            throw new NotImplementedException();
        }

        public Task<IRTCStatsReport> GetStats()
        {
            throw new NotImplementedException();
        }

        public Task SetParameters(RTCRtpSendParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void SetStreams(IMediaStream[] mediaStreams)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceTrack(IMediaStreamTrack newTrack = null)
        {
            throw new NotImplementedException();
        }

        public RTCRtpCapabilities GetCapabilities(string kind)
        {
            throw new NotImplementedException();
        }


    }
}