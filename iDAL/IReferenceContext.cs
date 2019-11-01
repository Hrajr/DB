using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public interface IReferenceContext
    {
        bool AddReference(Reference reference);
        bool RemoveReference(string id);
        bool EditReference(Reference reference);
        List<Reference> GetReference();
        Reference GetReferenceByID(string id);
    }
}
