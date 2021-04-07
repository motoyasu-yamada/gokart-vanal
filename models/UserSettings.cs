﻿using System;
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

    public void RestoreFromHistory(DeckItem deckItemTo, string videoPath)
    {
      var index = History.Decks.FindLastIndex(i => i.VideoPath == videoPath);
      if (index == -1)
      {
        Console.WriteLine($"***RestoreFromHistory***: videoPath={videoPath},index={index},Reset");
        deckItemTo.CopyFrom(new DeckItem { VideoPath = videoPath });
        return;
      }
      var deckItemFrom = History.Decks[index];
      Console.WriteLine($"***RestoreFromHistory***: videoPath={videoPath},index={index},deckItemFrom={deckItemFrom.VideoPath}");
      deckItemTo.CopyFrom(deckItemFrom);
    }

    public override void Save()
    {
      AddHistory(Deck.A);
      AddHistory(Deck.B);

      base.Save();
    }

    private void AddHistory(DeckItem deckItem)
    {
      var index = History.Decks.FindLastIndex(i => i.VideoPath == deckItem.VideoPath);
      if (index != -1)
      {
        History.Decks.RemoveAt(index);
      }
      var newDeckItem = new DeckItem();
      newDeckItem.CopyFrom(deckItem);
      History.Decks.Insert(0, newDeckItem);
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
    public void CopyFrom(DeckItem from)
    {
      this.VideoPath = from.VideoPath;
      this.Alfano6Path = from.Alfano6Path;
      this.Alfano6Offset = from.Alfano6Offset;
      this.OffsetPercent = from.OffsetPercent;
      this.ScalePercent = from.ScalePercent;
      this.VideoScalingMethod = from.VideoScalingMethod;
      this.Markers = new List<Marker>();
      foreach (var m in from.Markers)
      {
        this.Markers.Add(m.Clone());
      }
    }
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
