﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ITaiKhoanBusiness
    {
        TaiKhoanModel Login(string TenTaiKhoan, string MatKhau);
        bool Create(TaiKhoanModel model);
        TaiKhoanModel GetDatabyID(string id);
        bool Update(TaiKhoanModel model);
        bool Delete(string MaTaiKhoan);
    }
}
