namespace WalkinAPI.Models;

public class CreateUser
{
    public string? password { get; set; }
    public string? profile_picture { get; set; }
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? email { get; set; }
    public string? phone_no { get; set; }
    public string? resume_link { get; set; }
    public string? portfolio_link { get; set; }
    public string? referal { get; set; }
    public int? send_mail { get; set; }
    public string? previously_applied_role { get; set; }
    public int? applicant_type_id { get; set; }
    public short passing_year { get; set; }
    public decimal percentage { get; set; }
    public string? college_location { get; set; }
    public int stream_id { get; set; }
    public int qualification_id { get; set; }
    public int college_id { get; set; }
    public string? preferred_job_roles { get; set; }
    public string? familiar_tech { get; set; }
    public string? other_familiar_tech { get; set; }

    public int years { get; set; }
    public string? current_ctc { get; set; }
    public string? expected_ctc { get; set; }
    public string? notice_period_end { get; set; }
    public string? notice_duration { get; set; }
    public string? expertise_tech { get; set; }
    public string? other_expertise_tech { get; set; }
}