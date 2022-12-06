using System;

namespace ContentMgmtCore.Model
{
    public class DBBakInfo
    {
        public long RecId { get; set; }
        public string DBName { get; set; } 
        public DateTime BakDatetime { get; set; } 
        public string FileName { get; set; }
        public string FileAbsolutePath { get; set; } 
        public int Status { get; set; }

        public DateTime RecordTime { get; set; }

        public DBBakInfo() { }

        public DBBakInfo(string _DBName,DateTime _BakDatetime, string _FileName,string _FileAbsolutePath) 
        {
            this.Status = 1;
            this.DBName = _DBName;
            this.BakDatetime = _BakDatetime;
            this.FileName = _FileName;
            this.FileAbsolutePath = _FileAbsolutePath; 
        }
    }  
}
