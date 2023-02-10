using System.Collections.Generic;

namespace SimpleCRUD_NET_6.Api.Handlers.Dtos
{
    public class ListResponse
    {
        public dynamic Data { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
    }

    public class DataTableQuery
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTableSearch Search { get; set; }
        public List<DataTableOrder> Order { get; set; }
        public List<DataTableColumn> Columns { get; set; }
    }

    public class DataTableSearch
    {
        public string Value { get; set; }
        public string Regex { get; set; }
    }

    public class DataTableOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class DataTableColumn
    {
        public string Data { get; set; }
    }
}