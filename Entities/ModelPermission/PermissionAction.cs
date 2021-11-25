using System.Collections.Generic;

namespace Entities.ModelPermission
{
    public class PermissionAction
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
        public List<string> FullNames { get; set; }
    }
}
