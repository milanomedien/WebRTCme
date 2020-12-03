﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebRtcJsInterop.Extensions;
using WebRtcJsInterop.Interops;
using WebRTCme;

namespace WebRtcJsInterop.Api
{
    internal class RTCPeerConnection : ApiBase, IRTCPeerConnection
    {
        public bool CanTrickleIceCandidates => JsRuntime.GetJsPropertyValue<bool>(
            NativeObject, "canTrickleIceCandidates");

        public RTCPeerConnectionState ConnectionState => RTCPeerConnectionState.New;  //JsRuntime.GetJsPropertyValue<RTCPeerConnectionState>(
            //NativeObject, "connectionState");

        public IRTCSessionDescription CurrentRemoteDescription => throw new NotImplementedException();

        public RTCIceConnectionState IceConnectionState => JsRuntime.GetJsPropertyValue<RTCIceConnectionState>(
            NativeObject, "iceConnectionState");

        public RTCIceGatheringState IceGatheringState => throw new NotImplementedException();

        public IRTCSessionDescription LocalDescription => throw new NotImplementedException();

        public Task<IRTCIdentityAssertion> PeerIdentity => throw new NotImplementedException();

        public IRTCSessionDescription PendingLocalDescription => throw new NotImplementedException();

        public IRTCSessionDescription PendingRemoteDescription => throw new NotImplementedException();

        public IRTCSessionDescription RemoteDescription => throw new NotImplementedException();

        public IRTCSctpTransport Sctp => throw new NotImplementedException();

        public RTCSignallingState SignallingState => throw new NotImplementedException();

        public event EventHandler OnConnectionStateChanged;
        public event EventHandler<IRTCDataChannelEvent> OnDataChannel;
        public event EventHandler<IRTCPeerConnectionIceEvent> OnIceCandidate;
        public event EventHandler OnIceConnectionStateChange;
        public event EventHandler OnIceGatheringStateChange;
        public event EventHandler<IRTCIdentityEvent> OnIdentityResult;
        public event EventHandler OnNegotiationNeeded;
        public event EventHandler OnSignallingStateChange;
        public event EventHandler<IRTCTrackEvent> OnTrack;

        internal static IRTCPeerConnection Create(IJSRuntime jsRuntime, RTCConfiguration rtcConfiguration)
        {
            var jsObjectRef = jsRuntime.CreateJsObject("window", "RTCPeerConnection");
            return new RTCPeerConnection(jsRuntime, jsObjectRef, rtcConfiguration);
        }

        private RTCPeerConnection() : base(null) { }

        private RTCPeerConnection(IJSRuntime jsRuntime, JsObjectRef jsObjectRef, RTCConfiguration rtcConfiguration) 
            : base(jsRuntime, jsObjectRef) 
        {
            AddNativeEventListener("onconnectionstatechanged", OnConnectionStateChanged);
            AddNativeEventListener("ondatachannel", OnDataChannel);
            AddNativeEventListener("onicecandidate", OnIceCandidate);
            AddNativeEventListener("oniceconnectionstatechange", OnIceConnectionStateChange);
            AddNativeEventListener("onicegatheringstatechange", OnIceGatheringStateChange);
            AddNativeEventListener("onidentityresult", OnIdentityResult);
            AddNativeEventListener("onnegotiationneeded", OnNegotiationNeeded);
            AddNativeEventListener("onsignallingstatechange", OnSignallingStateChange);
            AddNativeEventListener("onconnectionstatechanged", OnTrack);
        }

        public RTCIceServer[] GetDefaultIceServers()
        {
            throw new NotImplementedException();
        }


        public Task AddIceCandidate(IRTCIceCandidate candidate)
        {
            throw new NotImplementedException();
        }

        public IRTCRtpSender AddTrack(IMediaStreamTrack track, IMediaStream stream)
        {
            var jsObjectRefRtcRtpSender = JsRuntime.CallJsMethod<JsObjectRef>(NativeObject, "addTrack",
                new object[]
                {
                    ((MediaStreamTrack)track).NativeObject,
                    ((MediaStream)stream).NativeObject
                });
            var rtcRtpSender = RTCRtpSender.Create(JsRuntime, jsObjectRefRtcRtpSender);
            return rtcRtpSender;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Task<IRTCSessionDescription> CreateAnswer(RTCAnswerOptions options = null)
        {
            throw new NotImplementedException();
        }

        public IRTCDataChannel CreateDataChannel(string label, RTCDataChannelInit options = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IRTCSessionDescription> CreateOffer(RTCOfferOptions options)
        {
            var jsObjectRefRtcSessionDescription = await JsRuntime.CallJsMethodAsync<JsObjectRef>(
                NativeObject, "createOffer");
            var rtcSessionDescription = JsRuntime.GetJsPropertyValue<RTCSessionDescription>(
                jsObjectRefRtcSessionDescription, null,
                new
                {
                    type = true,
                    sdp = true
                });
            //// TODO: REMOVE JS OBJ REF
            return rtcSessionDescription;
        }


        /*static*/public Task<IRTCCertificate> GenerateCertificate()
        {
            throw new NotImplementedException();
        }

        public RTCConfiguration GetConfiguration()
        {
            throw new NotImplementedException();
        }

        public void GetIdentityAssertion()
        {
            throw new NotImplementedException();
        }

        public IRTCRtpReceiver[] GetReceivers()
        {
            throw new NotImplementedException();
        }

        public IRTCRtpSender[] GetSenders()
        {
            throw new NotImplementedException();
        }

        public Task<IRTCStatsReport> GetStats()
        {
            throw new NotImplementedException();
        }

        public IRTCRtpTransceiver[] GetTransceivers()
        {
            throw new NotImplementedException();
        }

        public void RemoveTrack(IRTCRtpSender sender)
        {
            throw new NotImplementedException();
        }

        public void RestartIce()
        {
            throw new NotImplementedException();
        }

        public void SetConfiguration(RTCConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void SetIdentityProvider(string domainName, string protocol = null, string userName = null)
        {
            throw new NotImplementedException();
        }

        public Task SetLocalDescription(IRTCSessionDescription sessionDescription)
        {
            throw new NotImplementedException();
        }

        public Task SetRemoteDescription(IRTCSessionDescription sessionDescription)
        {
            throw new NotImplementedException();
        }











        //public async Task<IAsyncDisposable> OnIceCandidate(Func<IRTCPeerConnectionIceEvent, ValueTask> callback)
        //{
        //    var ret = await JsRuntime.AddJsEventListener(NativeObject as JsObjectRef, null, "onicecandidate",
        //        JsEventHandler.Create<IRTCPeerConnectionIceEvent>(async e =>
        //        {
        //            await callback.Invoke(e).ConfigureAwait(false);
        //        },
        //        null, false)).ConfigureAwait(false);
        //    return ret;
        //}

        //public async Task<IAsyncDisposable> OnTrack(Func<IRTCTrackEvent, ValueTask> callback)
        //{
        //    var ret = await JsRuntime.AddJsEventListener(NativeObject as JsObjectRef, null, "ontrack",
        //        JsEventHandler.Create<IRTCTrackEvent>(async e =>
        //        {
        //            await callback.Invoke(e).ConfigureAwait(false);
        //        },
        //        null, false)).ConfigureAwait(false);
        //    return ret;
        //}



        private void AddNativeEventListener(string eventName, EventHandler eventHandler)
        {
            JsEvents.Add(JsRuntime.AddJsEventListener(NativeObject as JsObjectRef, null, eventName,
                JsEventHandler.Create(() =>
                {
                    eventHandler?.Invoke(this, EventArgs.Empty);
                },
                null, false)));
        }

        private void AddNativeEventListener<T>(string eventName, EventHandler<T> eventHandler)
        {
            JsEvents.Add(JsRuntime.AddJsEventListener(NativeObject as JsObjectRef, null, eventName,
                JsEventHandler.Create<T>(e =>
                {
                    eventHandler?.Invoke(this, e);
                },
                null, false)));
        }
    }
}