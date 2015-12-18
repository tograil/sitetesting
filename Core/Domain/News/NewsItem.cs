using System.Collections.Generic;

namespace Core.Domain.News
{
    public class NewsItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<NewsCheck> ApprovalStatusHistory { get; set; }
    }
}
