using System;
using System.Collections.Generic;
using System.Linq;

using Dailydive.Contracts.Dto.Domain;
using Dapper;

namespace Dailydive.DataAccess
{
    public partial class DailyDiveDataAccess
    {
        public IList<TaskHistory> ViewTaskHistory()
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "select Task.TaskName,Task.TaskMeasurement, TaskHistory.TaskDate, TaskHistory.TaskQuantity, TaskHistory.TaskDetails, TaskHistory.TaskHistoryId from [RonaldDb].[DailyDive].[Task] inner join [RonaldDb].[DailyDive].[TaskHistory] on Task.TaskId = TaskHistory.TaskId ORDER BY TaskHistory.TaskDate ASC ";

                var records = connection.Query<TaskHistory>(sql).ToList();

                return records;
            }
        }

        public IList<TaskHistory> AddTaskHistory(TaskHistory TaskHistory)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "insert into [RonaldDb].[DailyDive].[TaskHistory](TaskDate, TaskQuantity, TaskId, TaskDetails) values(@TaskDate, @TaskQuantity, @TaskId, @TaskDetails) ";

                var record =
                    connection.Query<TaskHistory>(sql,
                        new
                        {
                            TaskHistory.TaskDate,
                            TaskHistory.TaskQuantity,
                            TaskHistory.TaskId,
                            TaskHistory.TaskDetails
                        }).ToList();

                return record;
            }
        }

        public TaskHistory LookUpTaskHistoryId(int id)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "select TaskHistory.TaskHistoryId, TaskHistory.TaskDate, TaskHistory.TaskQuantity, TaskHistory.TaskDetails, Task.TaskId, Task.TaskName, Task.TaskMeasurement "
                + "from [RonaldDb].[DailyDive].[TaskHistory] "
                + "inner join [RonaldDb].[DailyDive].[Task] on TaskHistory.TaskId = Task.TaskId "
                + "where TaskHistory.TaskHistoryId = @id";

                var record = connection.Query<TaskHistory>(sql, new { id }).FirstOrDefault();

                return record;
            }
        }

        public TaskHistory UpdateTaskHistory(TaskHistory TaskHistory)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "update [RonaldDb].[DailyDive].[TaskHistory] "
                    + "set TaskDate = @TaskDate, "
                    + " TaskQuantity = @TaskQuantity, "
                    + "TaskDetails = @TaskDetails "
                    + " where TaskHistoryId =@TaskHistoryId";

                var record = connection.Query<TaskHistory>(sql, new { TaskHistory.TaskDate, TaskHistory.TaskQuantity, TaskHistory.TaskDetails, TaskHistory.TaskHistoryId }).FirstOrDefault();

                return record;
            }
        }

        public IEnumerable<TaskHistory> RemoveTaskHistory(int id)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "Delete from [RonaldDb].[DailyDive].[TaskHistory] where TaskHistoryId = @id";

                var record = connection.Query<TaskHistory>(sql, new { id });

                return record;
            }
        }

        public IEnumerable<TaskHistory> SearchTaskHistory(string searchFor)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "select Task.TaskName,Task.TaskMeasurement, TaskHistory.TaskDate, TaskHistory.TaskQuantity, TaskHistory.TaskDetails, TaskHistory.TaskHistoryId "
                          + "from[RonaldDb].[DailyDive].[TaskHistory] "
                          + "inner join [RonaldDb].[DailyDive].[Task] "
                          + "on TaskHistory.TaskId = Task.TaskId "
                          + "where Task.Taskname like '%' + @searchFor  +'%'";

                var records = connection.Query<TaskHistory>(sql, new { searchFor });

                return records;
            }
        }
    }
}
