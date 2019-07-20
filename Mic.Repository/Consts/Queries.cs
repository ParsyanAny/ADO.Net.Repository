namespace Mic.Repository.Consts
{
    public static class Queries
    {
        public const string SelectAll = "SELECT * FROM {0}";
        public const string Select = "SELECT * FROM {0} WHERE {1}";
        public const string SelectOne = "SELECT * FROM {0} WHERE {1} = {2}";
        public const string Insert = "INSERT INTO {0}({1}) VALUES({2})";
        public const string InsertScalar = "INSERT INTO {0}({1}) VALUES({2})" + "SELECT CAST(scope_identity() AS int)";
        public const string Update = "UPDATE {0} SET {1}={2} WHERE Id = {3}";
        public const string Delete = "DELETE FROM {2} WHERE {1}";
        //public const string Where = "WHERE";
    }
}
