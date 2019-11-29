using System.Collections.Generic;
using DAL.DTO;

namespace DAL.SQLcontext
{
    public interface IReferenceContext
    {
        bool AddReference(ReferenceDTO reference);
        bool RemoveReference(string id);
        bool EditReference(ReferenceDTO reference);
        List<ReferenceDTO> GetReference();
        ReferenceDTO GetReferenceByID(string id);
    }
}
