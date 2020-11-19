﻿using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebRtc.iOS;
using Webrtc;

namespace WebRTCme
{
    internal class WebRtc : IWebRtc
    {
        private static RTCPeerConnectionFactory _nativePeerConnectionFactory;
        public static RTCPeerConnectionFactory NativePeerConnectionFactory =>
            _nativePeerConnectionFactory ?? (_nativePeerConnectionFactory = new RTCPeerConnectionFactory(
                new RTCDefaultVideoEncoderFactory(),
                new RTCDefaultVideoDecoderFactory()));

        public static Task<IWebRtc> CreateAsync()
        {
            var ret = new WebRtc();
            return ret.InitializeAsync();
        }

        private Task<IWebRtc> InitializeAsync()
        {
            ////CFunctions.InitFieldTrialDictionary(new Dictionary<string, string>());
            ////CFunctionsRTCSetupInternalTracer();
            CFunctions.RTCInitializeSSL();

            return Task.FromResult(this as IWebRtc);
        }

        public Task CleanupAsync()
        {
            ////CFunctions.RTCShutdownInternalTracer();
            CFunctions.RTCCleanupSSL();

            return Task.CompletedTask;
        }

        Task<IWindow> IWebRtc.Window(IJSRuntime jsRuntime)
        {
            return Task.FromResult(new Window() as IWindow);
        }
    }
}
