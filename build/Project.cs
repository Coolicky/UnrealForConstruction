using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Nuke.Common.Tooling;

[TypeConverter(typeof(ProjectTypeConverter))]
class Project : Enumeration
{
    public string ProjectName;
    public string DockerImage;

    public static Project Api = new()
    {
        ProjectName = "Coolicky.ConstructionLogistics.Api",
        DockerImage = "construction-logistics-api",
        Value = "Api"
    };
}


class ProjectTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
        object value)
    {
        return typeof(Project).GetFields()
            .First(p => p.Name.ToLowerInvariant() == value?.ToString()?.ToLowerInvariant())
            .GetValue(null);
    }
}