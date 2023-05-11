// Sound Reactor
// Copyright (c) 2018, Little Dreamer Games, All Rights Reserved
// Please visit us at littledreamergames.com

using System;
using UnityEngine;

namespace LDG.SoundReactor
{
    public enum ChannelVoiceMessage
    {
        NoteOff = 0x80,
        NoteOn = 0x90,
        PolyphonicPressure = 0xA0,
        ControlChange = 0xB0,
        ProgramChange = 0xC0,
        ChannelPressure = 0xD0,
        PitchWheelChange = 0xE0
    }

    [Serializable]
    public struct MidiEvent
    {
        /// <summary>
        /// Empty event that is only allocated once.
        /// </summary>
        static public MidiEvent Empty = new MidiEvent();

        #region Fields
        /// <summary>
        /// Track this event belongs to
        /// </summary>
        [NonSerialized]
        public short TrackIndex;

        /// <summary>
        /// Tempo this event was played at. A MIDI always starts with 2 beats per seconds, aka 120 beats per minute.
        /// </summary>
        [NonSerialized]
        public double Tempo;

        /// <summary>
        /// Ticks in micro ticks since the last event. The first event always has a value of 0.
        /// </summary>
        public int DeltaTicks;

        /// <summary>
        /// Ticks in micro ticks since the beginning of the track.
        /// </summary>
        public int Ticks;

        /// <summary>
        /// Ticks in micro ticks this note is held down for. To convert to seconds, it's: HoldTicks / Divisions / Current Tempo (in beats per second)
        /// </summary>
        public int HoldTicks;

        /// <summary>
        /// Time in seconds since the beginning of the track.
        /// </summary>
        public float Time;

        /// <summary>
        /// Time in seconds this note is held down for.
        /// </summary>
        public float HoldTime;

        /// <summary>
        /// Index into MetaMessages array stored in MidiClip.
        /// </summary>
        public ushort MetaMessageIndex;

        /// <summary>
        /// Reference to meta message if IsMetaMessage is true, otherwise it's null.
        /// </summary>
        [NonSerialized]
        public MetaMessage MetaMessage;

        /// <summary>
        /// Defines what kind of midi event this is.
        /// </summary>
        public byte Status;

        /// <summary>
        /// Contains channel voice data.
        /// </summary>
        public byte Data1;

        /// <summary>
        /// Contains channel voice data.
        /// </summary>
        public byte Data2;
        #endregion

        #region Properties
        /// <summary>
        /// Retrieves the message from the Status byte when the Status byte is for a Channel Voice Message
        /// </summary>
        public ChannelVoiceMessage ChannelVoiceMessage
        {
            get
            {
                return (ChannelVoiceMessage)(Status & 0xF0);
            }
        }

        /// <summary>
        /// Retrieves the channel from a Status byte when the Status byte is for a Channel Voice Message
        /// </summary>
        public int Channel
        {
            get
            {
                return (Status & 0x0F);
            }
        }

        /// <summary>
        /// Checks if the current byte is a status byte or not.
        /// </summary>
        public bool IsRunningStatus
        {
            get
            {
                // [0, 127]
                return (Status < 0x80);
            }
        }
        
        public bool IsChannelModeMessage
        {
            get
            {
                // [121, 127]
                return (Status >= 0x79 && Status <= 0x7F);
            }
        }

        /// <summary>
        /// Returns true if this event should be handled as a Channel Voice Message
        /// </summary>
        public bool IsChannelVoiceMessage
        {
            get
            {
                // [128, 239]
                return (Status >= 0x80 && Status <= 0xEF);
            }
        }

        /// <summary>
        /// Returns true if the event should be handled as a SyseEx Message.
        /// </summary>
        public bool IsSystemExclusiveMessage
        {
            get
            {
                // [240, 247]
                return (Status >= 0xF0 && Status <= 0xF7);
            }
        }

        /// <summary>
        /// Returns true if this event has a meta message associated with it.
        /// </summary>
        public bool IsMetaMessage
        {
            get
            {
                // [255]
                return (Status == 0xFF);
            }
        }

        /// <summary>
        /// Channel Voice Message - Note [0, 127]
        /// </summary>
        public byte Note { get { return Data1; } set { Data1 = value; } }

        /// <summary>
        /// Channel Voice Message - Velocity [0, 127]
        /// </summary>
        public byte Velocity { get { return Data2; } set { Data2 = value; } }

        [NonSerialized]
        /// <summary>
        /// Channel Voice Message - Normalized Velocity [0.0, 1.0]
        /// </summary>
        public float NormalizedVelocity;

        /// <summary>
        /// Channel Voice Message - Program Number
        /// </summary>
        public byte ProgramNumber { get { return Data1; } set { Data1 = value; } }

        /// <summary>
        /// Channel Voice Message - Polyphonic Pressure
        /// </summary>
        public byte PolyphonicPressure { get { return Data2; } set { Data2 = value; } }

        /// <summary>
        /// Channel Voice Message - Channel Pressure
        /// </summary>
        public byte ChannelPressure { get { return Data1; } set { Data1 = value; } }
        #endregion

        #region Public Methods
        public void ClearData()
        {
            DeltaTicks = 0;
            
            Data1 = 0;
            Data2 = 0;
        }

        public void Read(MidiReader reader)
        {
            switch (ChannelVoiceMessage)
            {
                case ChannelVoiceMessage.NoteOff:
                    // note
                    Data1 = reader.ReadByte();

                    // velocity
                    Data2 = reader.ReadByte();
                    break;

                case ChannelVoiceMessage.NoteOn:
                    // note
                    Data1 = reader.ReadByte();

                    // velocity
                    Data2 = reader.ReadByte();
                    break;

                case ChannelVoiceMessage.PolyphonicPressure:
                    // note
                    Data1 = reader.ReadByte();

                    // pressure
                    Data2 = reader.ReadByte();
                    break;

                case ChannelVoiceMessage.PitchWheelChange:
                    //Debug.Log("pitch wheel change");
                    Data1 = reader.ReadByte();
                    Data2 = reader.ReadByte();
                    break;
                case ChannelVoiceMessage.ControlChange:
                    Data1 = reader.ReadByte(); // 64 is sustain

                    // when data1 is 64
                    // sustain off < 64
                    // sustain on >= 64
                    Data2 = reader.ReadByte();

                    //Debug.Log("control change: " + midiEvent.data1 + ", " + midiEvent.data2);
                    break;

                case ChannelVoiceMessage.ProgramChange:
                    //Debug.Log("program change");
                    Data1 = reader.ReadByte();
                    break;
                case ChannelVoiceMessage.ChannelPressure:
                    //Debug.Log("channel pressure");
                    Data1 = reader.ReadByte();
                    break;
            }
        }

        public void Write(MidiWriter writer)
        {
            writer.WriteVLQ(DeltaTicks);
            writer.Write(Status);

            if (IsMetaMessage)
            {
                MetaMessage.Write(writer);

                return;
            }
            
            if(IsChannelVoiceMessage)
            {
                switch (ChannelVoiceMessage)
                {
                    case ChannelVoiceMessage.NoteOff:
                    case ChannelVoiceMessage.NoteOn:
                    case ChannelVoiceMessage.PolyphonicPressure:
                    case ChannelVoiceMessage.ControlChange:
                        writer.Write(Data1);
                        writer.Write(Data2);
                        break;

                    case ChannelVoiceMessage.ProgramChange:
                    case ChannelVoiceMessage.ChannelPressure:
                        writer.Write(Data1);
                        break;
                }

                return;
            }

            Debug.LogError("MIDI Message not supported");
        }
		
		public void SetNoteOnMessage(byte note, byte velocity, int ticks)
        {
            Status = (byte)ChannelVoiceMessage.NoteOn;

            Note = note;
            Velocity = velocity;

            Ticks = ticks;
        }

        public void SetNoteOffMessage(byte note, byte velocity, int ticks)
        {
            Status = (byte)ChannelVoiceMessage.NoteOff;

            Note = note;
            Velocity = velocity;

            Ticks = ticks;
        }

        public void SetEvent(byte status, byte note, byte velocity, int ticks)
        {
            Status = status;

            Note = note;
            Velocity = velocity;

            Ticks = ticks;
        }

        public void SetMetaMessage(MetaMessage metaMessage, int ticks)
        {
            Status = 255;

            MetaMessage = metaMessage;

            Ticks = ticks;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(MidiEvent other)
        {
            return other.Ticks == Ticks && other.Status == Status && other.Data1 == Data1 && other.Data2 == Data2;
        }
        
        public static bool operator ==(MidiEvent lhs, MidiEvent rhs)
        {
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(MidiEvent lhs, MidiEvent rhs)
		{
			return !(lhs == rhs);
		}
        
        #endregion
    }
}