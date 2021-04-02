using System.Configuration;

namespace gokart_vanal
{
  class UserSettings : ApplicationSettingsBase
  {
    [UserScopedSetting()]
    public string ExportFolder
    {
      get { return (string)this["ExportFolder"]; }
      set { this["ExportFolder"] = value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("diff_{videoa_name}_{videob_name}_{marker_name}")]
    public string ExportFileName
    {
      get { return (string)this["ExportFileName"]; }
      set { this["ExportFileName"] = value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("10")]
    public int ExportNumberOfImages
    {
      get { return (int)this["ExportNumberOfImages"]; }
      set { this["ExportNumberOfImages"] = value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("200")]
    public int ExportIntervalOfImages
    {
      get { return (int)this["ExportIntervalOfImages"]; }
      set { this["ExportIntervalOfImages"] = value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("C:\\Users\\dell\\iCloudDrive\\KART\\MOTEGI-BEST\\KGO-20210328-SS-TT-BEST-GH015958.mp4")]
    public string VideoAPath
    {
      get
      {
        return ((string)this["VideoAPath"]);
      }
      set
      {
        this["VideoAPath"] = (string)value;
      }
    }
    [UserScopedSetting()]
    [DefaultSettingValue("M:\\DCIM\\100GOPRO\\GH010104.MP4")]
    public string VideoBPath
    {
      get
      {
        return ((string)this["VideoBPath"]);
      }
      set
      {
        this["VideoBPath"] = (string)value;
      }
    }
  }
}
