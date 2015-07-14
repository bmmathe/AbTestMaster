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
                        cmd.CommandText = @"SELECT SplitGroup, SplitGoal, Ratio FROM [dbo].[AbSplitView] WHERE SplitName = @SplitName";
                        cmd.Parameters.AddWithValue("@SplitName", splitView.SplitViewName);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {                                
                                if (!reader.IsDBNull(0))
                                {
                                    splitView.SplitGroup = reader.GetString(0);
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    splitView.Goal = reader.GetString(1);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    splitView.Ratio = reader.GetDouble(2);
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
