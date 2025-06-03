using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AccountingSystem.Models;

namespace AccountingSystem.Data
{
    public class RecordService
    {
        public static List<Record> GetAllRecords()
        {
            var records = new List<Record>();
            string sql = "SELECT * FROM Records ORDER BY RecordDate DESC";

            DataTable dt = DbHelper.ExecuteDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                records.Add(new Record
                {
                    Id = Convert.ToInt32(row["Id"]),
                    RecordDate = Convert.ToDateTime(row["RecordDate"]),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Amount = Convert.ToDecimal(row["Amount"]),
                    Type = row["Type"].ToString(),
                    Description = row["Description"].ToString()
                });
            }

            return records;
        }

        public static void AddRecord(Record record)
        {
            string sql = @"INSERT INTO Records (RecordDate, CategoryId, CategoryName, Amount, Type, Description)
                           VALUES (@RecordDate, @CategoryId, @CategoryName, @Amount, @Type, @Description)";

            var parameters = new[]
            {
                new SqlParameter("@RecordDate", record.RecordDate),
                new SqlParameter("@CategoryId", record.CategoryId),
                new SqlParameter("@CategoryName", record.CategoryName),
                new SqlParameter("@Amount", record.Amount),
                new SqlParameter("@Type", record.Type),
                new SqlParameter("@Description", record.Description),
            };

            DbHelper.ExecuteNonQuery(sql, parameters);
        }
    }
}
