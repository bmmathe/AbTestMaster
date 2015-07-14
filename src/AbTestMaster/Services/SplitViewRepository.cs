using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AbTestMaster.Domain;
using AbTestMaster.Target;

namespace AbTestMaster.Services
{
    internal class SplitViewRepository
    {
        public SplitView GetSplitView(SplitView splitView)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[TargetService.Config.SplitViews.ConnectionStringName].ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT * FROM [dbo].[AbSplitView] WHERE SplitName = @SplitName";
                        cmd.Parameters.AddWithValue("@SplitName", splitView.SplitViewName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var splitGroupOrdinal = reader.GetOrdinal("SplitGroup");
                                var splitGoalOrdinal = reader.GetOrdinal("SplitGoal");
                                var ratioOrdinal = reader.GetOrdinal("Ratio");

                                if (!reader.IsDBNull(splitGroupOrdinal))
                                {
                                    splitView.SplitGroup = reader.GetString(splitGroupOrdinal);
                                }

                                if (!reader.IsDBNull(splitGoalOrdinal))
                                {
                                    splitView.Goal = reader.GetString(splitGoalOrdinal);
                                }

                                if (!reader.IsDBNull(ratioOrdinal))
                                {
                                    splitView.Ratio = reader.GetDouble(ratioOrdinal);
                                }
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (TargetService.Config.Targets.ThrowExceptions)
                {
                    throw new Exception("Exception occurred in AbTestMaster when writing to database. Error Message: " + ex.Message);
                }
            }
            return splitView;
        }
    }
}
