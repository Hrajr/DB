﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock
{
    public class MockReference
    {
        public List<Reference> ListReferences = new List<Reference>();
        
        public List<Reference> GetAllReferences()
        {
            ListReferences.Add(ReferenceMock);
            ListReferences.Add(ReferenceMock2);
            ListReferences.Add(ReferenceMock3);
            return ListReferences;
        }

        public Reference ReferenceMock = new Reference
        {
            CompanyName = "TestCompany",
            ContactName = "TestContactName",
            Address = "TestAddress",
            Zipcode = "TestZipcodeCompany",
            Place = "TestPlace",
            Country = "TestCountry",
            PhoneNumber = "TestPhone",
            Email = "TestEmail",
            Bank = "TestBank",
            BIC = "TestBIC",
            IBAN = "TestIBAN",
            KvK = "TestKvK",
            VAT = "TestVAT",
            Doubtfull = false,
            Date = DateTime.Now.Date,
            Note = "This is a test company for testing purpose only"
        };

        public Reference ReferenceMock2 = new Reference
        {
            CompanyName = "TestCompany2",
            ContactName = "TestContactName2",
            Address = "TestAddress2",
            Zipcode = "TestZipcodeCompany2",
            Place = "TestPlace2",
            Country = "TestCountry2",
            PhoneNumber = "TestPhone2",
            Email = "TestEmail2",
            Bank = "TestBank2",
            BIC = "TestBIC2",
            IBAN = "TestIBAN2",
            KvK = "TestKvK2",
            VAT = "TestVAT2",
            Doubtfull = false,
            Date = DateTime.Now.Date,
            Note = "This is a test company 2 for testing purpose only"
        };

        public Reference ReferenceMock3 = new Reference
        {
            CompanyName = "TestCompany3",
            ContactName = "TestContactName3",
            Address = "TestAddress3",
            Zipcode = "TestZipcodeCompany3",
            Place = "TestPlace3",
            Country = "TestCountry3",
            PhoneNumber = "TestPhone3",
            Email = "TestEmail3",
            Bank = "TestBank3",
            BIC = "TestBIC3",
            IBAN = "TestIBAN3",
            KvK = "TestKvK3",
            VAT = "TestVAT3",
            Doubtfull = false,
            Date = DateTime.Now.Date,
            Note = "This is a test company 3 for testing purpose only"
        };
    }
}
