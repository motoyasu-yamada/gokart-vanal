using System;
using System.Collections.Generic;
using System.Configuration;

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
    public string Folder { get; set; }
    public string FileNameTemplate { get; set; }
    public int LengthMillis { get; set; } = 3000;
    public int ImageDecompositionIntervalMillis { get; set; } = 200;
  }

  [Serializable]
  public enum VideoScalingMethod
  {
    FitToScreen,
    SameRatio
  }

  [Serializable()]
  public class DeckItem
  {
    public string VideoPath { get; set; }
    public string Alfano6Path { get; set; }
    public int Alfano6Offset { get; set; } = 0;
    public int OffsetPercent { get; set; } = 15;
    public int ScalePercent { get; set; } = 50;
    public VideoScalingMethod VideoScalingMethod { get; set; } = VideoScalingMethod.FitToScreen;
    public List<Marker> Markers { get; set; } = new List<Marker>();
  }


  [Serializable]
  public class DeckSettings
  {
    public ArrangeMode ArrangeMode { get; set; } = ArrangeMode.Vertical;

    public DeckItem A { get; set; } = new DeckItem();

    public DeckItem B { get; set; } = new DeckItem();
  }

  [Serializable()]
  public class HistorySettings
  {
    public List<DeckItem> Decks { get; set; } = new List<DeckItem>();
  }

}
