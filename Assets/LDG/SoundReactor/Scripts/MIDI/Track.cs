// Sound Reactor
// Copyright (c) 2018, Little Dreamer Games, All Rights Reserved
// Please visit us at littledreamergames.com

using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace LDG.SoundReactor
{
    /// <summary>
    /// Contains MidiEvents for a particular track.
    /// </summary>
    [Serializable]
    public class Track
    {
        #region Properties
        public short TrackIndex { get { return trackIndex; } }

        public bool IsValid { get { return (containsNotes || containsTempo); } }

        [SerializeField]
        private string name = "";

        public string Name
        {
            get
            {
                return name;
            }
        }
        #endregion

        #region Fields
        private List<MidiEvent> midiEventList = new List<MidiEvent>();

        [SerializeField]
        private MidiEvent[] midiEvents;

        private MidiEvent midiEvent;
        private MidiEvent midiEventPrev;

        private bool containsNotes = false;
        private bool containsTempo = false;

        [SerializeField]
        private short trackIndex;
        #endregion

        #region Constructors
        public Track(short trackIndex, string name)
        {
            this.trackIndex = trackIndex;
            this.name = name;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Bypasses data block
        /// </summary>
        private void ReadPastData(MidiReader reader)
        {
            // read data length
            int length = (int)reader.ReadVLQ();

            // skip this data
            reader.BaseStream.Position += length;
        }

        /// <summary>
        /// Bypasses System Exclusive event.
        /// </summary>
        private void ReadSystemCommonMessage(MidiReader reader)
        {
            ReadPastData(reader);
        }

        /// <summary>
        /// Read the Channel Voice Message, but only grab note state. Call this just after reading and interpreting the Status byte.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="midiEvent"></param>
        private void ReadChannelVoiceMessage(MidiReader reader, ref MidiEvent midiEvent)
        {
            midiEvent.Read(reader);

            if(midiEvent.ChannelVoiceMessage == ChannelVoiceMessage.NoteOn)
            {
                containsNotes = true;
            }
        }

        private void CalculateTicks()
        {
            int ticks = 0;

            // calculate absolute ticks
            for (int i = 0; i < midiEvents.Length; i++)
            {
                ticks += midiEvents[i].DeltaTicks;
                midiEvents[i].Ticks = ticks;
                midiEvents[i].HoldTicks = 0;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Used for converting ticks to seconds. The number of time maps will equal the number of tempo entries
        /// in the MIDI file. The time maps are only allocated once when converting a .mid file to the .mid.asset
        /// file.
        /// </summary>
        public TempoRegion [] CreateTempoRegions(MetaMessage[] metaMessages, Header header, int defaultTempo)
        {
            return TempoUtil.CreateTempoRegions(midiEvents, metaMessages, header, defaultTempo);
        }

        public void GetChannelVoiceMessages(int trackIndex, List<MidiEvent> midiEvents)
        {
            foreach(MidiEvent me in this.midiEvents)
            {
                if (me.IsChannelVoiceMessage)
                {
                    midiEvents.Add(me);
                }
            }
        }

        public void GetMetaMessages(int trackIndex, List<MidiEvent> midiEvents)
        {
            foreach (MidiEvent me in this.midiEvents)
            {
                if (me.IsMetaMessage)
                {
                    midiEvents.Add(me);
                }
            }
        }

        public void GetMidiEvents(int trackIndex, List<MidiEvent> midiEvents)
        {
            foreach (MidiEvent me in this.midiEvents)
            {
                midiEvents.Add(me);
            }
        }

        public IEnumerable<MidiEvent> ChannelVoiceMessages
        {
            get
            {
                if (midiEvents.Length == 0) yield break;

                foreach (MidiEvent me in midiEvents)
                {
                    if (me.IsChannelVoiceMessage)
                    {
                        yield return me;
                    }
                }
            }
        }

        public IEnumerable<MidiEvent> MetaMessages
        {
            get
            {
                if (midiEvents.Length == 0) yield break;

                foreach (MidiEvent me in midiEvents)
                {
                    if (me.IsMetaMessage && me.MetaMessage != null)
                    {
                        yield return me;
                    }
                }
            }
        }

        public IEnumerable<MidiEvent> MidiEvents
        {
            get
            {
                if (midiEvents.Length == 0) yield break;

                foreach (MidiEvent me in midiEvents)
                {
                    yield return me;
                }
            }
        }

        public void RemapTicksToTime(TempoRegion[] tempoRegions, int division)
        {
            TempoUtil.RemapTicksToTimeA(midiEvents, tempoRegions, division);
        }

        public void Read(MidiReader reader, List<MetaMessage> metaMessageList, ref ushort metaMessageIndex, long trackEndPos)
        {
            midiEvent.Ticks = 0;
            midiEvent.DeltaTicks = 0;

            if (trackEndPos > reader.BaseStream.Length)
            {
                Debug.Log("Track chunk size overflows past the IO stream");
            }

            //while (reader.BaseStream.Position < reader.BaseStream.Length)
            while (reader.BaseStream.Position < trackEndPos)
            {
                midiEvent.ClearData();
                midiEvent.DeltaTicks = (int)reader.ReadVLQ();
                midiEvent.Status = reader.ReadByte();

                // check for running status. all values 128 and above are considered events and messages, but
                // any value 127 and below are considered data for Channel Voices, so process those until a
                // NoteOn with a zero velocity is detected.
                // http://midi.teragonaudio.com/tech/midispec/run.htm
                if(midiEvent.IsRunningStatus)
                {
                    // not doing this caused hours of debugging :(
                    reader.BaseStream.Position -= 1;

                    // running status, so use the previous event's status
                    midiEvent.Status = midiEventPrev.Status;

                    ReadChannelVoiceMessage(reader, ref midiEvent);
                    
                    midiEventList.Add(midiEvent);
                }
                else
                {
                    if (midiEvent.IsMetaMessage)
                    {
                        MetaMessage metaMessage = new MetaMessage();

                        metaMessage.Read(reader);
                        metaMessageList.Add(metaMessage);

                        if(metaMessage.MetaType == MetaType.TrackName)
                        {
                            string name = metaMessage.TrackName;

                            this.name = (name != "") ? name : this.name;
                        }

                        if(metaMessage.MetaType == MetaType.Tempo)
                        {
                            containsTempo = true;
                        }

                        midiEvent.MetaMessageIndex = metaMessageIndex++;
                        midiEventList.Add(midiEvent);
                        
                        if (metaMessage.MetaType == MetaType.EndOfTrack)
                        {
                            break;
                        }
                    }

                    if (midiEvent.IsSystemExclusiveMessage)
                    {
                        // skip
                        ReadSystemCommonMessage(reader);
                    }

                    if (midiEvent.IsChannelVoiceMessage)
                    {
                        ReadChannelVoiceMessage(reader, ref midiEvent);
                        midiEventList.Add(midiEvent);
                        
                        // remember this status so we can use it as a running status, if required
                        midiEventPrev = midiEvent;
                    }
                }
            }

            midiEvents = midiEventList.ToArray();
            midiEventList.Clear();

            CalculateTicks();
            AssignMetaMessages(metaMessageList);
        }

        private void AssignMetaMessages(List<MetaMessage> metaMessageList)
        {
            for (int i = 0; i < midiEvents.Length; i++)
            {
                midiEvents[i].MetaMessage = metaMessageList[midiEvents[i].MetaMessageIndex];
            }
        }

        public int CountNotes()
        {
            int noteCount = 0;

            // first calculate absolute ticks
            for (int i = 0; i < midiEvents.Length; i++)
            {
                if(midiEvents[i].IsChannelVoiceMessage && midiEvents[i].ChannelVoiceMessage == ChannelVoiceMessage.NoteOn)
                {
                    if (midiEvents[i].Velocity != 0)
                    {
                        noteCount++;
                    }
                }
            }

            return noteCount;
        }

        public void CalculateHoldTime()
        {
            int note = 0;

            // calculate hold time in seconds and in ticks for each note on event
            for (int i = 0; i < midiEvents.Length; i++)
            {
                if (midiEvents[i].IsChannelVoiceMessage &&
                    midiEvents[i].ChannelVoiceMessage == ChannelVoiceMessage.NoteOn &&
                    midiEvents[i].Velocity != 0.0f)
                {
                    note = midiEvents[i].Note;
                    
                    // search forward for a note off or zero velocity for the current note
                    for (int j = i + 1; j < midiEvents.Length; j++)
                    {
                        if (midiEvents[j].Note == note)
                        {
                            if ((midiEvents[j].ChannelVoiceMessage == ChannelVoiceMessage.NoteOff) ||
                                (midiEvents[j].ChannelVoiceMessage == ChannelVoiceMessage.NoteOn && midiEvents[j].Velocity == 0.0f))
                            {
                                midiEvents[i].HoldTicks = midiEvents[j].Ticks - midiEvents[i].Ticks;
                                midiEvents[i].HoldTime = midiEvents[j].Time - midiEvents[i].Time;

                                break;
                            }
                        }
                    }
                }
            }
        }

        public int GetMaxTicks(int ticks)
        {
            for (int i = 0; i < midiEvents.Length; i++)
            {
                ticks = Mathf.Max(ticks, midiEvents[i].Ticks);
            }

            return ticks;
        }

        public float GetMaxLength(float length)
        {
            for (int i = 0; i < midiEvents.Length; i++)
            {
                length = Mathf.Max(length, midiEvents[i].Time);
            }

            return length;
        }

        /// <summary>
        /// Seeks to a specific time in a MIDI clip. Events are not raised.
        /// </summary>
        public void Seek(SequencerInternal sequencerInternal, float time, MidiEventHandler handler)
        {
            int eventIndex = 0;

            if (time < 0.0f) return;

            // if the event time is less than the current time, process this group of events
            while (midiEvents[eventIndex].Time < time)
            {
                // process this group of events
                do
                {
                    MidiEvent e = midiEvents[eventIndex];

                    // count the notes
                    if (e.IsChannelVoiceMessage && e.ChannelVoiceMessage == ChannelVoiceMessage.NoteOn)
                    {
                        if(e.Velocity != 0.0f)
                        {
                            sequencerInternal.NoteCounter++;
                        }
                    }

                    if (handler != null)
                    {
                        handler(sequencerInternal.Sequencer, midiEvents[eventIndex]);
                    }

                    // force break the loop if we've exceded the length of the event array
                    if (++eventIndex >= midiEvents.Length) break;
                }
                while (midiEvents[eventIndex].DeltaTicks == 0.0f);

                // set the new index.
                sequencerInternal.SetCurrentEventIndex(trackIndex, eventIndex);

                // break if there aren't any events left
                if (eventIndex >= midiEvents.Length) break;
            }
        }

        public bool Update(SequencerInternal sequencerInternal, MetaMessage[] metaMessages, int noteOffset)
        {
            int eventIndex = sequencerInternal.GetCurrentEventIndex(trackIndex);
            

            // return if we've processed all the events
            if (eventIndex >= midiEvents.Length) return false;

            MetaMessage metaMessage = null;

            short noteIndex;

            // if the current time is greater than the event time, process this group of events
            while (midiEvents[eventIndex].Time <= sequencerInternal.Time)
            {
                // process this group of events
                do
                {
                    // process meta messages
                    if (midiEvents[eventIndex].IsMetaMessage)
                    {
                        metaMessage = metaMessages[midiEvents[eventIndex].MetaMessageIndex];

                        // update the tempo (tempo is in microseconds)
                        if (metaMessages[midiEvents[eventIndex].MetaMessageIndex].MetaType == MetaType.Tempo)
                        {
                            sequencerInternal.Tempo = 1000000.0 / (double)metaMessages[midiEvents[eventIndex].MetaMessageIndex].Tempo;
                        }
                    }
                    else
                    {
                        metaMessage = null;
                    }

                    if (midiEvents[eventIndex].IsChannelVoiceMessage)
                    {
                        switch (midiEvents[eventIndex].ChannelVoiceMessage)
                        {
                            case ChannelVoiceMessage.NoteOff:
                                noteIndex = (short)(midiEvents[eventIndex].Note + noteOffset);

                                if (noteIndex >= 0 && noteIndex < 128)
                                {
                                    sequencerInternal.SetMidiNoteData(sequencerInternal.TrackIndex, noteIndex, 0, 0.0f, 0.0f);
                                }

                                break;

                            case ChannelVoiceMessage.NoteOn:
                                noteIndex = (short)(midiEvents[eventIndex].Note + noteOffset);

                                if (noteIndex >= 0 && noteIndex < 128)
                                {
                                    sequencerInternal.SetMidiNoteData(
                                        sequencerInternal.TrackIndex,
                                        noteIndex,
                                        midiEvents[eventIndex].Velocity,
                                        (float)midiEvents[eventIndex].Velocity / 127.0f,
                                        midiEvents[eventIndex].HoldTime / sequencerInternal.PlaybackSpeed
                                        );
                                }
                                break;
                        }
                    }

                    // assign metaMessage if this MidiEvent has one
                    midiEvents[eventIndex].MetaMessage = metaMessage;

                    // assign TrackIndex this MidiEvent belongs to
                    midiEvents[eventIndex].TrackIndex = sequencerInternal.TrackIndex;

                    // tempo this event was played at
                    midiEvents[eventIndex].Tempo = sequencerInternal.Tempo;

                    // pass midi event up to the application
                    sequencerInternal.RaiseMidiEvent(midiEvents[eventIndex]);
                    
                    // force break the loop if we've exceded the length of the event array
                    if (++eventIndex >= midiEvents.Length) break;
                }
                while (midiEvents[eventIndex].DeltaTicks == 0.0f);

                // set the new index.
                sequencerInternal.SetCurrentEventIndex(trackIndex, eventIndex);

                if (eventIndex >= midiEvents.Length) return false;
            }
            
            return true;
        }

#if UNITY_EDITOR
        public void Draw(float width, float height, float time, Color color)
        {
            float hScale = (width / (float)time);
            float vScale = (height / 128.0f);

            for (int i = 0; i < midiEvents.Length; i++)
            {
                MidiEvent midiEvent = midiEvents[i];

                if (midiEvent.Time > time) break;

                if (midiEvent.IsChannelVoiceMessage && midiEvent.ChannelVoiceMessage == ChannelVoiceMessage.NoteOn)
                {
                    float x = midiEvent.Time * hScale;
                    float y = (128 - midiEvent.Note) * vScale;
                    float holdTime = midiEvent.HoldTime * hScale;

                    // gotta force it to be large enough to draw
                    holdTime = (holdTime < 1.0f) ? 1.0f : holdTime;

                    GLU.Line(new Vector2(x, y), new Vector2(x + holdTime, y), color);
                }
            }
        }
#endif
        #endregion
    }
}