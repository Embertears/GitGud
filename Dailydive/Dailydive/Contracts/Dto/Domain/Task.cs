using System;

namespace Dailydive.Contracts.Dto.Domain
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskMeasurement { get; set; }
    }
}