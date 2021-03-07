namespace Mavanmanen.StreamDeckSharp.Attributes.Data
{
    internal class ProfileData
    {
        public string Name { get; }
        public DeviceType DeviceType { get; }
        public bool? ReadOnly { get; }
        public bool? DontAutoSwitchWhenInstalled { get; }

        public ProfileData(string name,
            DeviceType deviceType,
            bool? readOnly,
            bool? dontAutoSwitchWhenInstalled)
        {
            Name = name;
            DeviceType = deviceType;
            ReadOnly = readOnly;
            DontAutoSwitchWhenInstalled = dontAutoSwitchWhenInstalled;
        }
    }
}
