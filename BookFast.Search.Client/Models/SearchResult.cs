// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace BookFast.Search.Client.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SearchResult
    {
        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        public SearchResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SearchResult class.
        /// </summary>
        public SearchResult(double? score = default(double?), IDictionary<string, IList<string>> highlights = default(IDictionary<string, IList<string>>), IDictionary<string, object> document = default(IDictionary<string, object>))
        {
            Score = score;
            Highlights = highlights;
            Document = document;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "highlights")]
        public IDictionary<string, IList<string>> Highlights { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "document")]
        public IDictionary<string, object> Document { get; set; }

    }
}
