using DAL.SQLcontext;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReferenceLogic
    {
        private readonly IReferenceContext _context;

        public ReferenceLogic()
        {
            _context = new ReferenceContext();
        }

        public bool AddReference(Reference reference)
        { 
            return _context.AddReference(reference);
        }

        public bool RemoveReference(string id)
        { 
            return _context.RemoveReference(id); 
        }

        public bool EditReference(Reference reference)
        { 
            return _context.EditReference(reference); 
        }

        public List<Reference> GetReference()
        {
            return _context.GetReference();
        }

        public Reference GetReferenceByID(string id)
        {
            return _context.GetReferenceByID(id);
        }
    }
}
