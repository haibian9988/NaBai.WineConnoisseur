using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using NABAI.Authorization.Roles;

namespace NABAI.Roles.Dto
{
    public class CreateRoleDto
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(AbpRoleBase.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        [StringLength(Role.MaxDescriptionLength)]
        public string Description { get; set; }

        public List<string> GrantedPermissions { get; set; }
    }
}
