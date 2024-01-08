using Asp.Versioning;
using Asp.Versioning.OData;
using Microsoft.OData.ModelBuilder;

namespace ODataApiVersioningViaUrlPathDemo.ModelConfigurations;

public class PersonModelConfiguration : IModelConfiguration
{
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix)
    {
        switch (apiVersion.MajorVersion)
        {
            case 1:
                ConfigureV1(builder);
                break;
            case 2:
                ConfigureV2(builder);
                break;
            default:
                ConfigureV1(builder);
                break;
        }
    }

    private static void ConfigureV1(ODataModelBuilder builder)
    {
        var person = builder.EntitySet<Models.V1.Person>("People").EntityType;
        person.HasKey(customer => customer.Id);
    }

    private static void ConfigureV2(ODataModelBuilder builder)
    {
        var person = builder.EntitySet<Models.V2.Person>("People").EntityType;
        person.HasKey(customer => customer.Id);
    }
}
