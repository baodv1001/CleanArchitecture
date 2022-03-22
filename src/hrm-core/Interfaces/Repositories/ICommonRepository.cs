namespace hrm_core.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        Task<Guid> GetBaseRole();
        Task<string> GetDepartmentPrefix(Guid teamId);
        Task<int> GetEmployeeNum();
        Task SeedSampleData();
    }
}
