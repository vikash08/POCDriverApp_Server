using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace POCDriverAppService.Swagger
{
    public class SwaggerHeaderParameters: IOperationFilter
    {

        public string Description { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string DefaultValue { get; set; }


        public void Apply(SwaggerDocsConfig c)
        {
            c.ApiKey(Key).Name(Name).Description(Description).In("header");
            c.OperationFilter(() => this);
        }

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.parameters = operation.parameters ?? new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = Name,
                description = Description,
                @in = "header",
                required = true,
                type = "string",
                @default = DefaultValue
            });
        }
    }
}