using gokart_vanal.models;
using System;
using System.Configuration;

namespace gokart_vanal
{
  class UserSettings : ApplicationSettingsBase
  {
    [UserScopedSetting]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public Options Options
    {
      get { return (Options)this[nameof(UserSettings.Options)] ?? (Options = new Options()); }
      set { this[nameof(UserSettings.Options)] = value; }
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
        deckItemTo.CopyFrom(new DeckItem { VideoPath = videoPath });
        return;
      }
      var deckItemFrom = History.Decks[index];
      deckItemTo.CopyFrom(deckItemFrom);
    }

    public override void Save()
    {
      AddHistory(Options.Deck.A);
      AddHistory(Options.Deck.B);

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

}
