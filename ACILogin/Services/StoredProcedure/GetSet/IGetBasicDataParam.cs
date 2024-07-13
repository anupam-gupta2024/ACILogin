namespace ACILogin.Services.StoredProcedure.GetSet
{
    public interface IGetBasicDataParam
    {
        int Action { get; set; }
        string? TestDate { get; set; }
        string? Class { get; set; }
        string? R1 { get; set; }
        string? R2 { get; set; }
        string? R3 { get; set; }
        string? Zoneid { get; set; }
        string? permission { get; set; }
    }

    public class GetBasicDataParam : IGetBasicDataParam
    {
        public int Action { get; set; }
        public string? TestDate { get; set; }
        public string? Class { get; set; }
        public string? R1 { get; set; }
        public string? R2 { get; set; }
        public string? R3 { get; set; }
        public string? Zoneid { get; set; }
        public string? permission { get; set; }
    }
}
