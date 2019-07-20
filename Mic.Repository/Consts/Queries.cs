namespace Mic.Repository.Consts
{
    public static class Queries
    {
        public const string SelectAll = "Select * From {0}";
        public const string Select = "Select * From {0} Where {1}";
        public const string SelectOne = "Select * From {0} Where {1} = {2}";
        public const string Insert = "INSERT INTO {0}({1}) VALUES({2})";
        public const string InsertScalar = "INSERT INTO {0}({1}) VALUES({2})" + "SELECT CAST(scope_identity() AS int)";
        public const string Where = "Where";
    }
}
