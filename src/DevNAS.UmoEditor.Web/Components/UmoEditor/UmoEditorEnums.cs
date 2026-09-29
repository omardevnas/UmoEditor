using System.Text.Json.Serialization;

namespace DevNAS.UmoEditor.Web.Components.UmoEditor;

/// <summary>Whether Umo's own ribbon toolbar is shown above the editor surface.</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UmoEditorToolbarMode
{
    [JsonStringEnumMemberName("full")]
    Full,

    [JsonStringEnumMemberName("none")]
    None,
}

/// <summary>UI locale for Umo's own toolbar/menu chrome. Content-level text
/// direction (RTL/LTR) is a separate, per-paragraph concern handled by the
/// widget's own text-direction extension, not this setting.</summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UmoEditorLocale
{
    [JsonStringEnumMemberName("en")]
    En,

    [JsonStringEnumMemberName("ar")]
    Ar,
}
