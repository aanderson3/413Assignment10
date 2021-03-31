using System;
namespace _413Bowling.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //calc num of pages and cast
        public int NumPages => (int) (Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
    }
}
