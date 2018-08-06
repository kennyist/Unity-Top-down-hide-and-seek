/* ========================================================================================== */
/*                                                                                            */
/* FMOD Ex - C# Wrapper . Copyright (c), Firelight Technologies Pty, Ltd. 2004-2011.          */
/*                                                                                            */
/* ========================================================================================== */

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace FMOD
{
    /*
        FMOD version number.  Check this against FMOD::System::getVersion / System_GetVersion
        0xaaaabbcc -> aaaa = major version number.  bb = minor version number.  cc = development version number.
    */
    public class VERSION
    {
        public const int    number = 0x00010207;
#if UNITY_IPHONE && !UNITY_EDITOR
        public const string dll    = "__Internal";
#else
        public const string dll    = "fmod";
#endif
    }

    /*
        FMOD types 
    */
    public enum INITFLAGS :int
    {
        NORMAL                    = 0x00000000,   /* All platforms - Initialize normally */
        STREAM_FROM_UPDATE        = 0x00000001,   /* All platforms - No stream thread is created internally.  Streams are driven from System::update.  Mainly used with non-realtime outputs. */
        _3D_RIGHTHANDED           = 0x00000002,   /* All platforms - FMOD will treat +X as left, +Y as up and +Z as forwards. */
        SOFTWARE_DISABLE          = 0x00000004,   /* All platforms - Disable software mixer to save memory.  Anything created with FMOD_SOFTWARE will fail and DSP will not work. */
        OCCLUSION_LOWPASS         = 0x00000008,   /* All platforms - All FMOD_SOFTWARE (and FMOD_HARDWARE on 3DS and NGP) with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which is automatically used when Channel::set3DOcclusion is used or the geometry API. */
        HRTF_LOWPASS              = 0x00000010,   /* All platforms - All FMOD_SOFTWARE (and FMOD_HARDWARE on 3DS and NGP) with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which causes sounds to sound duller when the sound goes behind the listener.  Use System::setAdvancedSettings to adjust cutoff frequency. */
        DISTANCE_FILTERING        = 0x00000200,   /* All platforms - All FMOD_SOFTWARE with FMOD_3D based voices will add a software lowpass and highpass filter effect into the DSP chain which will act as a distance-automated bandpass filter. Use System::setAdvancedSettings to adjust the center frequency. */
        SOFTWARE_REVERB_LOWMEM    = 0x00000040,   /* All platforms - SFX reverb is run using 22/24khz delay buffers, halving the memory required. */
        ENABLE_PROFILE            = 0x00000020,   /* All platforms - Enable TCP/IP based host which allows "DSPNet Listener.exe" to connect to it, and view the DSP dataflow network graph in real-time. */
        VOL0_BECOMES_VIRTUAL      = 0x00000080,   /* All platforms - Any sounds that are 0 volume will go virtual and not be processed except for having their positions updated virtually.  Use System::setAdvancedSettings to adjust what volume besides zero to switch to virtual at. */
        WASAPI_EXCLUSIVE          = 0x00000100,   /* Win32 Vista only - for WASAPI output - Enable exclusive access to hardware, lower latency at the expense of excluding other applications from accessing the audio hardware. */
        DISABLEDOLBY              = 0x00100000,   /* Wii / 3DS - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the system settings. */
        WII_DISABLEDOLBY          = 0x00100000,   /* Wii only - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the Wii system settings. */
        _360_MUSICMUTENOTPAUSE    = 0x00200000,   /* Xbox 360 only - The "music" channelgroup which by default pauses when custom 360 dashboard music is played, can be changed to mute (therefore continues playing) instead of pausing, by using this flag. */
        SYNCMIXERWITHUPDATE       = 0x00400000,   /* Win32/Wii/PS3/Xbox 360 - FMOD Mixer thread is woken up to do a mix when System::update is called rather than waking periodically on its own timer. */
        DTS_NEURALSURROUND        = 0x02000000,   /* Win32/Mac/Linux - Use DTS Neural surround downmixing from 7.1 if speakermode set to FMOD_SPEAKERMODE_STEREO or FMOD_SPEAKERMODE_5POINT1.  Internal DSP structure will be set to 7.1. */
        GEOMETRY_USECLOSEST       = 0x04000000,   /* All platforms - With the geometry engine, only process the closest polygon rather than accumulating all polygons the sound to listener line intersects. */
        DISABLE_MYEARS_AUTODETECT = 0x08000000    /* Win32 - Disables automatic setting of FMOD_SPEAKERMODE_STEREO to FMOD_SPEAKERMODE_MYEARS if the MyEars profile exists on the PC.  MyEars is HRTF 7.1 downmixing through headphones. */
    }

	
    [StructLayout(LayoutKind.Sequential)]
    public struct VECTOR
    {
        public float x;        /* X co-ordinate in 3D space. */
        public float y;        /* Y co-ordinate in 3D space. */
        public float z;        /* Z co-ordinate in 3D space. */
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct GUID
    {
        public uint   Data1;       /* Specifies the first 8 hexadecimal digits of the GUID */
        public ushort Data2;       /* Specifies the first group of 4 hexadecimal digits.   */
        public ushort Data3;       /* Specifies the second group of 4 hexadecimal digits.  */
        [MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
        public byte[] Data4;       /* Array of 8 bytes. The first 2 bytes contain the third group of 4 hexadecimal digits. The remaining 6 bytes contain the final 12 hexadecimal digits. */
    }


     public enum RESULT :int
    {
        OK,                        /* No errors. */
        ERR_ALREADYLOCKED,         /* Tried to call lock a second time before unlock was called. */
        ERR_BADCOMMAND,            /* Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound). */
        ERR_CDDA_DRIVERS,          /* Neither NTSCSI nor ASPI could be initialised. */
        ERR_CDDA_INIT,             /* An error occurred while initialising the CDDA subsystem. */
        ERR_CDDA_INVALID_DEVICE,   /* Couldn't find the specified device. */
        ERR_CDDA_NOAUDIO,          /* No audio tracks on the specified disc. */
        ERR_CDDA_NODEVICES,        /* No CD/DVD devices were found. */
        ERR_CDDA_NODISC,           /* No disc present in the specified drive. */
        ERR_CDDA_READ,             /* A CDDA read error occurred. */
        ERR_CHANNEL_ALLOC,         /* Error trying to allocate a channel. */
        ERR_CHANNEL_STOLEN,        /* The specified channel has been reused to play another sound. */
        ERR_COM,                   /* A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly. */
        ERR_DMA,                   /* DMA Failure.  See debug output for more information. */
        ERR_DSP_CONNECTION,        /* DSP connection error.  Connection possibly caused a cyclic dependancy.  Or tried to connect a tree too many units deep (more than 128). */
        ERR_DSP_DONTPROCESS,       /* DSP return code from a DSP process query callback.  Tells mixer not to call the process callback and therefore not consume CPU.  Use this to optimize the DSP graph. */
        ERR_DSP_FORMAT,            /* DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format, or a matrix may have been set with the wrong size if the target unit has a specified channel map. */
        ERR_DSP_SILENCE,           /* DSP return code from a DSP process query callback.  Tells mixer silence would be produced from read, so go idle and not consume CPU.  Use this to optimize the DSP graph. */
        ERR_DSP_INUSE,             /* DSP is already in the mixer's DSP network. It must be removed before being reinserted or released. */
        ERR_DSP_NOTFOUND,          /* DSP connection error.  Couldn't find the DSP unit specified. */
        ERR_DSP_RUNNING,           /* DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback. */
        ERR_DSP_TOOMANYCONNECTIONS,/* DSP connection error.  The unit being connected to or disconnected should only have 1 input or output. */
        ERR_FILE_BAD,              /* Error loading file. */
        ERR_FILE_COULDNOTSEEK,     /* Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format. */
        ERR_FILE_DISKEJECTED,      /* Media was ejected while reading. */
        ERR_FILE_EOF,              /* End of file unexpectedly reached while trying to read essential data (truncated?). */
        ERR_FILE_ENDOFDATA,        /* End of current chunk reached while trying to read data. */
        ERR_FILE_NOTFOUND,         /* File not found. */
        ERR_FILE_UNWANTED,         /* Unwanted file access occured. */
        ERR_FORMAT,                /* Unsupported file or audio format. */
        ERR_HTTP,                  /* A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere. */
        ERR_HTTP_ACCESS,           /* The specified resource requires authentication or is forbidden. */
        ERR_HTTP_PROXY_AUTH,       /* Proxy authentication is required to access the specified resource. */
        ERR_HTTP_SERVER_ERROR,     /* A HTTP server error occurred. */
        ERR_HTTP_TIMEOUT,          /* The HTTP request timed out. */
        ERR_INITIALIZATION,        /* FMOD was not initialized correctly to support this function. */
        ERR_INITIALIZED,           /* Cannot call this command after System::init. */
        ERR_INTERNAL,              /* An error occured that wasn't supposed to.  Contact support. */
        ERR_INVALID_ADDRESS,       /* On Xbox 360, this memory address passed to FMOD must be physical, (ie allocated with XPhysicalAlloc.) */
        ERR_INVALID_FLOAT,         /* Value passed in was a NaN, Inf or denormalized float. */
        ERR_INVALID_HANDLE,        /* An invalid object handle was used. */
        ERR_INVALID_PARAM,         /* An invalid parameter was passed to this function. */
        ERR_INVALID_POSITION,      /* An invalid seek position was passed to this function. */
        ERR_INVALID_SPEAKER,       /* An invalid speaker was passed to this function based on the current speaker mode. */
        ERR_INVALID_SYNCPOINT,     /* The syncpoint did not come from this sound handle. */
        ERR_INVALID_VECTOR,        /* The vectors passed in are not unit length, or perpendicular. */
        ERR_MAXAUDIBLE,            /* Reached maximum audible playback count for this sound's soundgroup. */
        ERR_MEMORY,                /* Not enough memory or resources. */
        ERR_MEMORY_CANTPOINT,      /* Can't use FMOD_OPENMEMORY_POINT on non PCM source data, or non mp3/xma/adpcm data if FMOD_CREATECOMPRESSEDSAMPLE was used. */
        ERR_MEMORY_SRAM,           /* Not enough memory or resources on console sound ram. */
        ERR_NEEDS2D,               /* Tried to call a command on a 3d sound when the command was meant for 2d sound. */
        ERR_NEEDS3D,               /* Tried to call a command on a 2d sound when the command was meant for 3d sound. */
        ERR_NEEDSHARDWARE,         /* Tried to use a feature that requires hardware support.  (ie trying to play a GCADPCM compressed sound in software on Wii). */
        ERR_NEEDSSOFTWARE,         /* Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature. */
        ERR_NET_CONNECT,           /* Couldn't connect to the specified host. */
        ERR_NET_SOCKET_ERROR,      /* A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere. */
        ERR_NET_URL,               /* The specified URL couldn't be resolved. */
        ERR_NET_WOULD_BLOCK,       /* Operation on a non-blocking socket could not complete immediately. */
        ERR_NOTREADY,              /* Operation could not be performed because specified sound/DSP connection is not ready. */
        ERR_OUTPUT_ALLOCATED,      /* Error initializing output device, but more specifically, the output device is already in use and cannot be reused. */
        ERR_OUTPUT_CREATEBUFFER,   /* Error creating hardware sound buffer. */
        ERR_OUTPUT_DRIVERCALL,     /* A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted. */
        ERR_OUTPUT_FORMAT,         /* Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output). */
        ERR_OUTPUT_INIT,           /* Error initializing output device. */
        ERR_OUTPUT_NODRIVERS,      /* The output device has no drivers installed, so FMOD_OUTPUT_NOSOUND is selected as the output mode. */
        ERR_OUTPUT_NOHARDWARE,     /* FMOD_HARDWARE was specified but the sound card does not have the resources necessary to play it. */
        ERR_OUTPUT_NOSOFTWARE,     /* Attempted to create a software sound but no software channels were specified in System::init. */
        ERR_PLUGIN,                /* An unspecified error has been returned from a plugin. */
        ERR_PLUGIN_INSTANCES,      /* The number of allowed instances of a plugin has been exceeded. */
        ERR_PLUGIN_MISSING,        /* A requested output, dsp unit type or codec was not available. */
        ERR_PLUGIN_RESOURCE,       /* A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback) */
        ERR_PLUGIN_VERSION,        /* A plugin was built with an unsupported SDK version. */
        ERR_PRELOADED,             /* The specified sound is still in use by the event system, call EventSystem::unloadFSB before trying to release it. */
        ERR_PROGRAMMERSOUND,       /* The specified sound is still in use by the event system, wait for the event which is using it finish with it. */
        ERR_RECORD,                /* An error occured trying to initialize the recording device. */
        ERR_REVERB_CHANNELGROUP,   /* Reverb properties cannot be set on this channel because a parent channelgroup owns the reverb connection. */
        ERR_REVERB_INSTANCE,       /* Specified instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because it is an invalid instance number or the reverb doesnt exist. */
        ERR_SUBSOUNDS,             /* The error occured because the sound referenced contains subsounds when it shouldn't have, or it doesn't contain subsounds when it should have.  The operation may also not be able to be performed on a parent sound. */
        ERR_SUBSOUND_ALLOCATED,    /* This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first. */
        ERR_SUBSOUND_CANTMOVE,     /* Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file. */
        ERR_SUBSOUND_MODE,         /* The subsound's mode bits do not match with the parent sound's mode bits.  See documentation for function that it was called with. */
        ERR_TAGNOTFOUND,           /* The specified tag could not be found or there are no tags. */
        ERR_TOOMANYCHANNELS,       /* The sound created exceeds the allowable input channel count.  This can be increased using the maxinputchannels parameter in System::setSoftwareFormat. */
        ERR_UNIMPLEMENTED,         /* Something in FMOD hasn't been implemented when it should be! contact support! */
        ERR_UNINITIALIZED,         /* This command failed because System::init or System::setDriver was not called. */
        ERR_UNSUPPORTED,           /* A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified. */
        ERR_UPDATE,                /* An error caused by System::update occured. */
        ERR_VERSION,               /* The version number of this file format is not supported. */
        ERR_HEADER_MISMATCH,       /* There is a version mismatch between the FMOD header and either the FMOD Studio library or the FMOD Low Level library. */

        ERR_EVENT_ALREADY_LOADED,  /* The specified project or bank has already been loaded. Having multiple copies of the same project loaded simultaneously is forbidden. */
        ERR_EVENT_FAILED,          /* An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior. */
        ERR_EVENT_GUIDCONFLICT,    /* An event with the same GUID already exists. */
        ERR_EVENT_INFOONLY,        /* Can't execute this command on an EVENT_INFOONLY event. */
        ERR_EVENT_INTERNAL,        /* An error occured that wasn't supposed to.  See debug log for reason. */
        ERR_EVENT_LIVEUPDATE_BUSY, /* The live update connection failed due to the game already being connected. */
        ERR_EVENT_LIVEUPDATE_MISMATCH, /* The live update connection failed due to the game data being out of sync with the tool. */
        ERR_EVENT_LIVEUPDATE_TIMEOUT, /* The live update connection timed out. */
        ERR_EVENT_MAXSTREAMS,      /* Event failed because 'Max streams' was hit when FMOD_EVENT_INIT_FAIL_ON_MAXSTREAMS was specified. */
        ERR_EVENT_MISMATCH,        /* FSB mismatches the FEV it was compiled with, the stream/sample mode it was meant to be created with was different, or the FEV was built for a different platform. */
        ERR_EVENT_NAMECONFLICT,    /* A category with the same name already exists. */
        ERR_EVENT_NEEDSSIMPLE,     /* Tried to call a function on a complex event that's only supported by simple events. */
        ERR_EVENT_NOTFOUND,        /* The requested event, bus or vca could not be found. */
        ERR_EVENT_WONT_STOP,       /* The event cannot be released because it will not terminate, call stop to allow releasing of this event */

        ERR_MUSIC_NOCALLBACK,      /* The music callback is required, but it has not been set. */
        ERR_MUSIC_NOTFOUND,        /* The requested music entity could not be found. */
        ERR_MUSIC_UNINITIALIZED,   /* Music system is not initialized probably because no music data is loaded. */

        ERR_STUDIO_UNINITIALIZED,  /* The Studio::System object is not yet initialized */
        ERR_STUDIO_NOT_LOADED,     /* The specified resource is not loaded, so it can't be unloaded. */
    }
	
#if !DISABLE_LOW_LEVEL
    public enum SPEAKERMODE :int
    {
		DEFAULT,
        RAW,              /* There is no specific speakermode.  Sound channels are mapped in order of input to output.  See remarks for more information. */
        MONO,             /* The speakers are monaural. */
        STEREO,           /* The speakers are stereo (DEFAULT). */
        QUAD,             /* 4 speaker setup.  This includes front left, front right, rear left, rear right.  */
        SURROUND,         /* 4 speaker setup.  This includes front left, front right, center, rear center (rear left/rear right are averaged). */
        _5POINT1,         /* 5.1 speaker setup.  This includes front left, front right, center, rear left, rear right and a subwoofer. */
        _7POINT1,         /* 7.1 speaker setup.  This includes front left, front right, center, rear left, rear right, side left, side right and a subwoofer. */

        MAX,              /* Maximum number of speaker modes supported. */
    }
	
    public class System : Studio.HandleBase
    {
        public RESULT loadPlugin(string filename, ref uint handle)
        {
            return FMOD_System_LoadPlugin(rawPtr, filename, ref handle, 0);
        }
        [DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_LoadPlugin(IntPtr system, string filename, ref uint handle, uint priority);
		
        public RESULT setSoftwareFormat(int samplerate, SPEAKERMODE speakermode, int numrawspeakers)
        {
            return FMOD_System_SetSoftwareFormat(rawPtr, samplerate, speakermode, numrawspeakers);
        }
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_System_SetSoftwareFormat(IntPtr system, int samplerate, SPEAKERMODE speakermode, int numrawspeakers);
		
#if UNITY_EDITOR
        public RESULT getVersion             (ref uint version)
        {
            return FMOD_System_GetVersion(rawPtr, ref version);
        }
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_System_GetVersion(IntPtr system, ref uint version);
#endif
		
	}	
#endif
	
	
    
#if !UNITY_IPHONE || UNITY_EDITOR
    public class Memory
    {
        public static RESULT GetStats(ref int currentalloced, ref int maxalloced)
        {
            return FMOD_Memory_GetStats(ref currentalloced, ref maxalloced, 1);
        }

        #region importfunctions
  
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Memory_GetStats(ref int currentalloced, ref int maxalloced, int blocking);

        #endregion
    }
#endif
	
#if UNITY_ANDROID
	
#endif
}
