using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    /*
    public class QueryOptions
    {


        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }


        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }



        public QueryOptions()
        {

            SortField = "Id";
            SortOrder = SortOrder.ASC;

            CurrentPage = 1;
            PageSize = 5;
        }

        public string Sort
        {
            get
            {
                return string.Format("{0} {1}",
                SortField, SortOrder.ToString());
            }
        }
    }


    public enum SortOrder
    {
        ASC,
        DESC
    }
     */

    /* 因為要轉成JASON, 如果不定義, 就會用開頭大寫的變量名 */
    public class QueryOptions
    {
        public QueryOptions()
        {
            CurrentPage = 1;
            PageSize = 5;

            SortField = "Id";
            SortOrder = ViewModels.SortOrder.ASC.ToString();
        }

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "sortField")]
        public string SortField { get; set; }

        [JsonProperty(PropertyName = "sortOrder")]
        public string SortOrder { get; set; }

        [JsonIgnore]
        public string Sort
        {
            get
            {
                return string.Format("{0} {1}",
                    SortField, SortOrder);
            }
        }
    }


    public enum SortOrder
    {
        ASC,
        DESC
    }
}