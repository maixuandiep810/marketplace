using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class ProductTranslation : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }


        public int ProductId { set; get; }
        public string LanguageId { set; get; }


        public virtual Product Product { get; set; }
        public virtual Language Language { get; set; }
    }
}
