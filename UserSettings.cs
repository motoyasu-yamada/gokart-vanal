using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml.Serialization;
using static gokart_vanal.PlayData;

namespace gokart_vanal
{
  class UserSettings : ApplicationSettingsBase
  {
    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public ExportSettings Export
    {
      get { return (ExportSettings)this[nameof(UserSettings.Export)] ?? (Export = new ExportSettings()); }
      set { this[nameof(UserSettings.Export)] = value; }
    }

    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public DeckSettings Deck
    {
      get { return (DeckSettings)this[nameof(UserSettings.Deck)] ?? (Deck = new DeckSettings()); }
      set { this[nameof(UserSettings.Deck)] = value; }
    }

    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public HistorySettings History
    {
      get { return (HistorySettings)this[nameof(UserSettings.History)] ?? (History = new HistorySettings()); }
      set { this[nameof(UserSettings.History)] = value; }
    }
  }

  [Serializable()]
  public class ExportSettings
  {
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public string Folder { get; set; }
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public string FileNameTemplate { get; set; }
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public int LengthMillis { get; set; } = 3000;
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public int ImageDecompositionIntervalMillis { get; set; } = 200;
  }

  [Serializable()]
  public class DeckItem
  {
    public string VideoPath { get; set; }
    public int VerticalOffset { get; set; } = 0;
    public int HorizontalOffset { get; set; } = 0;
  }


  [Serializable]
  public class DeckSettings
  {
    public ArrangeModes ArrangeMode { get; set; } = ArrangeModes.Vertical;

    public DeckItem A { get; set; } = new DeckItem();

    public DeckItem B { get; set; } = new DeckItem();

    public List<Marker> Markers { get; set; } = new List<Marker>();
  }

  [Serializable()]
  public class HistorySettings
  {
    public ArrangeModes ArrangeMode { get; set; } = ArrangeModes.Vertical;
    public List<VideoHistoryItem> VideoHistory { get; set; } = new List<VideoHistoryItem>();
    public List<MakerHistoryItem> MakerHistoryItem { get; set; } = new List<MakerHistoryItem>();
  }

  [Serializable()]
  public class MakerHistoryItem
  {
    public string GetKey()
    {
      return VideoPathA + "___" + VideoPathB;

    }
    public string VideoPathA { get; set; }
    public string VideoPathB { get; set; }
    public List<Marker> Markers { get; set; } = new List<Marker>();
  }

  [Serializable()]
  public class VideoHistoryItem
  {
    public string VideoPath { get; set; }
    public int VerticalOffset { get; set; }
    public int HorizontalOffset { get; set; }
  }

}
