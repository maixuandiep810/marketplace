using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class LangNgheDanhMuc : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }    
    

        public int LangNgheId { get; set; }
        public int DanhMucId { get; set; }


        public virtual LangNghe LangNghe { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
