namespace ACILogin.Models
{
    public class DataConnection
    {
        public required string DefaultConnection { get; set; }
        public required string DefaultConnection2 { get; set; }

        public enum ConnectionTypes
        {
            DefaultConnection,
            DefaultConnection2
        }
    }

    //public interface IConnectionTypes
    //{
    //    string getConnectionType();
    //}
}
