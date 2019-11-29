﻿using DAL.DTO;
using DAL.SQLcontext;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReferenceLogic
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Bank { get; set; }
        public string BIC { get; set; }
        public string IBAN { get; set; }
        public string KvK { get; set; }
        public string VAT { get; set; }
        public bool Doubtfull { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        private readonly IReferenceContext _context;

        public ReferenceLogic()
        {
            _context = new ReferenceContext();
        }

        public ReferenceLogic(ReferenceDTO reference)
        {
            ID = reference.ID;
            CompanyName = reference.CompanyName;
            ContactName = reference.ContactName;
            Address = reference.Address;
            Zipcode = reference.Zipcode;
            Place = reference.Place;
            Country = reference.Country;
            PhoneNumber = reference.PhoneNumber;
            Email = reference.Email;
            Bank = reference.Bank;
            BIC = reference.BIC;
            IBAN = reference.IBAN;
            KvK = reference.KvK;
            VAT = reference.VAT;
            Doubtfull = reference.Doubtfull;
            Date = reference.Date;
            Note = reference.Note;
        }

        public bool AddReference(ReferenceLogic reference)
        {
            return _context.AddReference(ConvertToDTO(reference));
        }

        public bool RemoveReference(string id)
        { 
            return _context.RemoveReference(id); 
        }

        public bool EditReference(ReferenceLogic reference)
        {
            return _context.EditReference(ConvertToDTO(reference));
        }

        public ReferenceDTO ConvertToDTO(ReferenceLogic reference)
        {
            var ReturnedRef = new ReferenceDTO()
            {
                ID = reference.ID,
                CompanyName = reference.CompanyName,
                ContactName = reference.ContactName,
                Address = reference.Address,
                Zipcode = reference.Zipcode,
                Place = reference.Place,
                Country = reference.Country,
                PhoneNumber = reference.PhoneNumber,
                Email = reference.Email,
                Bank = reference.Bank,
                BIC = reference.BIC,
                IBAN = reference.IBAN,
                KvK = reference.KvK,
                VAT = reference.VAT,
                Doubtfull = reference.Doubtfull,
                Date = reference.Date,
                Note = reference.Note,
            };
            return ReturnedRef;
        }

        public List<ReferenceLogic> GetReference()
        {
            return _context.GetReference().ConvertAll(x => new ReferenceLogic { ID = x.ID, CompanyName = x.CompanyName, ContactName = x.ContactName, Address = x.Address, Zipcode = x.Zipcode, Place = x.Place, Country = x.Country, PhoneNumber = x.PhoneNumber, Email = x.Email, Bank = x.Bank, BIC = x.BIC, IBAN = x.IBAN, KvK = x.KvK, VAT = x.VAT, Doubtfull = x.Doubtfull, Date = x.Date, Note = x.Note});
        }

        public ReferenceLogic GetReferenceByID(string id)
        {
            return new ReferenceLogic(_context.GetReferenceByID(id));
        }
    }
}
