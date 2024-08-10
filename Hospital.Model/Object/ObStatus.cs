using System;

namespace Hospital.App
{
    [Serializable]
    public class ObStatus
    {
        public ActionRec Action { get; set; }
        public string TrangThai { get; set; }
        public string CreateBy { get; set; }
        public string CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateTime { get; set; }
        public string DeleteBy { get; set; }
        public string DeleteTime { get; set; }
        public ObStatus() {
            TrangThai = "";
            CreateBy = "";
            CreateTime = "";
            UpdateBy = "";
            UpdateTime = "";
            DeleteBy = "";
            DeleteTime = "";
        }
    }

}
