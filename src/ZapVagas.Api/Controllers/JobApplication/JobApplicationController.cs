namespace ZapVagas.API.Controllers.JobApplication
{
    public static class JobApplicationController
    {
        public static void MapJobApplicationEndpoints(this WebApplication app)
        {
            var jobApplicationGroup = app.MapGroup("/api/jobapplications")
                .WithTags("Job Applications");

            //jobApplicationGroup.MapPost("/", JobApplicationHandler.CreateJobApplication)
            //    .WithName("CreateJobApplication")
            //    .Produces<Domain.Entities.JobApplication>(StatusCodes.Status201Created)
            //    .ProducesProblem(StatusCodes.Status400BadRequest)
            //    .ProducesProblem(StatusCodes.Status500InternalServerError);

            //jobApplicationGroup.MapGet("/{id:int}", JobApplicationHandler.GetJobApplicationById)
            //    .WithName("GetJobApplicationById")
            //    .Produces<Domain.Entities.JobApplication>(StatusCodes.Status200OK)
            //    .ProducesProblem(StatusCodes.Status404NotFound)
            //    .ProducesProblem(StatusCodes.Status500InternalServerError);

            //jobApplicationGroup.MapGet("/", JobApplicationHandler.GetAllJobApplications)
            //    .WithName("GetAllJobApplications")
            //    .Produces<List<Domain.Entities.JobApplication>>(StatusCodes.Status200OK)
            //    .ProducesProblem(StatusCodes.Status500InternalServerError);

            //jobApplicationGroup.MapPut("/{id:int}", JobApplicationHandler.UpdateJobApplication)
            //    .WithName("UpdateJobApplication")
            //    .Produces<Domain.Entities.JobApplication>(StatusCodes.Status200OK)
            //    .ProducesProblem(StatusCodes.Status400BadRequest)
            //    .ProducesProblem(StatusCodes.Status404NotFound)
            //    .ProducesProblem(StatusCodes.Status500InternalServerError);

            //jobApplicationGroup.MapDelete("/{id:int}", JobApplicationHandler.DeleteJobApplication)
            //    .WithName("DeleteJobApplication")
            //    .Produces(StatusCodes.Status204NoContent)
            //    .ProducesProblem(StatusCodes.Status404NotFound)
            //    .ProducesProblem(StatusCodes.Status500InternalServerError);
        }
    }
}
