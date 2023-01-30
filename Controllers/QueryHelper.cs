using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
namespace WalkinAPI.Models;
using MySqlConnector;
using Dapper;
using System.Transactions;



public class QueryHelper
{
    public DBConnect Db { get; }

    public QueryHelper(DBConnect db)
    {
        Db = db;
    }

    public async Task<Prefetch> GetData()
    {
        string sql = "call prefetch()";
        Prefetch Result = new Prefetch();

        var results = await Db.Connection.QueryMultipleAsync(sql);
        Result.Technologies = await results.ReadAsync<Technology>();
        Result.Roles = await results.ReadAsync<JobRole>();
        Result.Colleges = await results.ReadAsync<College>();
        Result.Streams = await results.ReadAsync<Branch>();
        Result.Qualifications = await results.ReadAsync<Qualification>();

        return Result;
    }

    public async Task<int> CreateUser(CreateUser user)
    {
        try
        {
            TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            string sql = $"call create_user('{user.password}','{user.profile_picture}','{user.firstname}','{user.lastname}','{user.email}','{user.phone_no}','{user.resume_link}','{user.portfolio_link}','{user.referal}',{user.send_mail},'{user.previously_applied_role}',{user.applicant_type_id},{user.passing_year},{user.percentage},'{user.college_location}',{user.stream_id},{user.qualification_id},{user.college_id})";
            int result = await Db.Connection.QuerySingleAsync<int>(sql);
            if (result != -1)
            {
                if (user.preferred_job_roles != null)
                {
                    await Db.Connection.QueryAsync($"call pref_job_role({result},'{user.preferred_job_roles}')");
                }

                if (user.familiar_tech != null)
                {
                    await Db.Connection.QueryAsync($"call familiar_tech({result},'{user.familiar_tech}')");
                }

                if (user.other_familiar_tech != "")
                {
                    await Db.Connection.QueryAsync($"call familiar_tech_other({result},'{user.other_familiar_tech}')");
                }

                if (user.applicant_type_id == 2)
                {
                    var query = $"call experience({user.years},'{user.current_ctc}','{user.expected_ctc}','{user.notice_period_end}','{user.notice_duration}',{result})";
                    var exp_id = await Db.Connection.QuerySingleAsync<int>(query);

                    if (user.expertise_tech != null)
                    {
                        await Db.Connection.QueryAsync($"call expertise_tech({exp_id},'{user.expertise_tech}')");
                    }

                    if (user.other_familiar_tech != "")
                    {
                        await Db.Connection.QueryAsync($"call expertise_tech_other({exp_id},'{user.other_expertise_tech}')");
                    }
                }
            }
            scope.Complete();
            Db.Connection.Close();
            return result;
        }
        catch
        {
            Db.Connection.Close();
            return -1;
        }
    }
}



