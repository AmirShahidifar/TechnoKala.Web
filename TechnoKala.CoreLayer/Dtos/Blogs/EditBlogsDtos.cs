namespace TechnoKala.CoreLayer.Dtos.Blogs
{
    public class EditBlogsDtos
    {
        public int id { get; set; }
        public int category_id { get; set; }

        public string title { get; set; }

        public string image { get; set; }

        public string description { get; set; }

    }
}
