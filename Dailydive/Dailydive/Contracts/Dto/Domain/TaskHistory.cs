using System;

namespace Dailydive.Contracts.Dto.Domain
{
    public class TaskHistory
    {
        public int TaskHistoryId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskMeasurement { get; set; }
        public DateTime TaskDate { get; set; }
        public int TaskQuantity { get; set; }
        public string TaskDetails { get; set; }


    }
}