using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataApiVersioningViaUrlPathDemo.Models.V1;

namespace ODataApiVersioningViaUrlPathDemo.Controllers.V1;

[ApiVersion(1)]
public class PeopleController : ODataController
{
    [EnableQuery]
    public IActionResult Get() => Ok(new[] { new Person { Id = 1, Name = "Tim"} });
}
