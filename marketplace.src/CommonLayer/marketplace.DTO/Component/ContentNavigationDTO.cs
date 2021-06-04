using System.Collections.Generic;
namespace marketplace.DTO.Component
{
    public class ContentNavigationDTO
    {
        public List<NavigationDTO> NavigationDTO { get; set; }
        public ContentNavigationDTO()
        {
            NavigationDTO = new List<NavigationDTO>();
        }
    }
}