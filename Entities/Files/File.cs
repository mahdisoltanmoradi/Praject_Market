using Entities.Common;

namespace Entities.Files
{
    public class File : BaseEntity<int>
    {
        public string Address { get; set; }
        public string ThumbnailAddress { get; set; }
        public string Title { get; set; }
        public long size { get; set; }
        public string fileformat { get; set; }

    }
}
