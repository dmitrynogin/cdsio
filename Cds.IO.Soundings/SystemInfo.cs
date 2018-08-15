namespace Cds.IO
{
    public class SystemInfo
    {
        [Field("Win OS Version")] public string WinOSVersion { get; set; }
        [Field("Computer Asset ID")] public string ComputerAssetID { get; set; }
        [Field("Computer Type")] public string ComputerType { get; set; }
        [Field("DAS Asset ID")] public string DASAssetID { get; set; }
        [Field("DAS Type")] public string DASType { get; set; }
    }
}