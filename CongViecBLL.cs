using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_nhom_C_
{
    internal class CongViecBLL
    {
        CongViecDAL dalCV;
        public CongViecBLL()
        {
            dalCV = new CongViecDAL();
        }

        public DataTable getAllCongViec()
        {
            return dalCV.getAllCongViec();
        }

        public bool insertCongViec(tblCongViec cv)
        {
            return dalCV.insertCongViec(cv);
        }
        public bool updateCongViec(tblCongViec cv)
        {
            return dalCV.updateCongViec(cv);
        }
        public bool deleteCongViec(tblCongViec cv)
        {
            return dalCV.deleteCongViec(cv);
        }

        public DataTable findCongViec(string cv)
        {
            return dalCV.findCongViec(cv);
        }
    }
}
