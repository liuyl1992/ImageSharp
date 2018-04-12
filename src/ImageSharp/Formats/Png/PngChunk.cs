﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Png
{
    /// <summary>
    /// Stores header information about a chunk.
    /// </summary>
    internal readonly struct PngChunk
    {
        public PngChunk(int length, string type, IManagedByteBuffer data = null, uint crc = default)
        {
            this.Length = length;
            this.Type = type;
            this.Data = data;
            this.Crc = crc;
        }

        /// <summary>
        /// Gets the length.
        /// An unsigned integer giving the number of bytes in the chunk's
        /// data field. The length counts only the data field, not itself,
        /// the chunk type code, or the CRC. Zero is a valid length
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Gets the chunk type as string with 4 chars.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the data bytes appropriate to the chunk type, if any.
        /// This field can be of zero length or null.
        /// </summary>
        public IManagedByteBuffer Data { get; }

        /// <summary>
        /// Gets a CRC (Cyclic Redundancy Check) calculated on the preceding bytes in the chunk,
        /// including the chunk type code and chunk data fields, but not including the length field.
        /// The CRC is always present, even for chunks containing no data
        /// </summary>
        public uint Crc { get; }

        /// <summary>
        /// Gets a value indicating whether the given chunk is critical to decoding
        /// </summary>
        public bool IsCritical =>
            this.Type == PngChunkTypes.Header ||
            this.Type == PngChunkTypes.Palette ||
            this.Type == PngChunkTypes.Data ||
            this.Type == PngChunkTypes.End;
    }
}
