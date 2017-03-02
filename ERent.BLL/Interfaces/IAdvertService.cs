using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERent.BLL.DTO;

namespace ERent.BLL.Interfaces
{
    /// <summary>
    /// get & make advert interface - for interconnecting with other levels
    /// </summary>
    public interface IAdvertService
    {
        /// <summary>
        /// make the advert for current apartment
        /// </summary>
        /// <param name="appartmentDto"></param>
        void MakeAdvert(ApartmentDTO appartmentDto);

        /// <summary>
        /// get apartment advert by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApartmentDTO GetAdvert(int? id);

        /// <summary>
        /// get all apartment adverts
        /// </summary>
        /// <returns></returns>
        IEnumerable<ApartmentDTO> GetAdverts();
        
        void Dispose();
    }
}
