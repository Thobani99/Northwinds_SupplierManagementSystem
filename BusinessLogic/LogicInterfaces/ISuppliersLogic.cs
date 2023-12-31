﻿using DataLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LogicInterfaces
{
    public interface ISuppliersLogic
    {
        DataTable GetSuppliers();

        void AddSupplier(string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax);

        void UpdateSupplier(int SupplierId,string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax);

        void DeleteSupplier(int SupplierId);

        Suppliers GetSupplierBySupplierId(int SupplierId);
    }
}
