namespace UserManagement.Api.ViewModels
{
    public class DataTablesViewModel
    {
        public int Start { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public int Length { get; set; }
        public int Draw { get; set; } // Important - required by DataTables for ajax requests
        public object Data { get; set; }
    }
}