using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Models;

namespace Company.Function
{
    public static class CreateStudent
    {
        [Function("CreateStudent")]
        [TableOutput("studenti")]
        public static StudentEntity Run([QueueTrigger("students-queue", Connection = "datclab4dobrescu_STORAGE")] string myQueueItem,
            FunctionContext context)
        {
           var logger = context.GetLogger("CreateStudent");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var student = JsonConvert.DeserializeObject<StudentEntity>(myQueueItem);
            return student;
        }
    }
}
