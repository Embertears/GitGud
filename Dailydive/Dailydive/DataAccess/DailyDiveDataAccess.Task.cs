using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dailydive.Contracts.Dto.Domain;

namespace Dailydive.DataAccess
{
    public partial class DailyDiveDataAccess
    {
        public IList<Task> ViewAllTask()
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "select * from [RonaldDb].[DailyDive].[Task] ORDER BY Task.TaskName";

                var records = connection.Query<Task>(sql).ToList();

                return records;
            }
        }

        public IList<Task> AddNewTask(Task task)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "insert into [RonaldDb].[DailyDive].[Task](TaskName, TaskMeasurement) values(@TaskName, @TaskMeasurement)";

                var records = connection.Query<Task>(sql, new {task.TaskName, task.TaskMeasurement}).ToList();

                return records;
            }                       
        }

        public Task LookUpTask(int id)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "Select Task.TaskName, Task.TaskId, Task.TaskMeasurement " 
                + "from [RonaldDb].[DailyDive].[Task] "
                + "where Task.TaskId = @id";

                var record = connection.Query<Task>(sql, new { id }).SingleOrDefault();

                return record;
            }
        }

        public Task UpdateTask(Task task)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "update [RonaldDb].[DailyDive].[Task] "
                + "set Task.TaskMeasurement = @TaskMeasurement "
                + "where Task.TaskId = @TaskId";

                var record = connection.Query<Task>(sql, new { task.TaskMeasurement, task.TaskId }).FirstOrDefault();

                return record;
            }
        }

        public IEnumerable<Task> SearchTask(string searchFor)  
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "Select * from [RonaldDb].[DailyDive].[Task] where TaskName like '%' +  @searchFor + '%'";

                var records = connection.Query<Task>(sql, new {searchFor});

                return records;
            }
        }
        public Task RemoveTask(int id)
        {
            using (var connection = this.OpenConnection())
            {
                var sql = "Delete from [RonaldDb].[DailyDive].[Task] where TaskId = @id";

                var record = connection.Query<Task>(sql, new {id}).FirstOrDefault();

                return record;

            }             
        }
    }
}
