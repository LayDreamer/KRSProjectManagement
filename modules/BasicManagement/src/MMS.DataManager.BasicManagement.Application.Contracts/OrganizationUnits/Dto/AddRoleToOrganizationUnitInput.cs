namespace MMS.DataManager.BasicManagement.OrganizationUnits.Dto;

public class AddRoleToOrganizationUnitInput
{
    public List<Guid> RoleId { get; set; }
    
    public Guid OrganizationUnitId { get; set; }
}