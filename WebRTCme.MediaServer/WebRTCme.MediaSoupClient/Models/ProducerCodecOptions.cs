﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebRTCme.MediaSoupClient.Models
{
    class ProducerCodecOptions
    {
        public bool? OpusStereo { get; init; } 
        public bool? OpusFec { get; init; }
        public bool? OpusDtx { get; init; }
        public int? OpusMaxPlaybackRate { get; init; } 
        public int? OpusMaxAvergaeBitrate { get; init; }
        public int? OpusPtime { get; init; }
        public int? VideoGoogleStartBitrate { get; init; } 
        public int? VideoGoogleMaxBitrate { get; init; }
        public int? VideoGoogleMinBitrate { get; init; }
    }
}
