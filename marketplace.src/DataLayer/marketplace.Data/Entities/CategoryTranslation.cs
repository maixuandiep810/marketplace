using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class CategoryTranslation : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }

        
        public string LanguageId { set; get; }
        public int CategoryId { set; get; }


        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }

    }
}
