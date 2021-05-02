using gokart_vanal.models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace gokart_vanal
{
  class UserSettings : ApplicationSettingsBase
  {
    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public MainSettings MainSetting
    {
      get { return (MainSettings)this[nameof(UserSettings.MainSetting)] ?? (MainSetting = new MainSettings()); }
      set { this[nameof(UserSettings.MainSetting)] = value; }
    }

    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public List<VideoData> History
    {
      get { return (List<VideoData>)this[nameof(UserSettings.History)] ?? (History = new List<VideoData>()); }
      set { this[nameof(UserSettings.History)] = value; }
    }

    public void RestoreFromHistory(VideoData deckItemTo, string videoPath)
    {
      var index = History.FindLastIndex(i => i.VideoPath == videoPath);
      if (index == -1)
      {
        deckItemTo.CopyFrom(new VideoData { VideoPath = videoPath });
        return;
      }
      var deckItemFrom = History[index];
      deckItemTo.CopyFrom(deckItemFrom);
    }

    public override void Save()
    {
      AddHistory(MainSetting.FrameSetting.A);
      if (MainSetting.FrameSetting.A.VideoPath != MainSetting.FrameSetting.B.VideoPath)
      {
        AddHistory(MainSetting.FrameSetting.B);
      }

      base.Save();
    }

    private void AddHistory(VideoData deckItem)
    {
      var index = History.FindLastIndex(i => i.VideoPath == deckItem.VideoPath);
      if (index != -1)
      {
        History.RemoveAt(index);
      }
      var newDeckItem = new VideoData();
      newDeckItem.CopyFrom(deckItem);
      History.Insert(0, newDeckItem);
    }
  }

}
