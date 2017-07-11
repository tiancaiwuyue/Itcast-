using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast视频WinForm
{
    static class GlobalHelper
    {
        //存储当前登录的用户主键
        public static int _autoId { get; set; } 
    }
    public class TblClass
    {
        public int TClassID { get; set; }
        public string TClassName { get; set; }
        public string TClassDesc { get; set; }
    }
    public class TblArea
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int AreaPID { get; set; }
        public override string ToString()
        {
            return AreaName;
        }
    }
    public class TblFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pid { get; set; }
        public string Note { get; set; }
    }
    public class TblFile02
    {
        public int did { get; set; }
        public string dName { get; set; }
        public string dContent { get; set; }
        public string dintime { get; set; }
        public string dEdittime { get; set; }
        public byte dIsDeleted { get; set; }
        public override string ToString()
        {
            return dName;
        }
    }
    public class PhoneType
    {
        public int PTID { get; set; }
        public string PTName { get; set; }
    }
    public class PhoneNum
    {
        public int PID { get; set; }
        //public int PTypeID { get; set; }
        public PhoneType Group { get; set; }
        public string PName { get; set; }
        public string PCellPhone { get; set; }
        public string PHomePhone { get; set; }
    }
}
