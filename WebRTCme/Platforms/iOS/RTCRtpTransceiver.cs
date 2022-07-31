﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebRTCme;
using WebRTCme.Platforms.iOS.Custom;

namespace WebRTCme.iOS
{
    internal class RTCRtpTransceiver : NativeBase<Webrtc.IRTCRtpTransceiver>, IRTCRtpTransceiver
    {
        public static IRTCRtpTransceiver Create(Webrtc.IRTCRtpTransceiver nativeRtpTransceiver) => 
            new RTCRtpTransceiver(nativeRtpTransceiver);

        public RTCRtpTransceiver(Webrtc.IRTCRtpTransceiver nativeRtpTransceiver) : base(nativeRtpTransceiver) { }

        public RTCRtpTransceiverDirection CurrentDirection => NativeObject.Direction
            .FromNative();

        public RTCRtpTransceiverDirection Direction 
        { 
            get => NativeObject.Direction.FromNative();
            set => NativeObject.SetDirection(value.ToNative(), out NSError _);
        }

        public string Mid => NativeObject.Mid;

        public IRTCRtpReceiver Receiver => RTCRtpReceiver.Create(NativeObject.Receiver);

        public IRTCRtpSender Sender => RTCRtpSender.Create(NativeObject.Sender);

        public bool Stopped => NativeObject.IsStopped;


        public void SetCodecPreferences(RTCRtpCodecCapability[] codecs)
        {
            throw new NotImplementedException();
        }

        public void Stop() => NativeObject.StopInternal();

    }
}
