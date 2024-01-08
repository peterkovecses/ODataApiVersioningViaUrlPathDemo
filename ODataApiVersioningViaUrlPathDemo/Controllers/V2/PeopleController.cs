using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataApiVersioningViaUrlPathDemo.Models.V2;

namespace ODataApiVersioningViaUrlPathDemo.Controllers.V2;

[ApiVersion(2)]
public class PeopleController : ODataController
{
    [EnableQuery]
    public IActionResult Get() => Ok(new[] { new Person { Id = 2, Name = "Tim", Age = 30 } });
}
