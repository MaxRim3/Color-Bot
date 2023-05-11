// Sound Reactor
// Copyright (c) 2018, Little Dreamer Games, All Rights Reserved
// Please visit us at littledreamergames.com

using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace LDG.SoundReactor
{
    public class MidiWriter : BinaryWriter
    {
        #region Fields
        // default to Intel endian, which is little endian.
        private bool isLittleEndian = true;

        private const uint maxVLQ = uint.MaxValue >> 4;

        private Queue chunkPos = new Queue();
        #endregion

        #region Constructors
        public MidiWriter(Stream input) : base(input)
        {
        }

        public MidiWriter(Stream input, bool isLittleEndian = true) : base(input)
        {
            this.isLittleEndian = isLittleEndian;
        }

        public MidiWriter()
        {
            chunkPos = new Queue();
        }
        #endregion

        public void ResetChunk()
        {
            chunkPos.Clear();
        }

        public void PushChunk(Action<MidiWriter, string> writeChunk, string id, bool includeIdInChunk)
        {
            if (!includeIdInChunk)
            {
                writeChunk(this, id);
                //Debug.Log($"Pushed: Chunk Id: {id}, Chunk Data Begin: {base.BaseStream.Position}, Inclusive: {inclusive.ToString()}");
            }

            chunkPos.Enqueue(base.BaseStream.Position);

            if (includeIdInChunk)
            {
                //Debug.Log($"Pushed: Chunk Id: {id}, Chunk Data Begin: {base.BaseStream.Position}, Inclusive: {inclusive.ToString()}");
                writeChunk(this, id);
            }
        }

        public void PopChunk(Action<MidiWriter, long> writeChunkSize)
        {
            long position = (long)chunkPos.Dequeue();
            long size = base.BaseStream.Position - position;

            base.BaseStream.Position = position;
            writeChunkSize(this, size);
            base.BaseStream.Position = position + size;

            //Debug.Log($"Popped: Chunk Size: {size}, Chunk Data End: {base.BaseStream.Position}");
        }

        public void WriteBytes(byte[] bytes, bool resolveEndian)
        {
            if (isLittleEndian != BitConverter.IsLittleEndian && resolveEndian)
            {
                Array.Reverse(bytes);
            }

            base.Write(bytes);

            if (isLittleEndian != BitConverter.IsLittleEndian && resolveEndian)
            {
                Array.Reverse(bytes);
            }
        }

        public void WriteBytes(byte[] bytes, int count, bool resolveEndian)
        {
            Array.Resize(ref bytes, count);

            if (isLittleEndian != BitConverter.IsLittleEndian && resolveEndian)
            {
                Array.Reverse(bytes);
            }

            base.Write(bytes);

            if (isLittleEndian != BitConverter.IsLittleEndian && resolveEndian)
            {
                Array.Reverse(bytes);
            }
        }

        /// <summary>
        /// Writes variable length quanity
        /// 
        /// Reference:
        /// https://en.wikipedia.org/wiki/Variable-length_quantity
        /// </summary>
        public void WriteVLQ(uint v)
        {
            if (v > maxVLQ)
            {
                Debug.Log(string.Format("WriteVLQ Error: {0} cannot be greater than {1}.", v, maxVLQ));
                throw new Exception(string.Format("WriteVLQ Error: {0} cannot be greater than {1}.", v, maxVLQ));
            }

            uint buffer;
            buffer = v & 0x7F;

            // build variable length byte buffer.
            while ((v >>= 7) > 0)
            {
                buffer <<= 8;

                // 0x7F = 0111 1111
                // 0x80 = 1000 0000
                buffer |= ((v & 0x7F) | 0x80);
            }

            // now write the buffer
            while(true)
            {
                // write the least significant byte
                base.Write((byte)buffer);

                // 0x80 = 1000 0000
                if ((buffer & 0x80) == 0x80)
                    buffer >>= 8;
                else
                    break;
            }
        }

        public void WriteVLQ(int v)
        {
            WriteVLQ((uint)v);
        }

        #region Overrides
        public override void Write(ushort value)
        {
            int v = value;

            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                v = (v << 8) | ((v >> 8) & 0xFF);
            }

            base.Write((ushort)v);
        }

        public override void Write(short value)
        {
            Write((ushort)value);
        }

        public override void Write(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            base.Write(BitConverter.ToSingle(bytes, 0));
        }

        public override void Write(uint value)
        {
            uint v = value;

            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                v = ((v << 8) & 0xFF00FF00) | ((v >> 8) & 0xFF00FF);
                v = (v << 16) | ((v >> 16) & 0xFFFF);
            }

            base.Write(v);
        }

        public override void Write(int v)
        {
            Write((uint)v);
        }
        #endregion
    }
}