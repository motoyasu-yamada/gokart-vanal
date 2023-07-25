using System;
using System.Runtime.InteropServices;

namespace gokart_vanal
{
  internal static class MatLabXrk
  {
    //! Get the compile date of this library
    /*!
    \return the compile date
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_library_date();
    public static string GetLibraryDate()
    {
      return Marshal.PtrToStringAnsi(get_library_date());
    }

    //! Get the compile time of this library
    /*!
    \return the compile time
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_library_time();
    public static string GetLibraryTime()
    {
      return Marshal.PtrToStringAnsi(get_library_time());
    }

    //! Open a xrk file
    /*!
    \param full_path_name full path to the file to be opened, it cannot be a relative path
    \return > 0 in case of success the internal index of the file opened, 0 in case the file is opened but can't be parsed, < 0 in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "open_file", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int OpenFile(string full_path_name);

    //! Close a xrk file
    /*!
    \param full_path_name full path to the file to be closed, it cannot be a relative path
    \return > 0 the internal index of the file closed, < 0 in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int close_file_n(string full_path_name);

    //! Close a xrk file
    /*!
    \param idx the internal file index returned by open function
    \return > 0 the internal index of the file closed, < 0 in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "close_file_i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int CloseFileWithIndex(int idx);

    //! Get vehicle info
    /*!
    \param idx the internal file index returned by open function
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_vehicle_name(int idx);
    public static string GetVehicleName(int idx)
    {
      return Marshal.PtrToStringAnsi(get_vehicle_name(idx));
    }

    //! Get track info
    /*!
    \param idx the internal file index returned by open function
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_track_name(int idx);
    public static string GetTrackName(int idx)
    {
      return Marshal.PtrToStringAnsi(get_track_name(idx));
    }

    //! Get racer info
    /*!
    \param idx the internal file index returned by open function
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_racer_name(int idx);
    public static string GetRacerName(int idx)
    {
      return Marshal.PtrToStringAnsi(get_racer_name(idx));
    }

    //! Get championship info
    /*!
    \param idx the internal file index returned by open function
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_championship_name(int idx);
    public static string GetChampionshipName(int idx)
    {
      return Marshal.PtrToStringAnsi(get_championship_name(idx));
    }

    //! Get venue type info
    /*!
    \param idx the internal file index returned by open function
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_venue_type_name(int idx);
    public static string GetVenueTypeName(int idx)
    {
      return Marshal.PtrToStringAnsi(get_venue_type_name(idx));
    }

    //! Get session date and time
    /*!
    \param idx the internal file index returned by open function
    \return a struct tm pointer with the required info, NULL in case of problems
    */
    // static extern struct tm const* get_date_and_time(int idx);

    //! Get laps count of a xrk file
    /*!
    \param idx the internal file index returned by open function
    \return > 0 the laps count, < 0 in case of problems, 0 in case the xrk file has no laps (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_laps_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapsCount(int idx);

    /*!
        Laps information functions
    */

    //! Get lap info
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param pstart pointer to an already allocated double in which the start time of the lap will be stored
    \param pduration pointer to an already allocated double in which the lap duration will be stored
    \return 1 if all is OK, < 0 in case of problems, 0 in case the xrk file has no laps (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_info", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapInfo(int idxf, int idxl, out double pstart, out double pduration);


    /*!
        Channels information functions
    */

    //! Get channels count of a xrk file
    /*!
    \param idx the internal file index returned by open function
    \return > 0 the channel count, < 0 in case of problems, 0 in case the xrk file has no channels (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_channels_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetChannelsCount(int idx);

    //! Get channel name
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_channel_name(int idxf, int idxc);
    public static string GetChannelName(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_channel_name(idxf, idxc));
    }

    //! Get channel units
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_channel_units(int idxf, int idxc);
    public static string GetChannelUnits(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_channel_units(idxf, idxc));
    }

    //! Get channel samples count
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetChannelSamplesCount(int idxf, int idxc);

    //! Get channel samples
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetChannelSamples(int idxf, int idxc, out double ptimes, out double pvalues, int cnt);

    //! Get channel samples count in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapChannelSamplesCount(int idxf, int idxl, int idxc);

    //! Get channel samples in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapChannelSamples(int idxf, int idxl, int idxc, double[] ptimes, double[] pvalues, int cnt);

    /*!
        GPS channels information functions, where GPS channels are the same channels added to AiM drk files in RS2Analysis,
        those that consider vehicle dynamics assuming that the vehicle is constantly aligned to the trajectory.
    */

    //! Get GPS channels count of a xrk file
    /*!
    \param idx the internal file index returned by open function
    \return > 0 the channel count, < 0 in case of problems, 0 in case the xrk file has no channels (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int get_GPS_channels_count(int idx);

    //! Get GPS channel name
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_GPS_channel_name(int idxf, int idxc);
    public static string GetGpsChannelName(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_GPS_channel_name(idxf, idxc));
    }

    //! Get GPS channel units
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_GPS_channel_units(int idxf, int idxc);
    public static string GetGpsChannelUnits(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_GPS_channel_units(idxf, idxc));
    }

    //! Get GPS channel samples count
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint= "get_GPS_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetGpsChannelSamplesCount(int idxf, int idxc);

    //! Get GPS channel samples
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint= "get_GPS_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetGpsChannelSamples(int idxf, int idxc, double[] ptimes, double[] pvalues, int cnt);

    //! Get GPS channel samples count in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_GPS_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapGpsChannelSamplesCount(int idxf, int idxl, int idxc);

    //! Get GPS channel samples in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_GPS_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapGpsChannelSamples(int idxf, int idxl, int idxc, double[] ptimes, double[] pvalues, int cnt);

    /*!
        GPS raw channels information functions, where GPS raw channels are information in the GPS solution coming directly from the GPS receiver.
    */

    //! Get GPS raw channels count of a xrk file
    /*!
    \param idx the internal file index returned by open function
    \return > 0 the channel count, < 0 in case of problems, 0 in case the xrk file has no channels (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_GPS_raw_channels_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetGpsRawChannelsCount(int idx);

    //! Get GPS raw channel name
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_GPS_raw_channel_name(int idxf, int idxc);
    public static string GetGpsRawChannelName(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_GPS_raw_channel_name(idxf, idxc));
    }

    //! Get GPS raw channel units
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return a null terminated char pointer with the required info, NULL in case of problems
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    private static extern IntPtr get_GPS_raw_channel_units(int idxf, int idxc);
    public static string GetGpsRawChannelUnits(int idxf, int idxc)
    {
      return Marshal.PtrToStringAnsi(get_GPS_raw_channel_units(idxf, idxc));
    }

    //! Get GPS raw channel samples count
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_GPS_raw_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetGpsRawChannelSamplesCount(int idxf, int idxc);

    //! Get GPS raw channel samples
    /*!
    \param idxf the internal file index returned by open function
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_GPS_raw_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetGpsRawChannelSamples(int idxf, int idxc, double[] ptimes, double[] pvalues, int cnt);

    //! Get GPS raw channel samples count in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \return > 0 the samples count, < 0 in case of problems, 0 in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_GPS_raw_channel_samples_count", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapGpsRawChannelSamplesCount(int idxf, int idxl, int idxc);

    //! Get GPS raw channel samples in a given lap
    /*!
    \param idxf the internal file index returned by open function
    \param idxl the lap index
    \param idxc the channel index
    \param ptimes pointer to an already allocated buffer in which sample times will be stored
    \param pvalues pointer to an already allocated buffer in which sample values will be stored
    \param cnt the number of samples of the buffer, that is the samples count returned by get channel samples count function
    \return > 0 the samples count, < 0 in case of problems, 0 in case the cnt param doesn't match the samples count or in case the channel has no samples (theorically not possible)
    */
    [DllImport("MatLabXRK-2017-32-ReleaseU.dll", EntryPoint = "get_lap_GPS_raw_channel_samples", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int GetLapGpsRawChannelSamples(int idxf, int idxl, int idxc, double[] ptimes, double[] pvalues, int cnt);


  }
}