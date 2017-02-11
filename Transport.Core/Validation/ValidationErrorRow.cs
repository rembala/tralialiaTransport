namespace Transport.Core.Validation
{
    public class ValidationErrorRow
    {
        public string ColumnName { get; set; }
        public string Message { get; set; }

        public ValidationErrorRow(string columnName = "", string message = "")
        {
            ColumnName = columnName;
            Message = message;
        }
    }
}
