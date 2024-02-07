namespace Blog.Application.QueryParams
{
    public class PostQueryParameters : BaseQueryParameters
    {
        private string _sortBy = "createdAt";
        public string SortBy
        {
            get => _sortBy;
            set { _sortBy = value; }
        }

        private string _orderBy = "desc";
        public string OrderBy
        {
            get => _orderBy;
            set { _orderBy = value; }
        }

        private bool? _isFeatured;
        public bool? IsFeatured
        {
            get => _isFeatured;
            set
            {
                if (value != null) _isFeatured = value;
            }
        }

        private Guid _idNotEqual;
        public Guid IdNotEqual
        {
            get => _idNotEqual;
            set { _idNotEqual = value; }
        }

        private Guid _categoryId;
        public Guid CategoryId
        {
            get => _categoryId;
            set { _categoryId = value; }
        }

        private int _limit = 5;
        public int Limit
        {
            get => _limit;
            set { _limit = value; }
        }
    }
}
