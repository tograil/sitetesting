namespace Core.DomainUnits
{
    public static class RolesUnits
    {
        public enum UserType
        {
            Customer,
            Admin
        }

        public enum Permission
        {
            CreateUser,
            UpdateAnyProfile,
            UpdateOwnProfile,
            AddOrEditOwnPost,
            AddEditOrApproveAnyPost
        }

        public enum ApprovalStatus
        {
            Approved,
            Denied,
            Banned
        }
    }
}
