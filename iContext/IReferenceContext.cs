using System;
using Models;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public interface IReferenceContext
    {
        bool AddReference(ReferenceInfo reference);
        bool RemoveReference(string id);
        bool EditReference(ReferenceInfo reference);
        List<ReferenceInfo> GetReference();
        ReferenceInfo GetReferenceByID(string id);
    }
}
