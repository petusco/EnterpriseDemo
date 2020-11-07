using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Enterprise.API.Helpers
{
	public static class InvalidModelStateResponseFactory
	{
		public static IActionResult FactoryFunction(ActionContext context)
		{
			var problemDetailsFactory = context.HttpContext.RequestServices
				.GetRequiredService<ProblemDetailsFactory>();
			var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
				context.HttpContext,
				context.ModelState);
			// Add additional info not added by default
			problemDetails.Detail = "See the errors field for details.";
			problemDetails.Instance = context.HttpContext.Request.Path;

			// If there are ModelState errors and all arguments were correctly
			// found / parsed we are dealing with validation errors
			var actionExecutingContext = context as ActionExecutingContext;
			if ((context.ModelState.ErrorCount > 0)
				&& (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
			{
				problemDetails.Type = "";
				problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
				problemDetails.Title = "One or more validation errors occured.";
				return new UnprocessableEntityObjectResult(problemDetails)
				{
					ContentTypes = { "application/problem+json" }
				};
			}

			// If one of the arguments wasn't correctly found / parsed
			// we are dealing with null / unparseable input
			problemDetails.Status = StatusCodes.Status400BadRequest;
			problemDetails.Title = "One or more errors on input occured.";
			return new BadRequestObjectResult(problemDetails)
			{
				ContentTypes = { "application/problem+json" }
			};
		}
	}
}
