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
    internal class RTCPeerConnectionAsync : BaseApi, IRTCPeerConnectionAsync
    {
        private RTCConfiguration _rtcConfiguration;

        private RTCPeerConnectionAsync(IJSRuntime jsRuntime, JsObjectRef jsObjectRef, RTCConfiguration rtcConfiguration) 
            : base(jsRuntime, jsObjectRef) 
        {
            _rtcConfiguration = rtcConfiguration;
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeBaseAsync();
        }

        public async Task<IRTCRtpSender> AddTrackAsync(IMediaStreamTrackAsync track, IMediaStreamAsync stream)
        {
            var x = (MediaStreamTrackAsync)track;
            var jsObjectRefRtcRtpSender = await JsRuntime.CallJsMethod<JsObjectRef>(JsObjectRef, "addTrack", new object[] 
            { 
                ((MediaStreamTrackAsync)track).JsObjectRef,
                ((MediaStreamAsync)stream).JsObjectRef
            });
            var rtcRtpSender = RTCRtpSender.New(JsRuntime, jsObjectRefRtcRtpSender);
            return rtcRtpSender;
        }

        public async Task<IRTCSessionDescription> CreateOfferAsync(RTCOfferOptions options)
        {
            var jsObjectRefRtcSessionDescription = await JsRuntime.CallJsMethodAsync<JsObjectRef>(JsObjectRef, 
                "createOffer", new object[] { });
            var rtcSessionDescription = await JsRuntime.GetJsPropertyValue<RTCSessionDescription>(
                jsObjectRefRtcSessionDescription, null,
                new
                {
                    type = true,
                    sdp = true
                });
            //// TODO: REMOVE JS OBJ REF
            return rtcSessionDescription;
        }


        public async Task<IAsyncDisposable> OnIceCandidateAsync(Func<IRTCPeerConnectionIceEvent, ValueTask> callback)
        {
            var ret = await JsRuntime.AddJsEventListener(JsObjectRef, null, "onicecandidate",
                JsEventHandler.New<IRTCPeerConnectionIceEvent>(async e => 
                { 
                    await callback.Invoke(e).ConfigureAwait(false); 
                },
                null, false)).ConfigureAwait(false);
            return ret;
        }

        public async Task<IAsyncDisposable> OnTrackAsync(Func<IRTCTrackEvent, ValueTask> callback)
        {
            var ret = await JsRuntime.AddJsEventListener(JsObjectRef, null, "ontrack",
                JsEventHandler.New<IRTCTrackEvent>(async e =>
                {
                    await callback.Invoke(e).ConfigureAwait(false);
                },
                null, false)).ConfigureAwait(false);
            return ret;
        }


        internal static async Task<IRTCPeerConnectionAsync> NewAsync(IJSRuntime jsRuntime, RTCConfiguration rtcConfiguration)
        {
            var jsObjectRef = await jsRuntime.CreateJsObject("window", "RTCPeerConnection", new object());
            var rtcPeerConnection = new RTCPeerConnectionAsync(jsRuntime, jsObjectRef, rtcConfiguration);
            return rtcPeerConnection;
        }

    }
}
